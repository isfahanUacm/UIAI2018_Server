using System;
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
	void FixedUpdate() {

	}

    void OnCollisionEnter2D(Collision2D target)
    {
        if (!GameManager.refrence.goalHappen)
        {
            if (target.transform.tag == "team1Gate")
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                transform.position = startPos;
                GameManager.refrence.goalHappen = true;
                GameManager.refrence.Goal(2);
                return;

            }
            if (target.transform.tag == "team2Gate")
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                transform.position = startPos;
                GameManager.refrence.goalHappen = true;
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
        if (target.transform.tag == "team1Net" || target.transform.tag == "team2Net")
        {
            Vector2 current_speed = this.GetComponent<Rigidbody2D>().velocity;
            float x = current_speed.x, y = current_speed.y;
            float len = Mathf.Sqrt(x * x + y * y);

            this.GetComponent<Rigidbody2D>().velocity = new Vector2(x/len, y/len);
        }
        if (!GameManager.refrence.goalHappen)
        {

            if (target.transform.tag == "team1Gate")
            {
                GameManager.refrence.goalHappen = true;
                StartCoroutine( GameManager.refrence.Goal(2));
            }
            else if (target.transform.tag == "team2Gate")
            {
                GameManager.refrence.goalHappen = true;
                StartCoroutine( GameManager.refrence.Goal(1));
            }
            
        }
    }

    void OnCollisionStay2D(Collision2D target)
    {
        if (target.transform.tag == "wall") //Wall bug!
        {
            if(GetComponent<Rigidbody2D>().velocity.magnitude == 0)
            {
                if(transform.position.y > 0)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y - .1f);
                }
                else
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + .1f);
                }
            }
        }
    }
}
