using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trainMoving : MonoBehaviour
{
    public float speed;
    float zPos;
    
    
    public float departureTime;
    
    public bool departure;
    public bool startMoving;
    bool runOnce;

    public GameObject musicPlayer;

    public GameObject player;
    public GameObject playerBottom;

    // Start is called before the first frame update
    void Start()
    {
        departure = false;
        runOnce = false;
        zPos = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetAxis("Mouse X") == 0 && Input.GetAxis("Mouse Y") == 0) //¨S°Ê
        {
            
        }
        else
        {
            departure = true;
        }


        if (departure&&!runOnce)
        {
            musicPlayer.SetActive(true);
            Invoke("Depature", departureTime);
            runOnce = true;
        }

        

       /* if (startMoving)
        {
            zPos -= speed * Time.deltaTime;
        }


        transform.position = new Vector3(transform.position.x, transform.position.y, zPos);*/


    }

    void Depature()
    {
        
        startMoving = true;
      //  player.GetComponent<Animator>().SetTrigger("depature");
      //  playerBottom.GetComponent<Animator>().SetTrigger("depature");
        Debug.Log("go!");
    }

    

}
