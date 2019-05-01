using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    #region Variables

    public GameObject helperBegin;
    public GameObject helperEnd;

    public float currentDistance;
    public float maxDis;
    public float minDis;
    float safeDis;

    public int factor;
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
        Name.text = name;
        minDis = .5f;
    }

    void FixedUpdate()
    {

        //print("player speed: " + playerBody.velocity.magnitude);

        checkSpeed();

        if (GameManager.refrence.gameState == GameManager.GameState.frozen)
        {
            if (transform.tag == "team1" && GameManager.refrence.turn == GameManager.Turn.team1)
            {
                canShoot = true;
            }
            else if (transform.tag == "team2" && GameManager.refrence.turn == GameManager.Turn.team2)
            {
                canShoot = true;
            }
            else
            {
                canShoot = false;
            }
        }
    }


    #region userController
    float angle;
    void OnMouseDrag()
    {
        if (GameManager.refrence.gameHalf == GameManager.GameHalf.finish)
            return;

        if (MenuManager.refrence.gameMode == MenuManager.Mode.pvp || (MenuManager.refrence.gameMode == MenuManager.Mode.pvc && GameManager.refrence.turn == GameManager.Turn.team2))
        {
            if (GameManager.refrence.gameState != GameManager.GameState.moving)
            {
                if (canShoot)
                {
                    arrowPlane.SetActive(true);
                    currentDistance = Vector2.Distance(helperBegin.transform.position, transform.position);

                    if (currentDistance <= maxDis)
                    {
                        safeDis = currentDistance;
                    }
                    else
                    {
                        safeDis = maxDis;
                    }

                    pwr = Mathf.Abs(safeDis) * factor; //13


                    manageArrowTransform();
                    //castRay();
                    //helperEnd

                    Vector3 dxy = helperBegin.transform.position - transform.position;
                    float diff = dxy.magnitude;
                    helperEnd.transform.position = transform.position + ((dxy / diff) * currentDistance * -1);

                    helperEnd.transform.position = new Vector3(helperEnd.transform.position.x, helperEnd.transform.position.y, -0.5f);
                    //helperEnd

                    Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
                    Vector3 hb = new Vector3(helperBegin.transform.position.x, helperBegin.transform.position.y, 0);
                    shootDirectionVector = Vector3.Normalize(hb - pos);
                    Vector2 targetDir = (-1) * (helperBegin.transform.position - transform.position);
                    angle = Vector2.Angle(transform.right, targetDir);
                    if (pos.y < hb.y)
                        angle = 360 - angle;

                    if(MenuManager.refrence.gameMode==MenuManager.Mode.pvc) //ScreenShot of the player! awful performance!
                        screenShot();
                }
            }
        }
    }

    void OnMouseUp()
    {
        if (GameManager.refrence.gameHalf == GameManager.GameHalf.finish)
            return;

        if (MenuManager.refrence.gameMode == MenuManager.Mode.pvp || (MenuManager.refrence.gameMode == MenuManager.Mode.pvc && GameManager.refrence.turn == GameManager.Turn.team2))
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
                        Vector2 outPower = shootDirectionVector * pwr * -1;

                        if (MenuManager.refrence.gameMode == MenuManager.Mode.pvc)
                        {
                            GameManager.refrence.game_log_shoot(ID - 1, (int)angle, (int)((safeDis / maxDis) * 100));
                        }

                        arrowPlane.SetActive(false);
                        GetComponent<Rigidbody2D>().AddForce(outPower, ForceMode2D.Impulse);
                    }
                    else
                    {
                        arrowPlane.SetActive(false);
                    }

                }
            }
        }
    }

    #endregion userController

    public static void screenShot()
    {
        if (MenuManager.refrence.gameMode == MenuManager.Mode.cvc || MenuManager.refrence.gameMode==MenuManager.Mode.pvc)
            ScreenCapture.CaptureScreenshot(System.IO.Directory.GetCurrentDirectory() + "\\" + string.Format("ScreenShots/pic{0}.PNG", GameManager.refrence.cycle_no));
    }

    public static void screenShot(string name)
    {
        if (MenuManager.refrence.gameMode == MenuManager.Mode.cvc || MenuManager.refrence.gameMode == MenuManager.Mode.pvc)
            ScreenCapture.CaptureScreenshot(System.IO.Directory.GetCurrentDirectory() + "\\" + string.Format("ScreenShots/{0}.png", name));
    }

    #region codeController
    public IEnumerator Shoot(float angle, float pwr)
    {
        //manageArrowTransformForCVC(angle);
        // shoot player[ID] with pwr power in direction of angle
        if (MenuManager.refrence.gameMode == MenuManager.Mode.cvc || MenuManager.refrence.gameMode == MenuManager.Mode.pvc || MenuManager.refrence.gameMode == MenuManager.Mode.log)
        {
            if (GameManager.refrence.gameState != GameManager.GameState.moving)
            {
                if (canShoot 
                    || MenuManager.refrence.gameMode == MenuManager.Mode.cvc 
                    || MenuManager.refrence.gameMode == MenuManager.Mode.log 
                    || (MenuManager.refrence.gameMode == MenuManager.Mode.pvc && GameManager.refrence.turn == GameManager.Turn.team1))
                {
                    for (int i = 0; i < GameManager.refrence.allPlayers.Length; i++)
                    {

                        GameManager.refrence.allPlayers[i].GetComponent<PlayerController>().activePlayer();
                    }
                    shoot = true;
                    Vector2 direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));
                    if (pwr > 100)
                    {
                        pwr = 100;
                    }
                    Vector2 outPower = direction * (pwr * .34f);
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
                    screenShot();

                    counter = 0;
                    while (counter < 1f)
                    {
                        counter += Time.deltaTime;
                        yield return null;
                    }
                    arrowPlane.SetActive(false);
                    #endregion showArrow
                    for (int i = 0; i < GameManager.refrence.allPlayers.Length; i++)
                    {
                        GameManager.refrence.allPlayers[i].transform.GetChild(0).gameObject.SetActive(false);
                    }
                    GetComponent<Rigidbody2D>().AddForce(outPower, ForceMode2D.Impulse);
                    GameManager.refrence.gameState = GameManager.GameState.moving;
                }
            }
        }
    }

    #endregion codeController


    void checkSpeed()
    {
        if (shoot)
        {
            if(playerBody.velocity.magnitude == 0 && GameManager.refrence.gameState == GameManager.GameState.moving)
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
        //calculate position
        if (currentDistance <= maxDis)
        {
            
            arrowPlane.transform.position = transform.position;
        }
        else
        {
            Vector3 dxy = helperBegin.transform.position - transform.position;
            float diff = dxy.magnitude;
            arrowPlane.transform.position = transform.position;
            
        }

        
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
        //print(safeDis);
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
            //print(hitInfo.transform.name);
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
        Time.timeScale = 100;
    }

    public void makeGameSlower()
    {
        Time.timeScale = 1;
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
