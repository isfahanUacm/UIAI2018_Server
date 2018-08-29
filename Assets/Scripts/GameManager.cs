using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

    public static GameManager refrence;

    public enum Turn { player1, player2 };
    public Turn turn;
    public GameObject[] allPlayers;
    public GameObject[] playersTeam1;
    public GameObject[] playersTeam2;
    public int index;

    public Vector3[] startPos;

    public int team1Score;
    public int team2Score;
    public Text yellowTeamScore;
    public Text redTeamScore;
    public bool goalHappen = false;

    void Awake()
    {
        if(refrence == null)
        {
            refrence = this;
        }
        startPos = new Vector3[10];
        for (int i = 0; i < 10; i++)
        {
            startPos[i] = allPlayers[i].transform.position;
        }
        team1Score = team2Score = 0;
    }

    void Start () {
        turn = Turn.player1;
    }
	
	
	void Update () {
        
        
    }


    public void Goal(int index)
    {
        if(index == 1)
        {
            team1Score++;
            yellowTeamScore.text ="yellow : "+ team1Score.ToString();
        }else if(index == 2)
        {
            team2Score++;
            redTeamScore.text = "red : " + team2Score.ToString();
        }
        for (int i = 0; i < 10; i++)
        {
            allPlayers[i].GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            allPlayers[i].transform.position = startPos[i];
        }
        goalHappen = false;
    }

}
