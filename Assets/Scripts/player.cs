using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

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
    public float angle;

    Vector2 firstPos;
    bool shouldMeasure = false;

    #endregion Variables

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot(angle, pwr);
        }
        measureSpeed();
    }

    #region userController
    
    void OnMouseDrag()
    {

        //if (canShoot)
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

            
        }
    }

    void OnMouseUp()
    {

        //if (canShoot)
        {
            if (currentDistance > minDis)
            {
                shoot = true;
                //for (int i = 0; i < GameManager.refrence.allPlayers.Length; i++)
                {
                    //GameManager.refrence.allPlayers[i].transform.GetChild(0).gameObject.SetActive(false);
                }
                Vector2 outPower = shootDirectionVector * pwr * -1;


                arrowPlane.SetActive(false);
                GetComponent<Rigidbody2D>().AddForce(outPower, ForceMode2D.Impulse);
            }
            else
            {
                arrowPlane.SetActive(false);
            }

        }
    }
   
    void manageArrowTransform()
    {
        //calculate position        
        arrowPlane.transform.position = transform.position;

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
                outRotation = Vector2.Angle(dir, transform.right) * -1;
            else
                outRotation = Vector2.Angle(dir, transform.right) * -1;
            arrowPlane.transform.eulerAngles = new Vector3(0, 0, outRotation);
        }

        //calculate scale
        float scaleCoefX = Mathf.Log(2 * safeDis, 2) * 1f;
        float scaleCoefY = Mathf.Log(2 * safeDis, 2) * .7f;
        arrowPlane.transform.localScale = new Vector3(1 + scaleCoefX, 1 + scaleCoefY, 0.001f); //default scale

    }

    public void Shoot(float angle, float pwr)
    {

        shoot = true;
        Vector2 direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));
        if (pwr > 100)
        {
            pwr = 100;
        }
        Vector2 outPower = direction * (pwr * .34f);
        print(GetComponent<Rigidbody2D>().velocity.magnitude);
        shouldMeasure = true;
        GetComponent<Rigidbody2D>().AddForce(outPower, ForceMode2D.Impulse);

    }

    void measureSpeed()
    {
        if (shouldMeasure)
        {
            float distance = Mathf.Abs(transform.position.x - firstPos.x);
            if (distance > 1)
            {
                print(GetComponent<Rigidbody2D>().velocity.magnitude);
                shouldMeasure = false;
            }
        }
    }

    #endregion userController
}
