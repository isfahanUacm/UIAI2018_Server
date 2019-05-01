using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public static MenuManager refrence;

    public enum Mode { pvp, pvc, cvc , log}; // player vs player or player vs code or code vs code
    public Mode gameMode;

    public AudioSource intro_audio, menu_audio;
    public Text txt_panel;
    public GameObject btnPanel;
    public GameObject playBtn;
    bool stop_audio = false;
    public int version;
    bool canClick = false; //@TODO false;

    bool isFirstTime;
    public Animator logoAnim;
    public GameObject pnl_msg_update;
    public Text msg_update;
    public string game_log_address_cmd = "";
    public string game_com_address_cmd = "";
    public string team1_name_cmd = "";
    public string team2_name_cmd = "";
    public int time_scale_cmd = 1;
    public enum cmdGameMode { pvp, pvc, cvc, log, _null};
    public cmdGameMode cmd_game_mode;
    public Stream log_stream;
    public StreamReader webserver_log_reader;

    public bool download_log_done;
    public IEnumerator read_log_address_from_url()
    {
        string game_id, token;

        int pm = Application.absoluteURL.IndexOf("?");
        if (pm != -1)
        {
            string str = Application.absoluteURL.Split('?')[1];

            string[] ss = str.Split('&');
            game_id = ss[0].Split('=')[1];
            token = ss[1].Split('=')[1];

            print("game_id: " + game_id + "token: " + token);

            //reqing
            WWW www = new WWW(string.Format("http://acm.ui.ac.ir/uiai2018/games/log/?game_id={0}&token={1}", game_id, token));
            yield return www;

            string tmp = www.text;
            log_stream = new MemoryStream();
            StreamWriter sw = new StreamWriter(log_stream);
            webserver_log_reader = new StreamReader(sw.BaseStream);
            foreach (string s in tmp.Split('\n'))
            {
                sw.WriteLine(s);
            }
            sw.Flush();
            log_stream.Position = 0;

            download_log_done = true;
            goToLog();

        }
    }

    public void handle_cmd_args(string[] str)
    {
        cmd_game_mode = cmdGameMode._null;
        for (int i = 1; i < str.Length; i++)
        {
            Debug.Log(str[i]);
            string[] ss = str[i].Split('=');
            switch (ss[0])
            {
                case "--mode":
                    switch (ss[1])
                    {
                        case "pvp":
                            cmd_game_mode = cmdGameMode.pvp;
                            break;
                        case "pvc":
                            cmd_game_mode = cmdGameMode.pvc;
                            break;
                        case "cvc":
                            cmd_game_mode = cmdGameMode.cvc;
                            break;
                        case "log":
                            cmd_game_mode = cmdGameMode.log;
                            break;
                        default:
                            return;
                    }
                    break;

                case "--team1name":
                    team1_name_cmd = ss[1];
                    break;

                case "--team2name":
                    team2_name_cmd = ss[1];
                    break;

                case "--logfile":
                    game_log_address_cmd = ss[1];
                    //@BUG space in address

                    break;
                case "--speed":
                    time_scale_cmd = int.Parse(ss[1]);
                    break;

                case "--comfile":
                    game_com_address_cmd = ss[1];
                    break;
            }
        }

        switch(cmd_game_mode)
        {
            case cmdGameMode.cvc:
                goToGameCVC();
                break;

            case cmdGameMode.pvc:
                goToGamePVC();
                break;

            case cmdGameMode.pvp:
                goToGamePVP();
                break;

            case cmdGameMode.log:
                goToLog();
                break;
        }

    }

    void Awake()
    {
        version = 3;
        webserver_log_reader = null;

        download_log_done = false;
        //StartCoroutine(read_log_address_from_url());  //url!

        handle_cmd_args(System.Environment.GetCommandLineArgs()); //cmd

        //StartCoroutine(get_version());

        if (PlayerPrefs.GetInt("firstTime") == 0)
        {
            isFirstTime = true;
            PlayerPrefs.SetInt("firstTime", 1);

        }
        else
        {
            isFirstTime = false;
            btnPanel.SetActive(true);
            playBtn.SetActive(false);
        }
        if(refrence == null)
        {
            refrence = this;
        }
        if (isFirstTime)
        {
            isFirstTime = false;
            logoAnim.SetTrigger("playAnim");
            intro_audio.Play();
        }
    }

    IEnumerator get_version()
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://acm.ui.ac.ir/uiai2018/api/get_version/?name=server");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string res = reader.ReadToEnd();
            //{ "version":"1"}
            res = res.Substring(res.IndexOf(':'));
            res = res.Split('"')[1];
            int server_version = int.Parse(res);

            if (server_version > version)
            {
                //EditorUtility.DisplayDialog("Update", string.Format("Newer UIAI2018 Server version {0} available.\nCheckout acm.ui.ac.ir/uiai2018/blog", server_version), "OK");
                pnl_msg_update.SetActive(true);
                msg_update.text = string.Format("Newer UIAI2018 Server version {0} available.\nCheckout acm.ui.ac.ir/uiai2018/blog", server_version);
            }
        }
        catch
        {

        }
        yield return null;
    }


    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);
        StartCoroutine(waitForAnim());
    }
	
	// Update is called once per frame
	void Update () {
        if (!stop_audio)
            if (!intro_audio.isPlaying && !menu_audio.isPlaying)
            {
                menu_audio.loop = true;
                menu_audio.Play();
            }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}

    public void goToGamePVP()
    {
        gameMode = Mode.pvp;
        openGamePlayScene();
    }

    public void goToGamePVC()
    {
        gameMode = Mode.pvc;
        openGamePlayScene();
    }

    public void goToGameCVC()
    {
        gameMode = Mode.cvc;
        openGamePlayScene();
    }

    public void goToLog()
    {
        gameMode = Mode.log;
        openGamePlayScene();
    }

    public void openGamePlayScene()
    {
        stop_audio = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void openBtnPanel()
    {
        if (canClick)
        {
            playBtn.SetActive(false);
            btnPanel.SetActive(true);
        }
    }

    IEnumerator waitForAnim()
    {
        yield return new WaitForSeconds(7f);
        canClick = true;
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("firstTime", 0);
    }


}
