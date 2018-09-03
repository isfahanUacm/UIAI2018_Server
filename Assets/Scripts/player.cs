using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public float angle;
    public float force;
    public float friction;
    public float mass;
    public float a;
    public float speed;
    public bool move;
    float t = 0;
    public LineRenderer line;

    private Vector2 EndRot = new Vector2(0f, 0f);
    float rot_z;
    Camera c;
    public bool canRotate;

    void Start()
    {
        c = Camera.main;
        canRotate = true;
        //force = 0;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (canRotate)
            {
                if (GameManager.refrence.turn == GameManager.Turn.team1)
                {
                    if (transform.tag == "player1")
                    {
                        EndRot.x = (c.ScreenToWorldPoint(Input.mousePosition)).x - transform.position.x;
                        EndRot.y = (c.ScreenToWorldPoint(Input.mousePosition)).y - transform.position.y;
                        rot_z = Mathf.Atan2(EndRot.x, EndRot.y) * Mathf.Rad2Deg;
                        float angle2;

                        angle2 = transform.localEulerAngles.z + 90;
                        if (angle2 > 360)
                        {
                            angle2 = angle2 - 360;
                        }
                        angle = angle2;
                        //print(angle2) ;
                        transform.eulerAngles = new Vector3(0f, 0f, 180 - rot_z);
                        float distance = Vector2.Distance(transform.position, c.ScreenToWorldPoint(Input.mousePosition));
                        
                        force = (250 * distance) / 1.5f;
                        if (distance > 1.5f)
                        {
                            force = 250;
                        }
                        line.gameObject.SetActive(true);
                        //line.gameObject.transform.position = transform.position;
                        line.SetPosition(0, this.transform.position);
                        Vector2 touchPos = new Vector2(c.ScreenToWorldPoint(Input.mousePosition).x, c.ScreenToWorldPoint(Input.mousePosition).y);
                        if (distance < 1.5f) 
                        line.SetPosition(1, touchPos);
                        //print(force);
                    }
                }
            }
        }
        shoot();
    }

    public void ChangeDirectio()
    {
        line.gameObject.SetActive(false);
        if (angle >= 0 && angle <= 360)
        {
            if (this.transform.tag == "player1")
            {
                //angle = angle - 90;                   
                this.transform.localEulerAngles = new Vector3(0, 0, angle - 90);
            }
            else if (this.transform.tag == "player2")
            {
                //angle = angle + 90;
                this.transform.localEulerAngles = new Vector3(0, 0, angle + 90);

            }
            if (!move)
            {
                move = true;
                //force = 300;
            }

        }
    }


    void shoot()
    {
        if (move)
        {
            canRotate = false;
            //move = false;
            float f = force + friction;
            force = 0;
            a = f / mass;
            //print(Time.fixedDeltaTime);
            speed += (a * Time.fixedDeltaTime);
            t += Time.fixedDeltaTime;
            if (speed >= 0)
            {
                //transform.position = new Vector3(X, Y, 0);
                transform.Translate(Vector3.up * speed * Time.fixedDeltaTime);
            }
            else
            {
                move = false;
                //force = 80;
                t = 0;
                canRotate = true;
                /*if (this.transform.tag == "player2")
                {
                    GameManager.refrence.turn = GameManager.Turn.player1;
                }
                else if (this.transform.tag == "player1")
                {
                    GameManager.refrence.turn = GameManager.Turn.player2;
                }*/
            }
        }
    }

    void shooot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * force, ForceMode2D.Force);
        }
    }


    void OnTriggerEnter2D(Collider2D target)
    {
        if( target.gameObject.tag == "player2")
        {
            print("barkhord");
            float ff = mass * a;
            print(ff);
            target.gameObject.GetComponent<player>().force = 50;
            target.gameObject.GetComponent<player>().move = true;
        }
    }
}
