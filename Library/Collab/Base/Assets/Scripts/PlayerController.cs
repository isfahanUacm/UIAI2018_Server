using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    #region Variables

    public GameObject helperBegin;
    public GameObject helperEnd;

    public float currentDistance;   
    public float maxDis;
    public float minDis;
    float safeDis;

    public float pwr;
    Vector3 shootDirectionVector;

    public GameObject arrowPlane;

    private RaycastHit2D hitInfo;
    private Ray2D ray;

    Vector3 oldVel;

    bool shoot;
    Rigidbody2D playerBody;
    public bool canShoot;

    public int ID;
    public string name;
    public Text Name;

    #endregion Variables

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        canShoot = false;
        Name.text = ID+"_"+ name;
        minDis = .8f;
    }

    void Update()
    {
        checkSpeed();

        if(GameManager.refrence.gameState == GameManager.GameState.frozen)
        {
            if (transform.tag == "team1" && GameManager.refrence.turn == GameManager.Turn.team1) {
                canShoot = true;
            }
            else if(transform.tag == "team2" && GameManager.refrence.turn == GameManager.Turn.team2)
            {
                canShoot = true;
            }else
            {
                canShoot = false;
            }
        }
    }


    #region userController

    void OnMouseDrag()
    {
        if (MenuManager.refrence.gameMode == MenuManager.Mode.pvp || MenuManager.refrence.gameMode == MenuManager.Mode.pvc)
        {
            if (GameManager.refrence.gameState != GameManager.GameState.moving)
            {
                if (canShoot)
                {
                    arrowPlane.SetActive(true);
                    currentDistance = Vector3.Distance(helperBegin.transform.position, transform.position);

                    if (currentDistance <= maxDis)
                    {
                        safeDis = currentDistance;
                    }
                    else
                    {
                        safeDis = maxDis;
                    }

                    pwr = Mathf.Abs(safeDis) * 13;


                    manageArrowTransform();
                    //castRay();
                    //helperEnd

                    Vector3 dxy = helperBegin.transform.position - transform.position;
                    float diff = dxy.magnitude;
                    helperEnd.transform.position = transform.position + ((dxy / diff) * currentDistance * -1);

                    helperEnd.transform.position = new Vector3(helperEnd.transform.position.x, helperEnd.transform.position.y, -0.5f);
                    //helperEnd


                    shootDirectionVector = Vector3.Normalize(helperBegin.transform.position - transform.position);

                    Vector3 targetDir = (-1) * (helperBegin.transform.position - transform.position);
                    float angle = Vector3.Angle(transform.right, targetDir);
                    //print(angle);
                }
            }
        }
    }

    void OnMouseUp()
    {
        if (GameManager.refrence.gameState != GameManager.GameState.moving)
        {
            if (canShoot)
            {
                if (currentDistance > minDis)
                {
                    GameManager.refrence.gameState = GameManager.GameState.moving;
                    shoot = true;
                    for (int i = 0; i < GameManager.refrence.allPlayers.Length; i++)
                    {
                        GameManager.refrence.allPlayers[i].transform.GetChild(0).gameObject.SetActive(false);
                    }
                    arrowPlane.SetActive(false);
                    Vector3 outPower = shootDirectionVector * pwr * -1;

                    print(string.Format("x: {0}, y: {1}, z: {2}", outPower.x, outPower.y, outPower.z));
                    print("power: " + Mathf.Sqrt(outPower.x*outPower.x + outPower.y*outPower.y + outPower.z * outPower.z));
                    GetComponent<Rigidbody2D>().AddForce(outPower, ForceMode2D.Impulse  );
                    //GetComponent<Rigidbody2D>().AddForce(outPower); 

                }
                else
                {
                    arrowPlane.SetActive(false);
                }
                
            }
        }
    }

    #endregion userController


    #region codeController
    public IEnumerator Shoot( float angle, float pwr)
    {
        //manageArrowTransformForCVC(angle);
        // shoot player[ID] with pwr power in direction of angle
        if (MenuManager.refrence.gameMode == MenuManager.Mode.cvc || MenuManager.refrence.gameMode == MenuManager.Mode.pvc || MenuManager.refrence.gameMode == MenuManager.Mode.log)
        {
            if (GameManager.refrence.gameState != GameManager.GameState.moving)
            {
                if (canShoot || MenuManager.refrence.gameMode == MenuManager.Mode.cvc || MenuManager.refrence.gameMode == MenuManager.Mode.log)
                {
                    
                    if (GameManager.refrence.turn == GameManager.Turn.team1)
                    {
          
                        
                        shoot = true;
                        for (int i = 0; i < GameManager.refrence.allPlayers.Length; i++)
                        {
                            GameManager.refrence.allPlayers[i].transform.GetChild(0).gameObject.SetActive(false);
                        }
                        //arrowPlane.SetActive(false);
                        Vector2 direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));
                        if (pwr > 100)
                        {
                            pwr = 100;
                        }
                        Vector3 outPower = direction * (pwr / 5) ;
                        //print(outPower);
                        //arrow AI
                        #region showArrow
                        arrowPlane.gameObject.SetActive(true);
                        arrowPlane.transform.position = transform.position;
                        float outRotation; // between 0 - 360
                        outRotation = angle - 180;
                        arrowPlane.transform.eulerAngles = new Vector3(0, 0, outRotation);
                        
                        float distCount = .5f;
                        if (pwr < 100)
                        {
                            distCount = (pwr * 1.7f) / 100;
                        }
                        else
                        {
                            distCount = 1.7f;
                        }
                        float counter = .5f;
                        while (counter < distCount)
                        {
                            
                            //calculate scale
                            float scaleCoefX = Mathf.Log(2 * counter, 2) * 1f;
                            float scaleCoefY = Mathf.Log(2 * counter, 2) * .7f;                           
                            arrowPlane.transform.localScale = new Vector3(1 + scaleCoefX, 1 + scaleCoefY, 0.001f);
                            counter += Time.deltaTime;                            
                            yield return null;
                        }
                        counter = 0;
                        while (counter < 2f)
                        {
                            counter += Time.deltaTime;
                            yield return null;
                        }
                        arrowPlane.SetActive(false);
                        #endregion showArrow
                        GetComponent<Rigidbody2D>().AddForce(outPower, ForceMode2D.Impulse);
                        GameManager.refrence.gameState = GameManager.GameState.moving;
                    }
                    else if (GameManager.refrence.turn == GameManager.Turn.team2)
                    {
                        
                        
                        shoot = true;
                        for (int i = 0; i < GameManager.refrence.allPlayers.Length; i++)
                        {
                            GameManager.refrence.allPlayers[i].transform.GetChild(0).gameObject.SetActive(false);
                        }                        
                        Vector2 direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));
                        if (pwr > 100)
                        {
                            pwr = 100;
                        }
                        //pwr = pwr / 5;
                        Vector3 outPower = direction * (pwr / 5);
                        //arrow AI
                        #region showArrow
                        arrowPlane.gameObject.SetActive(true);
                        arrowPlane.transform.position = transform.position;
                        float outRotation; // between 0 - 360
                        outRotation = angle - 180;
                        arrowPlane.transform.eulerAngles = new Vector3(0, 0, outRotation);
                        float distCount = .5f;
                        if (pwr < 100)
                        {
                            distCount = (pwr * 1.7f) / 100;
                        }
                        else
                        {
                            distCount = 1.7f;
                        }
                        float counter = .5f;
                        while (counter < distCount)
                        {

                            //calculate scale
                            float scaleCoefX = Mathf.Log(2 * counter, 2) * 1f;
                            float scaleCoefY = Mathf.Log(2 * counter, 2) * .7f;
                            arrowPlane.transform.localScale = new Vector3(1 + scaleCoefX, 1 + scaleCoefY, 0.001f);
                            counter += Time.deltaTime;
                            yield return null;
                        }
                        counter = 0;
                        while (counter < 2f)
                        {
                            counter += Time.deltaTime;
                            yield return null;
                        }
                        #endregion showArrow
                        arrowPlane.SetActive(false);
                        GetComponent<Rigidbody2D>().AddForce(outPower, ForceMode2D.Impulse);
                        GameManager.refrence.gameState = GameManager.GameState.moving;
                    }
                }
            }
        }
    }

    #endregion codeController


    void checkSpeed()
    {
        if (shoot)
        {
            if(playerBody.velocity.magnitude < .2f && GameManager.refrence.gameState == GameManager.GameState.moving)
            {
                //print("player stoped");
                playerBody.velocity = Vector2.zero;
                shoot = false;
                //GameManager.refrence.checkGameState();
                GameManager.refrence.shouldCheckState = true;
            }
        }
    }

    void manageArrowTransform()
    {
        //power arrow codes
        //hide arrowPlane
        //arrowPlane.GetComponent<Renderer>().enabled = true;
        //shootCircle.GetComponent<Renderer>().enabled = true;

        //calculate position
        if (currentDistance <= maxDis)
        {
            /*arrowPlane.transform.position = new Vector3((2 * transform.position.x) - helperBegin.transform.position.x,
                                                            (2f * transform.position.y) - helperBegin.transform.position.y,
                                                              -1.5f);*/
            arrowPlane.transform.position = transform.position;
        }
        else
        {
            Vector3 dxy = helperBegin.transform.position - transform.position;
            float diff = dxy.magnitude;
            arrowPlane.transform.position = transform.position;
            //arrowPlane.transform.position = transform.position + ((dxy / diff) * maxDis * -1);
            //arrowPlane.transform.position = new Vector3(arrowPlane.transform.position.x,
            //arrowPlane.transform.position.y,
            //-1.5f);
        }

        //shootCircle.transform.position = transform.position + new Vector3(0, 0, 0.05f);
        //print(helperBegin.transform.position - transform.position);
        //Vector2 dir = (helperBegin.transform.position - transform.position);
        
        //print(Vector2.Angle(dir,Vector2.right));
        //calculate rotation
        if (helperBegin.transform.position.y > transform.position.y)
         {

             Vector2 dir = (helperBegin.transform.position - transform.position);
             float outRotation; // between 0 - 360

             if (Vector2.Angle(dir, transform.right) > 90)
                 outRotation = Vector2.Angle(dir, transform.right);
             else
                 outRotation = Vector2.Angle(dir, transform.right);
             arrowPlane.transform.eulerAngles = new Vector3(0, 0, outRotation);
         }
         else if (helperBegin.transform.position.y < transform.position.y)
         {
             Vector2 dir = (helperBegin.transform.position - transform.position);
             float outRotation; // between 0 - 360

             if (Vector2.Angle(dir, transform.right) > 90)
                 outRotation = Vector2.Angle(dir, transform.right)*-1;
             else
                 outRotation = Vector2.Angle(dir, transform.right)*-1;
             arrowPlane.transform.eulerAngles = new Vector3(0, 0, outRotation);
         }
         
        //print(Vector3.Angle(dir, transform.forward));

        //calculate scale
        float scaleCoefX = Mathf.Log(2* safeDis , 2) * 1f;
        //float scaleCoefY = Mathf.Log(1 + safeDis / 2, 2) * 2.2f;
        float scaleCoefY = Mathf.Log(2*safeDis, 2) * .7f;
        arrowPlane.transform.localScale = new Vector3(1 + scaleCoefX, 1+ scaleCoefY, 0.001f); //default scale
        //shootCircle.transform.localScale = new Vector3(1 + scaleCoefX * 3, 1 + scaleCoefY * 3, 0.001f); //default scale
    }

    void manageArrowTransformForCVC(float angle)
    {
        arrowPlane.gameObject.SetActive(true);
        arrowPlane.transform.position = transform.position;

        float outRotation; // between 0 - 360
        outRotation = angle - 180;
        arrowPlane.transform.eulerAngles = new Vector3(0, 0, outRotation);
        //calculate scale
        float scaleCoefX = Mathf.Log(2 * 1.7f, 2) * 1f;       
        float scaleCoefY = Mathf.Log(2 * 1.7f, 2) * .7f;
        arrowPlane.transform.localScale = new Vector3(1 + scaleCoefX, 1 + scaleCoefY, 0.001f); //default scale
        //shootCircle.transform.localScale = new Vector3(1 + scaleCoefX * 3, 1 + scaleCoefY * 3, 0.001f); //default scale
    }

    void castRay()
    {

        //cast the ray from units position with a normalized direction out of it which is mirrored to our current drag vector.
        ray = new Ray2D(transform.position, (helperEnd.transform.position - transform.position).normalized);

        hitInfo = Physics2D.Raycast(transform.position, ((helperEnd.transform.position - transform.position)).normalized, 3);
        if (hitInfo)
        {
            print(hitInfo.transform.name);
            GameObject objectHit = hitInfo.transform.gameObject;

            //debug line whenever the ray hits something.
            Debug.DrawLine(ray.origin, hitInfo.point, Color.cyan);

            //draw reflected vector like a billiard game. this is the out vector which reflects from targets geometry.
            Vector3 reflectedVector = Vector3.Reflect((hitInfo.point - ray.origin), hitInfo.normal);
            Debug.DrawRay(hitInfo.point, reflectedVector, Color.gray, 0.2f);

            //draw inverted reflected vector (useful for fine-tuning the final shoot)
            Debug.DrawRay(hitInfo.transform.position, reflectedVector * -1, Color.white, 0.2f);

            //draw the inverted normal which is more likely to be similar to real world response.
            Debug.DrawRay(hitInfo.transform.position, hitInfo.normal * -3, Color.red, 0.2f);

            //Debug
            //print("Ray hits: " + objectHit.name + " At " + Time.time + " And Reflection is: " + reflectedVector);
        }
    }


    public void makeGameFaster()
    {
        Time.timeScale = 10;
    }

    public void makeGameSlower()
    {
        Time.timeScale = 1;
    }


    void OnCollisionEnter2D(Collision2D target)
    {
        
        /*if(target.transform.tag == "left")
        {
            print(target.gameObject.name);

            oldVel = GetComponent<Rigidbody2D>().velocity;
            // GetComponent<Rigidbody2D>().AddForce(target.contacts[0].normal * 2f, ForceMode2D.Impulse);
            ContactPoint2D cp = target.contacts[0];
            GetComponent<Rigidbody2D>().velocity = Vector3.Reflect(oldVel, cp.normal);

            // bumper effect to speed up ball
            GetComponent<Rigidbody2D>().velocity =  2 * GetComponent<Rigidbody2D>().velocity;

        }*/
    }

    public void activePlayer()
    {
        //if (GameManager.refrence.gameState == GameManager.GameState.frozen)
        {
            if (transform.tag == "team1" && GameManager.refrence.turn == GameManager.Turn.team1)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                GetComponent<Animator>().SetTrigger("active");
            }
            else if (transform.tag == "team2" && GameManager.refrence.turn == GameManager.Turn.team2)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                GetComponent<Animator>().SetTrigger("active");
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(false);
                //transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("active");
            }
        }
    }

    public void deActivePlayer()
    {
        //if (GameManager.refrence.gameState == GameManager.GameState.frozen)
        {
            if (transform.tag == "team1" && GameManager.refrence.turn == GameManager.Turn.team1)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                //GetComponent<Animator>().SetTrigger("active");
            }
            else if (transform.tag == "team2" && GameManager.refrence.turn == GameManager.Turn.team2)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                //GetComponent<Animator>().SetTrigger("active");
            }
            else
            {
                //transform.GetChild(0).gameObject.SetActive(false);
                //transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("active");
            }
        }
    }
}
