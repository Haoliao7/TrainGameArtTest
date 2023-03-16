using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{
    trainMoving tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = GameObject.Find("train").GetComponent<trainMoving>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < 126 && tr.startMoving)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + tr.speed * Time.deltaTime);
        }


    }
}
