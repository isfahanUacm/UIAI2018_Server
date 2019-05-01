using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalGate1 : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}


    //void OnTriggerStay2D(Collider2D target)
    //{
    //    if (target.transform.tag == "team1" || target.transform.tag == "team2")
    //    {
    //        if (target.transform.GetComponent<Rigidbody2D>().velocity.magnitude == 0)
    //        {
    //            GameObject tmp = target.gameObject;
    //            if (this.tag == "team1Gate")
    //            {
    //                if(GameManager.refrence.players_inside_goal_list.Contains(tmp))
    //                    GameManager.refrence.players_inside_goal_list.Add(tmp);

    //                GameManager.refrence.take_out_inside_goal_player(target.transform.GetComponent<PlayerController>(), 1);
    //            }
    //            else if (this.tag == "team2Gate")
    //            {
    //                if (GameManager.refrence.players_inside_goal_list.Contains(tmp))
    //                    GameManager.refrence.players_inside_goal_list.Add(tmp);

    //                GameManager.refrence.take_out_inside_goal_player(target.transform.GetComponent<PlayerController>(), 2);
    //            }
    //        }
    //    }

    //}

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.transform.tag == "team1" || target.transform.tag == "team2")
        {
            GameObject tmp = target.gameObject;
            if (this.tag == "team1Gate")
            {
                if (!GameManager.refrence.players_inside_goal1_list.Contains(tmp))
                    GameManager.refrence.players_inside_goal1_list.Add(tmp);
            }
            else if (this.tag == "team2Gate")
            {
                if (!GameManager.refrence.players_inside_goal2_list.Contains(tmp))
                    GameManager.refrence.players_inside_goal2_list.Add(tmp);
            }
        }
    }

    void OnTriggerExit2D(Collider2D target)
    {
        if (target.transform.tag == "team1" || target.transform.tag == "team2")
        {
            GameObject tmp = target.gameObject;
            if (this.tag == "team1Gate")
            {
                if (GameManager.refrence.players_inside_goal1_list.Contains(tmp))
                    GameManager.refrence.players_inside_goal1_list.Remove(tmp);
            }
            else if (this.tag == "team2Gate")
            {
                if (GameManager.refrence.players_inside_goal2_list.Contains(tmp))
                    GameManager.refrence.players_inside_goal2_list.Remove(tmp);
            }
        }
    }
}
