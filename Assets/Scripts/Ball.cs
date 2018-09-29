using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    // Use this for initialization
    Vector3 startPos;
    Rigidbody2D ballBody;
    public AudioClip[] ballSounds;
    public AudioSource ballSfx;

    void Start () {
        startPos = transform.position;
        ballBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(ballBody.velocity.magnitude < .2f)
        {
            ballBody.velocity = Vector2.zero;
        }
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
                return;

            }
            if (target.transform.tag == "team2Gate")
            {
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                transform.position = startPos;
                GameManager.refrence.goalHappen = true;
                //GameManager.refrence.team1Score++;
                GameManager.refrence.Goal(1);
                return;
            }
            if(target.transform.tag == "wall")
            {
                ballSfx.clip = ballSounds[2];
                ballSfx.volume = 0.3f;
                ballSfx.Play();
            }
            if (target.transform.tag == "Gate")
            {
                ballSfx.clip = ballSounds[2];
                ballSfx.volume = 0.5f;
                ballSfx.Play();
            }
            if (target.transform.tag == "team1" || target.transform.tag == "team2")
            {
                ballSfx.clip = ballSounds[0];
                ballSfx.volume = 0.7f;
                ballSfx.Play();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (!GameManager.refrence.goalHappen)
        {
            if (target.transform.tag == "team1Gate")
            {
                //GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                //transform.position = startPos;
                GameManager.refrence.goalHappen = true;
                //GameManager.refrence.team2Score++;
                StartCoroutine( GameManager.refrence.Goal(2));

            }
            else if (target.transform.tag == "team2Gate")
            {
                //GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                //transform.position = startPos;
                GameManager.refrence.goalHappen = true;
                //GameManager.refrence.team1Score++;
                StartCoroutine( GameManager.refrence.Goal(1));
            }
        }
    }
}
