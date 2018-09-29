using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    void Start() {
        turn = Turn.team1;
        shouldCheckState = false;
        for (int i = 0; i < allPlayers.Length; i++)
        {
            allPlayers[i].GetComponent<PlayerController>().activePlayer();
        }
        //crowed.clip = crowedClips[0];
        crowed.Play();
    }


    void Update() {
        checkGameState();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot(ID, angle, power);
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
        {
            turn = Turn.team2;
        }
        else
        {
            turn = Turn.team1;
        }
        for (int i = 0; i < allPlayers.Length; i++)
        {
            allPlayers[i].GetComponent<PlayerController>().activePlayer();
        }
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
        }else if(index == 2)
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

            playersTeam1[ID-1].GetComponent<PlayerController>().Shoot(angle, pwr);
        }
        else if (turn == Turn.team2)
        {

            playersTeam2[ID-1].GetComponent<PlayerController>().Shoot(angle, pwr);
        }




    }



}
