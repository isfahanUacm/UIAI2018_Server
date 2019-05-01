using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.IO.Compression;

public class GameManager : MonoBehaviour {

    public static GameManager refrence;

    public enum Turn { team1, team2 };
    public Turn turn;
    public enum GameState { moving, frozen, goalHappend };
    public GameState gameState;
    public enum GameHalf { firstHalf, secHalf, finish};
    public GameHalf gameHalf;
    public bool shouldCheckState;

    public GameObject[] allPlayers;
    public GameObject[] playersTeam1;
    public GameObject[] playersTeam2;
    public GameObject ball;
    Vector3 ballStartPos;
    public int index;

    public static Vector3[] startPos;

    public int team1Score;
    public int team2Score;
    public Text yellowTeamScore;
    public Text redTeamScore;
    public Text Team1Name;
    public Text Team2Name;
    public Text txt_cycleNo;
    public bool goalHappen = false;

    public bool AplayerIsMoving;

    public AudioSource crowed;
    //public AudioClip[] crowedClips;
    public AudioSource bgMusic;
    public AudioSource GoalVoice;
    public AudioSource GoalCrowed;
    public AudioSource ballAndPlayers;
    public AudioSource soot;
    public AudioSource FinalWistle;

    Vector2 direction;
    public GameObject test;
    public int ID;
    public int angle;
    public float power;

    public Slider gameSpeedSlider;
    public Text gameSpeedText;

    //_________________________________________________________________________________
    public static TcpClient team1_sock, team2_sock;
    public static StreamReader team1_sr, team2_sr;
    public static StreamWriter team1_sw, team2_sw;
    string team1_name="df_team1", team2_name="df_team2";
    public int cycle_no;
    public static StreamWriter game_log_sw, com_log_sw; //StreamWriters of game.log & communication.log
    public static StreamReader game_log_sr; //StreamReader for reading game.log and show it (in log repley mode)
    public static StreamWriter test_sw;
    const int half_game_cycle_no = 50; //number of cycles in a half
    Vector2[] default_poses = {new Vector2(-6.5f, 0), new Vector2(-2, 1), new Vector2(-5, -2), new Vector2(-5, 2), new Vector2(-2, -1) };
    double player_radius;
    public GameObject border_left, border_right, border_up, border_down;
    //_________________________________________________________________________________

    void Awake()
    {
        Time.timeScale = 1;
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
        player_radius = playersTeam1[0].GetComponent<PlayerController>().GetComponent<CircleCollider2D>().radius;
        gameHalf = GameHalf.firstHalf;
        cycle_no = 0;
        txt_cycleNo.text ="Cycle Number : "+ "0";
        turn = Turn.team1;
        shouldCheckState = false;
        for (int i = 0; i < allPlayers.Length; i++)
        {
            allPlayers[i].GetComponent<PlayerController>().activePlayer();
        }
        //crowed.clip = crowedClips[0];
        crowed.Play();

        if (MenuManager.refrence.gameMode == MenuManager.Mode.cvc)
        {
            //create template folder for screen shot pics.
            if (Directory.Exists("ScreenShots")) 
                Directory.Delete("ScreenShots", true); //remove pervious folder!

            Directory.CreateDirectory("ScreenShots/"); 
            
            //use this StreamWriter to create the game's log file
            game_log_sw = new StreamWriter("Game.log", false);
            //use this StreamWriter to create communication.log file
            com_log_sw = new StreamWriter("Communication.log", false);

            if (!start_server(9595))
                return;

            team1_sr = new StreamReader(team1_sock.GetStream());
            team2_sr = new StreamReader(team2_sock.GetStream());

            team1_sw = new StreamWriter(team1_sock.GetStream());
            team2_sw = new StreamWriter(team2_sock.GetStream());

            Team_init_cvc(team1_sr, out team1_name, playersTeam1);
            Team_init_cvc(team2_sr, out team2_name, playersTeam2);

            cvc_play_round();
        }

        else if (MenuManager.refrence.gameMode == MenuManager.Mode.log)
        {
            print("lets show this fucking log!");

            //initial this StreamReader for reading game.log
            game_log_sr = new StreamReader("Game.log");
            test_sw = new StreamWriter("test.log");

            team_init_log(out team1_name, playersTeam1, true);
            team_init_log(out team2_name, playersTeam2, false);
            log_play_round();
        }
        else if(MenuManager.refrence.gameMode == MenuManager.Mode.pvp)
        {
            cycle_no = 1;
        }

        yellowTeamScore.text = "0";
        redTeamScore.text =" 0";
        Team1Name.text = team1_name;
        Team2Name.text = team2_name;

    }

    private static int team_no = 0;

    public void team_init_log(out string team_name, GameObject[] team_players, bool first_team)
    {
        team_name = game_log_sr.ReadLine();

        int i = 0;
        foreach (string str_player in game_log_sr.ReadLine().Split(','))
        {
            string[] str_player_parts = str_player.Split(':');
            team_players[i].GetComponent<PlayerController>().name = (i+1) + ": " + str_player_parts[0];
            team_players[i].GetComponent<PlayerController>().Name.text = (i+1) + ": " + str_player_parts[0];


            Vector3 pos = new Vector3(float.Parse(str_player_parts[1]), float.Parse(str_player_parts[2]));

            team_players[i].transform.position = pos;

            if (first_team)
                startPos[i] = pos;
            else
                startPos[5 + i] = pos;

            i++;
        }

        test_sw.WriteLine(team_name);
        foreach (GameObject player in team_players)
            test_sw.Write("{0}:{1}:{2},", player.GetComponent<PlayerController>().Name.text.Substring(3), player.transform.position.x, player.transform.position.y);
        test_sw.WriteLine();

    }

    public void Team_init_cvc(StreamReader team_sr, out string team_name, GameObject[] team_players)
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
        com_log_sw.Flush();

        if (!tmp.Substring(0, 8).Equals("register"))
        {
            print("wrong command");
            //return;
        }
        //team NAME:
        team_name = tmp.Substring(9);
        game_log_sw.WriteLine(team_name); //log team name

        //team FORMATION
        tmp = team_sr.ReadLine();
        com_log_sw.WriteLine(tmp);
        com_log_sw.Flush();
        int i = 0;
        bool correct_side = true; //if a player's formation's x>0 => false
        foreach (string player in tmp.Substring(10).Split(','))
        {
            string[] ss = player.Split(':');
            team_players[i].GetComponent<PlayerController>().name = (i+1) + ": " + ss[0];
            team_players[i].GetComponent<PlayerController>().Name.text = (i+1) + ": " + ss[0];

            
            if((float.Parse(ss[1]) + player_radius)>0) //oboor az vasat zamin
            {
                correct_side = false;
                break;
            }

            Vector3 pos;
            if (team_no == 0)
                pos = new Vector3(float.Parse(ss[1]), float.Parse(ss[2]));
            else
                pos = new Vector3(float.Parse(ss[1]) * -1, float.Parse(ss[2]) * -1);

            team_players[i].transform.position = pos;
            startPos[team_no*5 + i] = pos;

            i++;
        }

        if(has_players_collision(team_players) || !correct_side)
        {
            print("players Collision! We will set your formation, ourselves!");
            set_to_default_formation(team_players, team_no);
        }


        string text = "";
        for (int j = 0; j < 5; j++)
        {
            text += team_players[j].GetComponent<PlayerController>().Name.text.Substring(3) + ":" + startPos[team_no * 5 + j].x + ":" + startPos[team_no * 5 + j].y;
            if (j != 4)
                text += ",";
        }
        game_log_sw.WriteLine(text); //log team players

        if (team_no == 1)
        {
            com_log_sw.WriteLine("_________________________");
            com_log_sw.Flush();
        }

        team_no = 1;
    }

    public IEnumerator team1_sock_accept(TcpListener serversocket)
    {
        team1_sock = serversocket.AcceptTcpClient();
        yield return null;
    }

    public IEnumerator team2_sock_accept(TcpListener serversocket)
    {
        team2_sock = serversocket.AcceptTcpClient();
        yield return null;
    }


    public bool start_server(int port)
    {
        TcpListener serversocket = new TcpListener(port);
        try
        {
            serversocket.Start();

            StartCoroutine(team1_sock_accept(serversocket));
            //MenuManager.refrence.SliderText.text = "Waiting for the 2nd Client to connect..."; //null?!
            MenuManager.refrence.slider.value = 50;

            StartCoroutine(team2_sock_accept(serversocket));
            MenuManager.refrence.slider.value = 100; 
            //wait for 0.5 sec!

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
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot(ID, angle, power);
        }*/
        checkGameState();
    }

    public void checkGameState()
    {
        if(gameHalf == GameHalf.finish)
        {
            if (MenuManager.refrence.gameMode == MenuManager.Mode.pvp)
            {
                pvp_end_game();
            }
        }
        txt_cycleNo.text = txt_cycleNo.text = "Cycle Number : " +  cycle_no.ToString();
        if (gameState == GameState.moving && shouldCheckState)
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
            shouldCheckState = false;
            gameState = GameState.frozen;

            takeout_inside_goal_players(); //@TODO
            changeTurn();

            if (MenuManager.refrence.gameMode == MenuManager.Mode.cvc)
                cvc_play_round();
            else if (MenuManager.refrence.gameMode == MenuManager.Mode.log)
                log_play_round();
            else if (MenuManager.refrence.gameMode == MenuManager.Mode.pvp)
                cycle_no++;
        }
    }

    public void takeout_inside_goal_players()
    {

    }

    public void log_play_round()
    {
        cycle_no++;
        //log pervious cycle:
        if (cycle_no != 1)
        {
            string my_players = "";
            string opp_players = "";
            if(turn==Turn.team2)
            {
                foreach (GameObject player in playersTeam1)
                    my_players += string.Format("{0}:{1},", player.transform.position.x, player.transform.position.y);
                foreach(GameObject player in playersTeam2)
                    opp_players += string.Format("{0}:{1},", player.transform.position.x, player.transform.position.y);
            }
            else
            {
                foreach (GameObject player in playersTeam2)
                    my_players += string.Format("{0}:{1},", player.transform.position.x, player.transform.position.y);
                foreach (GameObject player in playersTeam1)
                    opp_players += string.Format("{0}:{1},", player.transform.position.x, player.transform.position.y);

            }
            test_sw.WriteLine(my_players.Substring(0, my_players.Length - 1));
            test_sw.WriteLine(opp_players.Substring(0, opp_players.Length - 1));
            test_sw.WriteLine("{0}:{1}", ball.transform.position.x, ball.transform.position.y);
            test_sw.WriteLine("{0}-{1}", team1Score, team2Score);
        }




        test_sw.WriteLine("______________________________________________________________________________");
        test_sw.WriteLine(cycle_no);

        game_log_sr.ReadLine(); //avoid line
        game_log_sr.ReadLine(); //avoid cycle no
        string[] str_shoot = game_log_sr.ReadLine().Split(','); //id,degree,power

        int t_id;
        float t_angle, t_power;
        t_id = int.Parse(str_shoot[0]);
        t_angle = float.Parse(str_shoot[1]);
        t_power = float.Parse(str_shoot[2]);
        Shoot(t_id, t_angle, t_power);
        test_sw.WriteLine("{0},{1},{2}", t_id, t_angle, t_power);
        test_sw.Flush();

        game_log_sr.ReadLine(); //avoid team1 poses
        game_log_sr.ReadLine(); //avoid team2 poses
        game_log_sr.ReadLine(); //avoid ball pos
        game_log_sr.ReadLine(); //avoid score
        
    }

    public void send_data_to_client(StreamWriter sw, GameObject[] myTeam, GameObject[] oppTeam, int my_score, int opp_score, bool mirror_positions)
    {
        string self_poses = "", opp_poses = "", text = "";
        for (int i = 0; i < 5; i++)
        {
            if (!mirror_positions)
                self_poses += string.Format("{0}:{1}", myTeam[i].transform.position.x, myTeam[i].transform.position.y);
            else
                self_poses += string.Format("{0}:{1}", myTeam[i].transform.position.x * -1, myTeam[i].transform.position.y * -1);

            if (i != 4)
                self_poses += ",";
        }
        for (int i = 0; i < 5; i++)
        {
            if (!mirror_positions)
                opp_poses += string.Format("{0}:{1}", oppTeam[i].transform.position.x, oppTeam[i].transform.position.y);
            else
                opp_poses += string.Format("{0}:{1}", oppTeam[i].transform.position.x * -1, oppTeam[i].transform.position.y * -1);

            if (i != 4)
                opp_poses += ",";
        }

        text = string.Format("{0}\n{1}\n{2}:{3}\n{4},{5},{6}",
            self_poses, opp_poses,
            ((!mirror_positions) ? ball.transform.position.x : ball.transform.position.x * -1),
            ((!mirror_positions) ? ball.transform.position.y : ball.transform.position.y * -1),
            my_score, opp_score, cycle_no);

        sw.WriteLine(text);
        sw.Flush();

        //log the server to client communication:
        com_log_server_to_client(text);
    }

    public void com_log_server_to_client(string text)
    {
        com_log_sw.WriteLine();

        if (turn==Turn.team1)
            com_log_sw.WriteLine("S -> C1 :");
        else
            com_log_sw.WriteLine("S -> C2 :");


        com_log_sw.WriteLine(text.Replace("\n", Environment.NewLine));
        com_log_sw.WriteLine();
        com_log_sw.Flush();
    }

    public void receive_data_from_client(StreamReader sr, out int r_id, out float r_angle, out float r_power)
    {
        string[] responce = sr.ReadLine().Trim().Split(',');
        com_log_client_to_server(responce);

        r_id = int.Parse(responce[0]);
        r_angle = float.Parse(responce[1]);
        r_power = float.Parse(responce[2]);

        if (r_angle < 0)
            r_angle += 360;

        if ( (gameHalf==GameHalf.firstHalf && turn == Turn.team2) || (gameHalf == GameHalf.secHalf && turn == Turn.team1))
            r_angle = (r_angle + 180) % 360;

        r_angle %= 360;
    }

    public void com_log_client_to_server(string[] responce)
    {
        if(turn==Turn.team1)
            com_log_sw.WriteLine("C1 -> S :");
        else
            com_log_sw.WriteLine("C2 -> S :");

        com_log_sw.WriteLine(string.Format("{0},{1},{2}", responce[0], responce[1], responce[2]));
        com_log_sw.WriteLine("_________________________");
        com_log_sw.Flush();
    }

    public void game_log_cycle_no()
    {
        game_log_sw.WriteLine("______________________________________________________________________________");
        game_log_sw.WriteLine(cycle_no);
        game_log_sw.Flush();
    }
    public void game_log_shoot(int r_id, float r_angle, float r_power)
    {
        game_log_sw.WriteLine("{0},{1},{2}", r_id, r_angle, r_power);
    }
    public void game_log_per_positions_before_shoot()
    {
        for (int i = 0; i < 5; i++) //team1 players positions
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
    public void resetPositions()
    {
        for (int i = 0; i < 10; i++)
        {
            allPlayers[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            allPlayers[i].transform.position = startPos[i];
            allPlayers[i].GetComponent<PlayerController>().deActivePlayer();
        }
        ball.transform.position = ballStartPos;

    }

    public IEnumerator cvc_end_game()
    {
        FinalWistle.Play();
        float counter = 0;
        while (counter < 2f)
        {
            counter += Time.deltaTime;
            yield return null;
        }
        resetPositions();
        team1_sw.WriteLine("END");
        team2_sw.WriteLine("END");
        team1_sw.Flush();
        team2_sw.Flush();
    }

    bool pvp_end_game_done = false;
    public void pvp_end_game()
    {
        if (pvp_end_game_done)
            return;

        FinalWistle.Play();

        resetPositions();
        pvp_end_game_done = true;
    }

    public void cvc_play_round()
    {
        //log the pervious move:
        if (cycle_no != 0)
            game_log_per_positions_before_shoot();

        cycle_no++;

        if(gameHalf!=GameHalf.finish)
            game_log_cycle_no();

        if (gameHalf == GameHalf.firstHalf)
        {
            if (turn == Turn.team1)
                send_data_to_client(team1_sw, playersTeam1, playersTeam2, team1Score, team2Score, false);
            else//team2's turn
                send_data_to_client(team2_sw, playersTeam2, playersTeam1, team2Score, team1Score, true);
        }
        else if (gameHalf == GameHalf.secHalf) 
        {
            if(turn==Turn.team1)
                send_data_to_client(team1_sw, playersTeam1, playersTeam2, team1Score, team2Score, true);
            else //team2's turn
                send_data_to_client(team2_sw, playersTeam2, playersTeam1, team2Score, team1Score, false);
        }
        else //finish!
        {
            StartCoroutine(cvc_end_game());
            return;
            //@TODO go to menu
        }
        //Data has been sent to the client

        int r_id;
        float r_angle, r_power;
        if (turn == Turn.team1)
            receive_data_from_client(team1_sr, out r_id, out r_angle, out r_power);
        else
            receive_data_from_client(team2_sr, out r_id, out r_angle, out r_power);

        Shoot(r_id, r_angle, r_power);

        //log the shoot
        game_log_shoot(r_id, r_angle, r_power);  
    }
    void changeGameHalf()
    {
        gameHalf = GameHalf.secHalf;
        turn = Turn.team2;
        for (int i = 0; i < 10; i++)
        {
            startPos[i] = new Vector3(startPos[i].x * -1, startPos[i].y * -1);
            allPlayers[i].transform.position = startPos[i];
        }
        ball.transform.position = ballStartPos;
        for (int i = 0; i < allPlayers.Length; i++)
            allPlayers[i].GetComponent<PlayerController>().activePlayer();
    }

    public void changeTurn()
    {
        //end of the 1st half condition:
        if(cycle_no== half_game_cycle_no)
        {
            changeGameHalf();
            return;
        }

        //end of the 2nd half condition:
        if (cycle_no == (2 * half_game_cycle_no))
        {
            gameHalf = GameHalf.finish;
            return;
        }

        //else:
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
        if ((index == 1 && gameHalf==GameHalf.firstHalf) || (index == 2 && gameHalf == GameHalf.secHalf))
        {
            team1Score++;
            //yellowTeamScore.text = team1_name + ": "+ team1Score.ToString();
            Team1Name.text = team1_name;
            yellowTeamScore.text = team1Score.ToString();
            turn = Turn.team2;
        }
        else if((index == 2 && gameHalf == GameHalf.firstHalf) || (index==1 && gameHalf==GameHalf.secHalf))
        {
            team2Score++;
            //redTeamScore.text = team2_name + ": " + team2Score.ToString();
            Team2Name.text = team2_name;
            redTeamScore.text = team2Score.ToString();
            turn = Turn.team1;
        }
        
        yield return new WaitForSeconds(3f);

        if (cycle_no == half_game_cycle_no)
        {
            changeGameHalf();
        }
        else if (cycle_no == (2 * half_game_cycle_no))
        {
            gameHalf = GameHalf.finish;
        }

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

        if (MenuManager.refrence.gameMode == MenuManager.Mode.cvc)
            cvc_play_round();
        else if (MenuManager.refrence.gameMode == MenuManager.Mode.log)
            log_play_round();
        else if(MenuManager.refrence.gameMode == MenuManager.Mode.pvp)
        {
            cycle_no++;
        }
    }

    public void Shoot(int ID , float angle , float pwr)
    {
        // shoot player[ID] with pwr power in direction of angle
        if (turn== Turn.team1)
        {
            StartCoroutine(playersTeam1[ID].GetComponent<PlayerController>().Shoot(angle, pwr));
        }
        else if (turn == Turn.team2)
        {
           StartCoroutine( playersTeam2[ID].GetComponent<PlayerController>().Shoot(angle, pwr));
        }
    }

    public void setGameSpeed()
    {
        Time.timeScale = gameSpeedSlider.value;
        int gS = (int)gameSpeedSlider.value;
        gameSpeedText.text ="Game Speed : "+ gS.ToString();
    }


    public bool has_players_collision(GameObject[] team_players)
    {

        for (int i = 0; i < 4; i++)
        {
            Collider2D this_player = team_players[i].GetComponent<Collider2D>();
            for (int j = 0; j < 4; j++)
            {
                if (i == j)
                    continue;
                Collider2D that_player = team_players[j].GetComponent<Collider2D>();

                if (this_player.bounds.Intersects(that_player.bounds))
                    return true;

                //if (this_player.bounds.Intersects(border_down.GetComponent<Collider2D>().bounds) ||
                //    this_player.bounds.Intersects(border_up.GetComponent<Collider2D>().bounds) ||
                //    this_player.bounds.Intersects(border_left.GetComponent<Collider2D>().bounds) ||
                //    this_player.bounds.Intersects(border_right.GetComponent<Collider2D>().bounds))
                //{
                //    print("difal!");
                //    return true;
                //}
            }
        }
        return false;
    }

    public void set_to_default_formation(GameObject[] team_players, int team_no)
    {
        for(int i=0;i<5;i++)
        {
            Vector2 pos;
            if (team_no == 0)
                pos = new Vector2(default_poses[i].x, default_poses[i].y);
            else
                pos = new Vector2(default_poses[i].x * -1, default_poses[i].y * -1);

            team_players[i].transform.position = pos;
            startPos[team_no * 5 + i] = pos;
        }
    }

}