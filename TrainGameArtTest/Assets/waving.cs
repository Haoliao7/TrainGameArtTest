using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waving : MonoBehaviour
{
    
    float angle;

    public float wavingSpeed;

    bool moving;
    float timer;
    public float timeLimit;

    //public Quaternion handDown;
    int mod;
    public float handDownSpeed;
    public float handDownSpeedMod;
    float realHandDownSpeed;

    bool gameEnd;
    float gameEndTimer;
    public float timeBeforeTurnBack;
    public float timeBeforeCallSound;
    public float timeBeforeEnterTunnel;
    public float timeBeforeRealEnd;
    public float a;
    //public Animator player;
    //public Animator playerBottom;
    public GameObject hand;
    public GameObject tunnel;
    public GameObject tunnelB;
    public float tunnelSpeed;
    public GameObject black;

    public trainMoving myTrain;
    public GameObject tunnelSoundPlayer;

    public GameObject white;
    public AudioSource music;

    /*public float offset;
    float zAngle;
    float wavingTimer;*/

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnd)
        {
            gameEndTimer += Time.deltaTime;
            music.volume -= Time.deltaTime * 0.15f;
            /*if (gameEndTimer > timeBeforeTurnBack)
            {
                //hand.SetActive(false);
                //player.SetTrigger("end");
                //playerBottom.SetTrigger("end");
                
            }*/

            if (gameEndTimer > timeBeforeCallSound)
            {
                if (!tunnelSoundPlayer.activeSelf) tunnelSoundPlayer.SetActive(true);
                
            }

            if (gameEndTimer > timeBeforeEnterTunnel)
            {
                //動畫
                if (!tunnel.activeSelf)
                {
                    tunnel.SetActive(true);
                    tunnelB.SetActive(true);
                }
                if (!white.activeSelf) white.SetActive(true);
                
                /*
                tunnel.transform.localScale = new Vector3(
                    tunnel.transform.localScale.x - tunnelSpeed,
                    tunnel.transform.localScale.y - tunnelSpeed, 
                    tunnel.transform.localScale.z - tunnelSpeed
                    );

                if (tunnel.transform.localScale.x <= 1)
                {
                    tunnelB.SetActive(true);
                }*/
            }

            if (gameEndTimer > timeBeforeRealEnd)
            {
                black.SetActive(true);
            }



        }



        if (Input.GetAxis("Mouse X") == 0 && Input.GetAxis("Mouse Y") == 0 && myTrain.startMoving) //沒動
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            
        }

        if (timer > timeLimit)
        {
            moving = false;
            //Debug.Log("hahaha");
        }
        else
        {
            moving = true;
        }


        /*if (myTrain.startMoving)
        {
            if (offset < 180) offset += Time.deltaTime * 2f;
        }*/


        if (moving && !gameEnd)
        {
            if (myTrain.departure)
            {
                var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, wavingSpeed);
                /*
                if (transform.eulerAngles.z < 80 - offset) transform.eulerAngles = new(transform.eulerAngles.x, transform.eulerAngles.y, 80 - offset);
                if (transform.eulerAngles.z > 80 + offset) transform.eulerAngles = new(transform.eulerAngles.x, transform.eulerAngles.y, 80 + offset);
                */




            }

        }
        else
        {
            if ( transform.eulerAngles.z > 268 && transform.eulerAngles.z<272)
            {
                gameEnd = true;
            }
            else
            {
                if (transform.eulerAngles.z < 90)
                {
                    mod = -1;
                    realHandDownSpeed = handDownSpeed + (90+ transform.eulerAngles.z) * handDownSpeedMod;
                }
                if (transform.eulerAngles.z >270)
                {
                    mod = -1;
                    realHandDownSpeed = handDownSpeed + (transform.eulerAngles.z-270) * handDownSpeedMod;
                }
                if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
                {
                    mod = 1;
                    realHandDownSpeed = handDownSpeed - (transform.eulerAngles.z - 270)* handDownSpeedMod;
                }

                transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + realHandDownSpeed * Time.deltaTime * mod);

            }
        }

        

        
    }

    float map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }
}
