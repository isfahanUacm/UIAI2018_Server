using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
public class GameManager : MonoBehaviour {

    public static GameManager refrence;

    public enum Turn { team1, team2 };
    public Turn turn;
    public enum GameState { moving, frozen , goalHappend };
    public GameState gameState;
    public bool shouldCheckState;

    public GameObject[] allPlayers;
    public GameObject[] playersTeam1;
    public GameObject[] playersTeam2;
    public GameObject ball;
    Vector3 ballStartPos;
    public int index;

    public Vector3[] startPos;

    public int team1Score;
    public int team2Score;
    public Text yellowTeamScore;
    public Text redTeamScore;
    public bool goalHappen = false;

    //public enum Mode { pvp, pvc, cvc }; // player vs player or player vs code or code vs code
    //public Mode gameMode;

    public bool AplayerIsMoving;

    public AudioSource crowed;
    //public AudioClip[] crowedClips;
    public AudioSource bgMusic;
    public AudioSource GoalVoice;
    public AudioSource GoalCrowed;
    public AudioSource ballAndPlayers;
    public AudioSource soot;

    Vector2 direction;    
    public GameObject test;
    public int ID;
    public int angle;
    public float power;

    //_________________________________________________________________________________
    public static TcpClient team1_sock, team2_sock;
    public static StreamReader team1_sr, team2_sr;
    public static StreamWriter team1_sw, team2_sw;
    string team1_name, team2_name, team1_logo, team2_logo;
    public int cycle_no;
    public static StreamWriter game_log_sw, com_log_sw; //StreamWriters of game.log & communication.log
    //_________________________________________________________________________________


    void Awake()
    {
        if (refrence == null)
        {
            refrence = this;
        }
        startPos = new Vector3[10];
        for (int i = 0; i < 10; i++)
        {
            startPos[i] = allPlayers[i].transform.position;
        }
        team1Score = team2Score = 0;
        ballStartPos = ball.transform.position;
    }

    void Start()
    {
        turn = Turn.team1; //@TODO who should starts the game?
        shouldCheckState = false;
        for (int i = 0; i < allPlayers.Length; i++)
        {
            allPlayers[i].GetComponent<PlayerController>().activePlayer();
        }
        //crowed.clip = crowedClips[0];
        crowed.Play();

        //Mahdi:
        //use this StreamWriter to create the game's log file
        game_log_sw = new StreamWriter("Game.log", false);
        //use this StreamWriter to create communication.log file
        com_log_sw = new StreamWriter("Communication.log", false);

        if (MenuManager.refrence.gameMode == MenuManager.Mode.cvc)
        {
            if (!start_server(9595))
                return;

            team1_sr = new StreamReader(team1_sock.GetStream());
            team2_sr = new StreamReader(team2_sock.GetStream());

            team1_sw = new StreamWriter(team1_sock.GetStream());
            team2_sw = new StreamWriter(team2_sock.GetStream());
            

            Team_init(team1_sr, out team1_name, out team1_logo, playersTeam1);
            Team_init(team2_sr, out team2_name, out team2_logo, playersTeam2);
        }
    }

    private static int team_no = 0;

    static void Team_init(StreamReader team_sr, out string team_name, out string team_logo, GameObject[] team_players)
    {
        if (team_no == 0)
        {
            com_log_sw.WriteLine("C1 -> S :");
        }
        else
        {
            com_log_sw.WriteLine();
            com_log_sw.WriteLine("C2 -> S:");
        }
        string tmp;
        tmp = team_sr.ReadLine(); //register team_name
        com_log_sw.WriteLine(tmp);
        if (!tmp.Substring(0, 8).Equals("register"))
        {
            print("wrong command");
            //return;
        }
        //team1 NAME:
        team_name = tmp.Substring(9);
        game_log_sw.WriteLine(team_name); //log team name

        tmp = team_sr.ReadLine(); //logo ...
        com_log_sw.WriteLine(tmp);
        if (!tmp.Substring(0, 4).Equals("logo"))
        {
            print("wrong command");
            //return;
        }
        //team1 LOGO:
        team_logo = tmp.Substring(5);
        game_log_sw.WriteLine(team_logo); //log team logo

        tmp = team_sr.ReadLine(); //formation name1:x1:y1,name2:x2:y2,name3:x3:y3,name4:x4:y4,name5:x5:y5
        com_log_sw.WriteLine(tmp);
        if(team_no==1)
            com_log_sw.WriteLine("_________________________");
        com_log_sw.Flush();
        if (!tmp.Substring(0, 9).Equals("formation"))
        {
            print("wrong command");
            //return;
        }
        //team1 FORMATION
        int i = 0;
        foreach (string player in tmp.Substring(9).Split(','))
        {
            string[] ss = player.Split(':');
            team_players[i].GetComponent<PlayerController>().name = ss[0]; //@TODO notworking
            team_players[i].GetComponent<PlayerController>().Name.text= ss[0]; //@TODO notworking

            Vector3 pos;
            if(team_no==0)
                pos = new Vector3(float.Parse(ss[1]), float.Parse(ss[2]));
            else
                pos = new Vector3(float.Parse(ss[1]) * -1, float.Parse(ss[2]));
            team_players[i].transform.position = pos; //@TODO

            i++;
        }
        team_no = 1;
        game_log_sw.WriteLine(tmp.Substring(10)); //log team players
    }

    static bool start_server(int port)
    {
        TcpListener serversocket = new TcpListener(port);
        try
        {
            serversocket.Start();
            team1_sock = serversocket.AcceptTcpClient();
            team2_sock = serversocket.AcceptTcpClient();
            serversocket.Stop();
        }
        catch (Exception ex)
        {
            print("Connection Failed!");
            print(ex.ToString());
            return false;
        }
        return true;
    }
    
    void Update() {
        checkGameState();

        //MahD:
        if (MenuManager.refrence.gameMode == MenuManager.Mode.cvc) //Code vs Code
        {
            if (GameManager.refrence.gameState != GameManager.GameState.frozen)
                return;



            //log the pervious move: ________________________________________________________________________________________________________________
            if (cycle_no!=0)
            {
                for(int i=0;i<5;i++) //team1 players positions
                {
                    game_log_sw.Write(string.Format("{0}:{1}", playersTeam1[i].transform.position.x, playersTeam1[i].transform.position.y));
                    if (i != 4)
                        game_log_sw.Write(",");
                    else
                        game_log_sw.WriteLine();
                }

                for (int i = 0; i < 5; i++) //team2 players positions
                {
                    game_log_sw.Write(string.Format("{0}:{1}", playersTeam2[i].transform.position.x, playersTeam2[i].transform.position.y));
                    if (i != 4)
                        game_log_sw.Write(",");
                    else
                        game_log_sw.WriteLine();
                }

                game_log_sw.WriteLine(string.Format("{0}:{1}", ball.transform.position.x, ball.transform.position.y)); //ball position

                game_log_sw.WriteLine(string.Format("{0}-{1}", team1Score, team2Score)); //scores

                game_log_sw.Flush();

            }

            game_log_sw.WriteLine("______________________________________________________________________________");
            //______________________________________________________________________________________________________________________________________

            string[] responce;

            string text = "";
            cycle_no++;
            game_log_sw.WriteLine(cycle_no);
            if (turn == Turn.team1)
            {
                string self_poses = "", opp_poses = "";
                for (int i = 0; i < 5; i++)
                {
                    self_poses += string.Format("{0}:{1}", playersTeam1[i].transform.position.x, playersTeam1[i].transform.position.y);
                    if (i != 4)
                        self_poses += ",";
                }
                for (int i = 0; i < 5; i++)
                {
                    opp_poses += string.Format("{0}:{1}", playersTeam2[i].transform.position.x, playersTeam2[i].transform.position.y);
                    if (i != 4)
                        opp_poses += ",";
                }

                text = string.Format("{0}\n{1}\n{2}:{3}\n{4},{5},{6}",
                    self_poses, opp_poses, ball.transform.position.x, ball.transform.position.y, team1Score, team2Score, cycle_no);

                team1_sw.WriteLine(text);
                team1_sw.Flush();
                //Data has been sent to the client

                //log the communication from Server to Client1:
                com_log_sw.WriteLine();
                com_log_sw.WriteLine("S -> C1 :");
                com_log_sw.WriteLine(text.Replace("\n", Environment.NewLine));
                com_log_sw.WriteLine();
                com_log_sw.Flush();

                responce = team1_sr.ReadLine().Trim().Split(',');
                print(string.Format("team1 resp: ({0}, {1}, {2})", responce[0], responce[1], responce[2]));
                //Data has been received from the client

                //log the communication from Client1 to Server:
                com_log_sw.WriteLine("C1 -> S :");
                com_log_sw.WriteLine(string.Format("{0},{1},{2}", responce[0], responce[1], responce[2]));
                com_log_sw.WriteLine("_________________________");
                com_log_sw.Flush();

            }
            else /*if (turn == Turn.team2)*/
            {
                string self_poses = "", opp_poses = "";
                for (int i = 0; i < 5; i++)
                {
                    self_poses += string.Format("{0}:{1}", playersTeam2[i].transform.position.x * -1, playersTeam2[i].transform.position.y);
                    if (i != 4)
                        self_poses += ",";
                }
                for (int i = 0; i < 5; i++)
                {
                    opp_poses += string.Format("{0}:{1}", playersTeam1[i].transform.position.x * -1, playersTeam1[i].transform.position.y);
                    if (i != 4)
                        opp_poses += ",";
                }

                text = string.Format("{0}\n{1}\n{2}:{3}\n{4},{5},{6}",
                    self_poses, opp_poses, ball.transform.position.x * -1, ball.transform.position.y, team2Score, team1Score, cycle_no);

                team2_sw.WriteLine(text);
                team2_sw.Flush();
                //Data sent to the client

                //log the communication from server to Client2:
                com_log_sw.WriteLine();
                com_log_sw.WriteLine("S -> C2 :");
                com_log_sw.WriteLine(text.Replace("\n", Environment.NewLine));
                com_log_sw.WriteLine();
                com_log_sw.Flush();

                responce = team2_sr.ReadLine().Trim().Split(',');
                print(string.Format("team2 resp: ({0}, {1}, {2})", responce[0], responce[1], responce[2]));
                //Data has been received from the client

                //log the communication from Client2 to Server:
                com_log_sw.WriteLine("C2 -> S :");
                com_log_sw.WriteLine(string.Format("{0},{1},{2}", responce[0], responce[1], responce[2]));
                com_log_sw.WriteLine("_________________________");
                com_log_sw.Flush();
            }

            //converting received data and SHOOT!
            int r_id;
            float r_angle, r_power;

            r_id = int.Parse(responce[0]);
            r_angle = float.Parse(responce[1]);
            r_power = float.Parse(responce[2]);

            if (turn == Turn.team1)
                Shoot(r_id, r_angle, r_power);
            else
                Shoot(r_id, ((r_angle+180))%360, r_power);
            
            //log the shoot
            game_log_sw.WriteLine("{0},{1},{2}", responce[0], responce[1], responce[2]);
        }
    }

    public void checkGameState()
    {
        if(gameState == GameState.moving && shouldCheckState)
        {
            for (int i = 0; i < allPlayers.Length; i++)
            {
                if (allPlayers[i].GetComponent<Rigidbody2D>().velocity.magnitude > .1f)
                {
                    return;
                }
            }
            if (ball.GetComponent<Rigidbody2D>().velocity.magnitude > .1f)
            {
                return;
            }
            changeTurn();
            shouldCheckState = false;
            gameState = GameState.frozen;
        }
    }


    public void changeTurn()
    {
        if(turn == Turn.team1)
            turn = Turn.team2;
        else
            turn = Turn.team1;

        for (int i = 0; i < allPlayers.Length; i++)
            allPlayers[i].GetComponent<PlayerController>().activePlayer();
    }

    public IEnumerator Goal(int index)
    {
        shouldCheckState = false;
        gameState = GameState.goalHappend;
        crowed.Stop();
        GoalCrowed.Play();
        GoalVoice.Play();
        if (index == 1)
        {
            team1Score++;
            yellowTeamScore.text ="yellow : "+ team1Score.ToString();
            turn = Turn.team2;
        }
        else if(index == 2)
        {
            team2Score++;
            redTeamScore.text = "red : " + team2Score.ToString();
            turn = Turn.team1;

        }
        
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < 10; i++)
        {
            allPlayers[i].GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            allPlayers[i].transform.position = startPos[i];
        }
        for (int i = 0; i < allPlayers.Length; i++)
        {
            allPlayers[i].GetComponent<PlayerController>().activePlayer();
        }
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ball.transform.position = ballStartPos;
        goalHappen = false;
        GoalCrowed.Stop();
        GoalVoice.Stop();
        crowed.Play();
        soot.Play();
        gameState = GameState.frozen;
        shouldCheckState = true;
    }

    public void Shoot(int ID , float angle , float pwr)
    {
        // shoot player[ID] with pwr power in direction of angle
        if (turn== Turn.team1)
        {
            playersTeam1[ID].GetComponent<PlayerController>().Shoot(angle, pwr);
        }
        else if (turn == Turn.team2)
        {
            playersTeam2[ID].GetComponent<PlayerController>().Shoot(angle, pwr);
        }
    }
}
