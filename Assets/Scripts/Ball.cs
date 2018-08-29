using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    // Use this for initialization
    Vector3 startPos;
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D target)
    {
        if (!GameManager.refrence.goalHappen)
        {
            if (target.transform.tag == "team1Gate")
            {
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                transform.position = startPos;
                GameManager.refrence.goalHappen = true;
                //GameManager.refrence.team2Score++;
                GameManager.refrence.Goal(2);

            }
            else if (target.transform.tag == "team2Gate")
            {
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                transform.position = startPos;
                GameManager.refrence.goalHappen = true;
                //GameManager.refrence.team1Score++;
                GameManager.refrence.Goal(1);
            }
        }
    }
}
