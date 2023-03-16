using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friendHand : MonoBehaviour
{
    public GameObject hand;
    public float rotateMod;

    public bool mirrored;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mirrored)
        {
            transform.eulerAngles = new Vector3(hand.transform.eulerAngles.x, hand.transform.eulerAngles.y, -hand.transform.eulerAngles.z + rotateMod);
        }
        else
        {
            transform.eulerAngles = new Vector3(hand.transform.eulerAngles.x, hand.transform.eulerAngles.y, hand.transform.eulerAngles.z + rotateMod);
        }


    }
}
