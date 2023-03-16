using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailMoving : MonoBehaviour
{
    public float maxY;
    //public float movingSpeed;
    public Vector3 goBackTo;
    trainMoving tr;
    public bool noNeedToGoBack;
    // Start is called before the first frame update
    void Start()
    {
        tr = GameObject.Find("train").GetComponent<trainMoving>();

    }

    // Update is called once per frame
    void Update()
    {
        if (tr.startMoving)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y , transform.position.z + tr.speed * Time.deltaTime);

            if (transform.position.z > maxY && !noNeedToGoBack)
            {
                transform.position = goBackTo;

            }

        }

    }
}
