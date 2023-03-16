using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trainShaking : MonoBehaviour
{
    public trainMoving myTrain;
    public float shakeRange;
    public float shakingSpeed;
    float yPos;
    float shake;
    public Material mat;
    public Color originalColor;

    public float timer;
    float colorOffset;

    public TrailRenderer tr01;
    public TrailRenderer tr02;
    public TrailRenderer tr03;

    float colorChangingTimer;

    public Color[] allColors;
    int dice;

    // Start is called before the first frame update
    void Start()
    {

        yPos = 0;
        mat.color = originalColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (myTrain.startMoving)
        {
            yPos = map(Mathf.Sin(shake), -1, 1, -shakeRange, shakeRange);
            shake += shakingSpeed * Time.deltaTime;
            timer += Time.deltaTime;

            if (tr01.time < 0.5)
            {
                tr01.time += Time.deltaTime * 0.005f;
            }
            if (tr02.time < 0.2)
            {
                tr02.time += Time.deltaTime * 0.005f;
            }

            if (tr03.time < 0.3)
            {
                tr03.time += Time.deltaTime * 0.005f;
            }


            /*mat.color = new Color(map(Mathf.Sin(shake / 5), -1, 1, 0.5f- colorOffset, 0.5f+ colorOffset),
                                                                 map(Mathf.Sin(shake / 2), -1, 1, 0.4f - colorOffset, 0.4f + colorOffset),
                                                                 map(Mathf.Sin(shake / 6), -1, 1, 0.6f - colorOffset, 0.6f + colorOffset),
                                                                 map(Mathf.Sin(shake / 3), -1, 1, 0.5f - colorOffset, 0.5f + colorOffset));*/

            if (timer > 25)
            {
                colorChangingTimer += Time.deltaTime;

                if (colorChangingTimer > 0.75f)
                {
                    colorChangingTimer = 0;
                    dice = Random.Range(0, allColors.Length);
                    mat.color = allColors[dice];

                }


                /*mat.color = new Color(map(Mathf.Sin(shake / 5), -1, 1, 0.55f, 0.9f),
                                                                map(Mathf.Sin(shake / 2), -1, 1, 0.3f, 0.7f),
                                                                map(Mathf.Sin(shake / 6), -1, 1, 0.5f, 0.9f),
                                                                map(Mathf.Sin(shake / 3), -1, 1, 0.3f, 0.7f));*/
            }
           
        }

        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        
    }

    float map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }

}
