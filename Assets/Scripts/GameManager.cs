using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.IO.Compression;
using UnityEngine.SceneManagement;
//using UnityEditor;
using System.Net;

public class GameManager : MonoBehaviour {

    public static GameManager refrence;

    public enum Turn { team1, team2 };
    public Turn turn;
    public enum GameState { moving, frozen, goalHappend };
    public GameState gameState;
    public enum GameHalf { firstHalf, secHalf, finish };
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
    public Text txt_gameHalf;
    public bool goalHappen = false;
    public Animator goalAnim;

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

    

    public static TcpClient team1_sock = null, team2_sock = null;
    public static StreamReader team1_sr, team2_sr;
    public static StreamWriter team1_sw, team2_sw;
    public string team1_name = "df_team1", team2_name = "df_team2";
    public int cycle_no;
    public static StreamWriter game_log_sw, com_log_sw; //StreamWriters of game.log & game.com
    public static StreamReader game_log_sr; //StreamReader for reading game.log and show it (in log repley mode)
    //public static StreamWriter test_sw; //for testing the log mode
    const int half_game_cycle_no = 100; //number of cycles in a half
    Vector2[] default_poses = { new Vector2(-6.5f, 0), new Vector2(-2, 1), new Vector2(-5, -2), new Vector2(-5, 2), new Vector2(-2, -1) };
    double player_radius;
    public GameObject border_left, border_right, border_up, border_down;
    //cvc connection panel:
    public Toggle team1Toggle;
    public Text team1ToggleText;
    public Toggle team2Toggle;
    public Text team2ToggleText;
    public Text CountDownText;
    public GameObject CountDown;
    public GameObject connectionPanel;
    //pvc connection panel:
    public GameObject pvc_connectionPanel;
    public Toggle pvc_toggle;
    public Text pvc_toggleText;
    public Text pvc_countDown;
    public string game_log_address;
    public string game_com_address;
    public GameObject error_panel;
    public Text error_text;
    public GameObject goal1_gate;
    public GameObject goal2_gate;
    public bool check_players_inside_goal;
    public Vector2[] per_allPlayers; //pervious cycle players positions
    public Vector2[] per_ball; //pervious cycle ball position
    public int per_team1Score, per_team2Score;
    //public List<GameObject> players_inside_goal_list;
    public List<GameObject> players_inside_goal1_list, players_inside_goal2_list;
    public int shoot_id;
    public int shoot_angle, shoot_power;
    void Awake()
    {
        if (MenuManager.refrence.game_log_address_cmd == "")
            game_log_address = "Game.log";
        else
            game_log_address = MenuManager.refrence.game_log_address_cmd; //read from cmd argument

        if (MenuManager.refrence.game_com_address_cmd == "")
            game_com_address = "Game.com";
        else
            game_com_address = MenuManager.refrence.game_com_address_cmd; //read from cmd argument

        team1_name = "Yellow";
        team2_name = "Purple";

        Time.timeScale = MenuManager.refrence.time_scale_cmd;
        gameSpeedText.text = "Game Speed : " + Time.timeScale.ToString();

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
        team_no = 0;
        team1_connected = false;
        team2_connected = false;
        pvp_end_game_done = false;
        cvc_end_game_done = false;
        log_end_game_done = false;
        pvc_end_game_done = false;
        check_players_inside_goal = false;
        //players_inside_goal_list = new List<GameObject>();
        players_inside_goal1_list = new List<GameObject>();
        players_inside_goal2_list = new List<GameObject>();

        player_radius = playersTeam1[0].GetComponent<PlayerController>().GetComponent<CircleCollider2D>().radius;
        gameHalf = GameHalf.firstHalf;
        cycle_no = 0;
        txt_cycleNo.text = "Cycle Number : " + "0";
        turn = Turn.team1;
        shouldCheckState = false;
        for (int i = 0; i < allPlayers.Length; i++)
        {
            allPlayers[i].GetComponent<PlayerController>().activePlayer();
        }
        crowed.Play();

        if (MenuManager.refrence.gameMode == MenuManager.Mode.cvc)
        {
            //create template folder for screen shot pics.
            if (Directory.Exists("ScreenShots"))
                Directory.Delete("ScreenShots", true); //remove pervious folder!

            Directory.CreateDirectory("ScreenShots");

            //use this StreamWriter to create the game's log file
            try
            {
                game_log_sw = new StreamWriter(game_log_address, false);
            }
            catch (Exception ex)
            {
                error_panel.SetActive(true);
                error_text.text += ex.Message;
                return;
            }
            //use this StreamWriter to create game.com file
            com_log_sw = new StreamWriter(game_com_address, false);

            StartCoroutine(cvc_start_server(9595));

        }

        else if (MenuManager.refrence.gameMode == MenuManager.Mode.log)
        {
            //string path = EditorUtility.OpenFilePanel("Select game file!", "", "log");

            if (MenuManager.refrence.webserver_log_reader != null)
            {
                //print("daram ez too web mikhoonam!");
                game_log_sr = MenuManager.refrence.webserver_log_reader;
            }
            else
            {

                //initial this StreamReader for reading game.log
                try
                {
                    game_log_sr = new StreamReader(game_log_address);
                }
                catch (Exception ex)
                {
                    error_panel.SetActive(true);
                    error_text.text += ex.Message;
                    return;
                }
                //game_log_sr = new StreamReader(path);
                //test_sw = new StreamWriter("test.log");
            }

            team_init_log(out team1_name, playersTeam1, true);
            team_init_log(out team2_name, playersTeam2, false);
            log_play_round();
        }
        else if (MenuManager.refrence.gameMode == MenuManager.Mode.pvp)
        {
            cycle_no = 1;
            for(int i=0;i<10;i++)
            {
                startPos[i] = new Vector3(allPlayers[i].GetComponent<PlayerController>().transform.position.x, allPlayers[i].GetComponent<PlayerController>().transform.position.y);
            }
        }
        else if (MenuManager.refrence.gameMode == MenuManager.Mode.pvc)
        {
            //create template folder for screen shot pics.
            if (Directory.Exists("ScreenShots"))
                Directory.Delete("ScreenShots", true); //remove pervious folder!

            Directory.CreateDirectory("ScreenShots");

            try
            {
                //use this StreamWriter to create the game's log file
                game_log_sw = new StreamWriter(game_log_address, false);
                //use this StreamWriter to create game.com file
                com_log_sw = new StreamWriter(game_com_address, false);
            }
            catch (Exception ex)
            {
                error_panel.SetActive(true);
                error_text.text += ex.Message;
                return;
            }
            StartCoroutine(pvc_start_server(9595));

        }


        yellowTeamScore.text = "0";
        redTeamScore.text = " 0";
        Team1Name.text = team1_name;
        Team2Name.text = team2_name;

        goalAnim.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        checkGameState();
    }

    private static int team_no = 0;

    public void team_init_log(out string team_name, GameObject[] team_players, bool first_team)
    {
        team_name = game_log_sr.ReadLine();
        

        int i = 0;
        foreach (string str_player in game_log_sr.ReadLine().Split(','))
        {
            string[] str_player_parts = str_player.Split(':');
            team_players[i].GetComponent<PlayerController>().name = str_player_parts[0];
            team_players[i].GetComponent<PlayerController>().Name.text = str_player_parts[0];


            Vector3 pos = new Vector3(float.Parse(str_player_parts[1]), float.Parse(str_player_parts[2]));

            team_players[i].transform.position = pos;

            if (first_team)
                startPos[i] = pos;
            else
                startPos[5 + i] = pos;

            i++;
        }

        //test_sw.WriteLine(team_name);
        //foreach (GameObject player in team_players)
        //    test_sw.Write("{0}:{1}:{2},", player.GetComponent<PlayerController>().Name.text.Substring(3), player.transform.position.x, player.transform.position.y);
        //test_sw.WriteLine();

    }

    public void Team_init_cvc(StreamReader team_sr, out string team_name, GameObject[] team_players)
    {
        //@TODO try catch
        if (team_no == 0)
        {
            com_log_sw.WriteLine("C1 -> S :");
        }
        else
        {
            com_log_sw.WriteLine();
            com_log_sw.WriteLine("C2 -> S:");
        }
        com_log_sw.Flush();

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
        if (team_no == 0)
        {
            if (MenuManager.refrence.team1_name_cmd == "")
                team_name = tmp.Substring(9);
            else
                team_name = MenuManager.refrence.team1_name_cmd;
        }
        else
        {
            if (MenuManager.refrence.team2_name_cmd == "")
                team_name = tmp.Substring(9);
            else
                team_name = MenuManager.refrence.team2_name_cmd;
        }



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
            team_players[i].GetComponent<PlayerController>().name = ss[0];
            team_players[i].GetComponent<PlayerController>().Name.text = ss[0];


            if ((float.Parse(ss[1]) + player_radius) > 0) //oboor az vasat zamin
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
            startPos[team_no * 5 + i] = pos;

            i++;
        }

        if (has_players_collision(team_players) || !correct_side)
        {
            print("Players collision! We will set your formation, ourselves!");
            set_to_default_formation(team_players, team_no);
        }


        string text = "";
        for (int j = 0; j < 5; j++)
        {
            text += team_players[j].GetComponent<PlayerController>().Name.text + ":" + startPos[team_no * 5 + j].x + ":" + startPos[team_no * 5 + j].y;
            if (j != 4)
                text += ",";
        }
        game_log_sw.WriteLine(text); //log team players
        game_log_sw.Flush();
        com_log_sw.Flush();
        team_no = 1;
    }

    IEnumerator team1_connect(TcpListener serversocket)
    {
        team1_sock = serversocket.AcceptTcpClient(); //wait here for the 1st client
        team1_sock.ReceiveTimeout = 1000;

        team1ToggleText.text = "team1 connected";
        team1Toggle.isOn = true;
        team1_connected = true;
        yield return null;
    }

    IEnumerator team2_connect(TcpListener serversocket)
    {
        team2_sock = serversocket.AcceptTcpClient(); ////wait here for the 2nd client
        team2_sock.ReceiveTimeout = 1000;

        team2Toggle.isOn = true;
        team2ToggleText.text = "team2 connected";
        team2_connected = true;
        yield return null;
    }

    bool team1_connected = false, team2_connected = false;
    IEnumerator cvc_start_server(int port)
    {

        team1_sock = null;
        team2_sock = null;

        team1_connected = false;
        team2_connected = false;

        connectionPanel.SetActive(true);
        yield return null;

        TcpListener serversocket = new TcpListener(port);


        serversocket.Start();

        StartCoroutine(team1_connect(serversocket));
        while (!team1_connected)
            yield return null;

        team1Toggle.isOn = true;
        yield return null;


        team1_sr = new StreamReader(team1_sock.GetStream());
        team1_sw = new StreamWriter(team1_sock.GetStream());
        team1_sr.BaseStream.ReadTimeout = 1000;
        Team_init_cvc(team1_sr, out team1_name, playersTeam1);

        StartCoroutine(team2_connect(serversocket));
        while (!team2_connected)
            yield return null;

        team2Toggle.isOn = true;

        CountDown.SetActive(true);
        yield return new WaitForSeconds(1f);
        CountDownText.text = "2";
        yield return new WaitForSeconds(1f);
        CountDownText.text = "1";
        yield return new WaitForSeconds(1f);

        connectionPanel.SetActive(false);
        serversocket.Stop();


        team2_sr = new StreamReader(team2_sock.GetStream());
        team2_sw = new StreamWriter(team2_sock.GetStream());
        team2_sr.BaseStream.ReadTimeout = 1000;
        Team_init_cvc(team2_sr, out team2_name, playersTeam2);

        cvc_play_round();

        Team1Name.text = team1_name;
        Team2Name.text = team2_name;

    }

    IEnumerator pvc_start_server(int port)
    {
        team1_sock = null;
        team1_connected = false;

        pvc_connectionPanel.SetActive(true);
        yield return null;

        TcpListener serversocket = new TcpListener(port);
        serversocket.Start();
        team1_sock = serversocket.AcceptTcpClient(); //wait here for the 1st client

        serversocket.Stop();

        pvc_toggle.isOn = true;
        pvc_toggleText.text = "Team1 Connected";

        //pvc_countDown.SetActive(true);
        float counter = 3;
        pvc_countDown.text = "3";
        yield return new WaitForSeconds(1f);
        pvc_countDown.text = "2";
        yield return new WaitForSeconds(1f);
        pvc_countDown.text = "1";
        yield return new WaitForSeconds(1f);

        pvc_connectionPanel.SetActive(false);

        team1_sr = new StreamReader(team1_sock.GetStream());
        team1_sw = new StreamWriter(team1_sock.GetStream());

        Team_init_cvc(team1_sr, out team1_name, playersTeam1);
        Team1Name.text = team1_name;

        pvc_log_player_team_init(); //game.log init team2(player)!

        pvc_play_round();
    }

    public void pvc_log_player_team_init()
    {
        game_log_sw.WriteLine(team2_name);
        string text = "";
        for (int j = 0; j < 5; j++)
        {
            text += playersTeam2[j].GetComponent<PlayerController>().Name.text + ":" + startPos[5+j].x + ":" + startPos[5+j].y;
            if (j != 4)
                text += ",";
        }
        game_log_sw.WriteLine(text); //log team players
    }

    public void checkGameState()
    {
        if (gameHalf == GameHalf.finish)
        {
            txt_gameHalf.text = "Finished";
            if (MenuManager.refrence.gameMode == MenuManager.Mode.pvp)
            {
                pvp_end_game();
            }
        }
        if (gameHalf != GameHalf.finish)
            txt_cycleNo.text = txt_cycleNo.text = "Cycle: " + cycle_no.ToString();
        else
            txt_cycleNo.text = txt_cycleNo.text = "";

        if (gameState == GameState.moving && shouldCheckState)
        {
            for (int i = 0; i < allPlayers.Length; i++)
            {
                if (allPlayers[i].GetComponent<Rigidbody2D>().velocity.magnitude > 0)
                {
                    return;
                }
            }
            if (ball.GetComponent<Rigidbody2D>().velocity.magnitude > 0)
            {
                return;
            }

            foreach (GameObject go in players_inside_goal1_list)
                take_out_inside_goal_player(go.GetComponent<PlayerController>(), 1);

            foreach (GameObject go in players_inside_goal2_list)
                take_out_inside_goal_player(go.GetComponent<PlayerController>(), 2);

            shouldCheckState = false;
            gameState = GameState.frozen;


            changeTurn();

            if (MenuManager.refrence.gameMode == MenuManager.Mode.cvc)
                cvc_play_round();
            else if (MenuManager.refrence.gameMode == MenuManager.Mode.log)
                log_play_round();
            else if (MenuManager.refrence.gameMode == MenuManager.Mode.pvp)
                cycle_no++;
            else if (MenuManager.refrence.gameMode == MenuManager.Mode.pvc)
            {
                //log the pervious move:
                if (cycle_no != 0)
                    game_log_per_positions_before_shoot();

                if (turn == Turn.team1)
                    pvc_play_round();
                else
                {
                    cycle_no++;
                    game_log_cycle_no();
                }
            }
        }
    }

    public double dist(Vector2 pos1, Vector2 pos2)
    {
        return Math.Sqrt((pos1.x - pos2.x) * (pos1.x - pos2.x) + (pos1.y - pos2.y) * (pos1.y - pos2.y));
    }

    public bool validate_pos(Vector2 pos) //check if this pos has no coflict with all players & ball
    {
        for(int i=0;i<10;i++)
        {
            if (dist(pos, allPlayers[i].transform.position) <= 1)
                return false;
        }
        if (dist(pos, ball.transform.position) <= 1)
            return false;

        return true;
    }

    public void take_out_inside_goal_player(PlayerController player_, int gate_no)
    {
        float[] arr = { -3.4f, -2.9f, -2.4f, -1.9f, -1.4f, -0.9f, -0.4f, 0.1f, 0.6f, 1.1f, 1.6f, 2.1f, 2.6f, 3.1f, 3.4f};
        float x;
        if (gate_no == 1)
            x = -6;
        else
            x = 6;
        while(x<8 && x>-8)
        {
            Shuffle(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                if (validate_pos(new Vector2(x, arr[i])))
                {
                    player_.transform.position = new Vector2(x, arr[i]);
                    return;
                }
            }
            if (gate_no == 1)
                x += 0.5f;
            else
                x -= 0.5f;
        }
        print("natoonestam bekesham biroon ///:");
    }

    public void Shuffle(float[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            int rnd = UnityEngine.Random.Range(0, arr.Length);
            float temp = arr[rnd];
            arr[rnd] = arr[i];
            arr[i] = temp;
        }
    }

    string per_cycle_team1_poses, per_cycle_team2_poses, per_cycle_ball_pos, per_cycle_score;

    public void log_play_round()
    {
        cycle_no++;
        //log pervious cycle:
        if (cycle_no != 1) //accurate positions
        {
            List<Vector2> players_pos_in_log = new List<Vector2>();

            foreach (string str_player in per_cycle_team1_poses.Split(','))
            {
                string[] player_pos_tmp = str_player.Split(':');
                Vector2 tmp = new Vector2(float.Parse(player_pos_tmp[0]), float.Parse(player_pos_tmp[1]));
                players_pos_in_log.Add(tmp);
            }

            foreach (string str_player in per_cycle_team2_poses.Split(','))
            {
                string[] player_pos_tmp = str_player.Split(':');
                Vector2 tmp = new Vector2(float.Parse(player_pos_tmp[0]), float.Parse(player_pos_tmp[1]));
                players_pos_in_log.Add(tmp);
            }

            string[] ball_pos_str = per_cycle_ball_pos.Split(':');
            Vector2 ball_in_log = new Vector2(float.Parse(ball_pos_str[0]), float.Parse(ball_pos_str[1]));

            ball.transform.position = ball_in_log; //accurate ball pos
            for (int i = 0; i < players_pos_in_log.Count; i++) //accurate players poses
            {
                allPlayers[i].transform.position = players_pos_in_log[i]; 
            }

            string[] st_scores = per_cycle_score.Split('-');
            yellowTeamScore.text = st_scores[0]; //accurate scores
            redTeamScore.text = st_scores[1];
        }



        string str_tmp = game_log_sr.ReadLine(); //avoid line
        if (str_tmp == "END")
        {
            log_end_game();
            return;
        }
        game_log_sr.ReadLine(); //avoid cycle no

        string str_turn = game_log_sr.ReadLine(); //set turn
        if (str_turn == "team1:")
            turn = Turn.team1;
        else
            turn = Turn.team2;

        string[] str_shoot = game_log_sr.ReadLine().Split(','); //id,degree,power

        shoot_id = int.Parse(str_shoot[0]);
        shoot_angle = (int)double.Parse(str_shoot[1]);
        shoot_power = (int)double.Parse(str_shoot[2]);
        Shoot(shoot_id, shoot_angle, shoot_power);
        //test_sw.WriteLine("{0},{1},{2}", t_id, t_angle, t_power);
        //test_sw.Flush();

        per_cycle_team1_poses = game_log_sr.ReadLine(); //team1 poses
        per_cycle_team2_poses = game_log_sr.ReadLine(); //team2 poses
        per_cycle_ball_pos = game_log_sr.ReadLine(); //ball pos
        per_cycle_score = game_log_sr.ReadLine(); //score

    }

    public void send_data_to_client(StreamWriter sw, GameObject[] myTeam, GameObject[] oppTeam, int my_score, int opp_score, bool mirror_positions)
    {
        com_log_sw.WriteLine("_________________________");
        com_log_sw.Flush();
        //current cycle:
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

        //pervious cycle:


        try
        {
            sw.WriteLine(text);
            sw.Flush();
            //log the server to client communication:
            com_log_server_to_client(text);
        }
        catch(Exception exp)
        {
            com_log_sw.WriteLine("EXCEPTION " + (turn == Turn.team1 ? "team1: " : "team2: ") + exp.ToString());
            com_log_sw.Flush();
        }

    }

    public void com_log_server_to_client(string text)
    {
        com_log_sw.WriteLine();

        if (turn == Turn.team1)
            com_log_sw.WriteLine("S -> C1 :");
        else
            com_log_sw.WriteLine("S -> C2 :");


        com_log_sw.WriteLine(text.Replace("\n", Environment.NewLine));
        com_log_sw.WriteLine();
        com_log_sw.Flush();
    }

    public void receive_data_from_client(StreamReader sr, out int r_id, out int r_angle, out int r_power)
    {
        try
        {
            string tmp = sr.ReadLine();
            com_log_client_to_server(tmp);

            string[] responce = tmp.Trim().Split(',');

            r_id = int.Parse(responce[0]);
            r_angle = (int)double.Parse(responce[1]);
            r_power = (int)double.Parse(responce[2]);

            if (r_angle < 0)
                r_angle += 360;

            if ((gameHalf == GameHalf.firstHalf && turn == Turn.team2) || (gameHalf == GameHalf.secHalf && turn == Turn.team1))
                r_angle = (r_angle + 180) % 360;

            r_angle %= 360;
        }
        catch(Exception exp)
        {
            //print(exp.Message);
            com_log_sw.WriteLine("EXCEPTION " + (turn == Turn.team1 ? "team1: " : "team2: ") + exp.ToString());
            com_log_sw.Flush();
            r_id = r_angle = r_power = 0;
        }
    }

    public void com_log_client_to_server(string responce)
    {
        if (turn == Turn.team1)
            com_log_sw.WriteLine("C1 -> S :");
        else
            com_log_sw.WriteLine("C2 -> S :");

        com_log_sw.WriteLine(responce);
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
        game_log_sw.WriteLine((turn == Turn.team1 ? "team1:" : "team2:"));
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

    bool cvc_end_game_done = false;
    public void cvc_end_game()
    {
        FinalWistle.Play();
        //end game cvc
        EndAnim();
        txt_cycleNo.text = "";

        resetPositions();

        PlayerController.screenShot("Final");

        try
        {
            team1_sw.WriteLine("END");
            team2_sw.WriteLine("END");

            team1_sw.Flush();
            team2_sw.Flush();

            team1_sock.Close();
            team2_sock.Close();
        }
        catch(Exception exp)
        {
            print(exp.Message);
        }
        

        game_log_sw.WriteLine("END");
        game_log_sw.WriteLine(string.Format("{0} {1}:{2} {3}", team1_name, team1Score, team2Score, team2_name));

        com_log_sw.WriteLine("END");
        com_log_sw.WriteLine(string.Format("{0} {1}:{2} {3}", team1_name, team1Score, team2Score, team2_name));

        game_log_sw.Flush();
        game_log_sw.Close();
        com_log_sw.Flush();
        com_log_sw.Close();

        if (MenuManager.refrence.cmd_game_mode == MenuManager.cmdGameMode.cvc)
            Application.Quit();

        cvc_end_game_done = true;
    }

    bool pvc_end_game_done = false;
    public void pvc_end_game()
    {
        FinalWistle.Play();
        //end pvc game
        EndAnim();
        txt_cycleNo.text = "";

        resetPositions();

        PlayerController.screenShot("Final");

        team1_sw.WriteLine("END");
        team1_sw.Flush();
        team1_sock.Close();

        game_log_sw.WriteLine("END");
        game_log_sw.WriteLine(string.Format("{0} {1}:{2} {3}", team1_name, team1Score, team2Score, team2_name));

        com_log_sw.WriteLine("END");
        com_log_sw.WriteLine(string.Format("{0} {1}:{2} {3}", team1_name, team1Score, team2Score, team2_name));

        game_log_sw.Flush();
        game_log_sw.Close();
        com_log_sw.Flush();
        com_log_sw.Close();
        pvc_end_game_done = true;
    }

    bool pvp_end_game_done = false;
    public void pvp_end_game()
    {
        if (pvp_end_game_done)
            return;

        FinalWistle.Play();
        //end pvp game
        EndAnim();
        resetPositions();
        pvp_end_game_done = true;
    }

    public void EndAnim()
    {
        goalAnim.gameObject.SetActive(true);
        goalAnim.SetTrigger("finish");
    }

    bool log_end_game_done = false;
    public void log_end_game()
    {
        FinalWistle.Play();
        txt_cycleNo.text = "";
        game_log_sr.Close();
        resetPositions();
        log_end_game_done = true;
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

            //first half finish
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
            cvc_end_game();
            return;
        }
        //Data has been sent to the client

        if (turn == Turn.team1)
            receive_data_from_client(team1_sr, out shoot_id, out shoot_angle, out shoot_power);
        else
            receive_data_from_client(team2_sr, out shoot_id, out shoot_angle, out shoot_power);

        Shoot(shoot_id, shoot_angle, shoot_power);

        //log the shoot
        game_log_shoot(shoot_id, shoot_angle, shoot_power);
    }
    public void pvc_play_round()
    {
        cycle_no++;

        if (gameHalf != GameHalf.finish)
            game_log_cycle_no();


        if (gameHalf == GameHalf.firstHalf)
        {
            //first half finish
            if (turn == Turn.team1)
                send_data_to_client(team1_sw, playersTeam1, playersTeam2, team1Score, team2Score, false);
            //else//team2's turn
                //from player
        }
        else if (gameHalf == GameHalf.secHalf)
        {
            if (turn == Turn.team1)
                send_data_to_client(team1_sw, playersTeam1, playersTeam2, team1Score, team2Score, true);
            //else //team2's turn
                //from player
        }
        else //finish!
        {
            pvc_end_game();
            return;
        }
        
        //Data has been sent to the client if it is team1 turns. otherwise player will shoot!
        if (turn == Turn.team1)
        {

            receive_data_from_client(team1_sr, out shoot_id, out shoot_angle, out shoot_power);
            //else
            //from player!

            Shoot(shoot_id, shoot_angle, shoot_power);

            //log the shoot
            game_log_shoot(shoot_id, shoot_angle, shoot_power);
        }
    }

    public void changeGameHalf()
    {
        soot.Play();
        goalAnim.gameObject.SetActive(true);
        goalAnim.SetTrigger("half");
        new WaitForSeconds(1f);

        gameHalf = GameHalf.secHalf;
        txt_gameHalf.text = "2nd half";
        turn = Turn.team2;
        for (int i = 0; i < 10; i++)
        {
            startPos[i] = new Vector3(startPos[i].x * -1, startPos[i].y * -1);
            allPlayers[i].transform.position = startPos[i];
        }
        ball.transform.position = ballStartPos;
        for (int i = 0; i < allPlayers.Length; i++)
            allPlayers[i].GetComponent<PlayerController>().activePlayer();
        soot.Play();
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
        //if (MenuManager.refrence.gameMode != MenuManager.Mode.log) 
        {
            shouldCheckState = false;
            gameState = GameState.goalHappend;
            crowed.Stop();
            GoalCrowed.Play();
            GoalVoice.Play();
            goalAnim.gameObject.SetActive(true);
            goalAnim.SetTrigger("goal");
            if ((index == 1 && gameHalf == GameHalf.firstHalf) || (index == 2 && gameHalf == GameHalf.secHalf))
            {
                team1Score++;
                //yellowTeamScore.text = team1_name + ": "+ team1Score.ToString();
                Team1Name.text = team1_name;
                yellowTeamScore.text = team1Score.ToString();
                turn = Turn.team2;
            }
            else if ((index == 2 && gameHalf == GameHalf.firstHalf) || (index == 1 && gameHalf == GameHalf.secHalf))
            {
                team2Score++;
                //redTeamScore.text = team2_name + ": " + team2Score.ToString();
                Team2Name.text = team2_name;
                redTeamScore.text = team2Score.ToString();
                turn = Turn.team1;
            }

            yield return new WaitForSeconds(3f);
            goalAnim.gameObject.SetActive(false);
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
            else if (MenuManager.refrence.gameMode == MenuManager.Mode.pvp)
            {
                cycle_no++;
            }
            else if(MenuManager.refrence.gameMode == MenuManager.Mode.pvc)
            {
                game_log_per_positions_before_shoot();

                if (turn == Turn.team1)
                    pvc_play_round();
                else
                {
                    cycle_no++;
                    game_log_cycle_no();
                }
            }
        }
    }

    public void Shoot(int ID , float angle , float pwr)
    {
        if (ID < 0)
            ID *= -1;
        ID %= 5;

        if (angle < 0)
            angle *= -1;
        angle %= 360;

        if (pwr < 0)
            pwr *= -1;
        if (pwr > 100)
            pwr = 100;


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

    public void goToMenu()
    {
        if (MenuManager.refrence.gameMode == MenuManager.Mode.cvc)
        {
            if (!cvc_end_game_done)
                cvc_end_game();
        }
        else if (MenuManager.refrence.gameMode == MenuManager.Mode.log)
        {
            if (!log_end_game_done)
                log_end_game();
        }
        else if (MenuManager.refrence.gameMode == MenuManager.Mode.pvp)
        {
            if (!pvp_end_game_done)
                pvp_end_game();
        }
        else if(MenuManager.refrence.gameMode==MenuManager.Mode.pvc)
        {
            if (!pvc_end_game_done)
                pvc_end_game();
        }

        Destroy(GameObject.FindGameObjectWithTag("MenuController"));
        SceneManager.LoadScene(0);
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("firstTime", 0);
    }


}