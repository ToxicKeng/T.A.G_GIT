using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Red_Colider : MonoBehaviour
{
    public float RadNum = 0f;

    public TMPro scoreText;
    public float scoreAmount;
    public float pointIncreasedPerSecond;

    void Start()
    {
        RNG();
        scoreAmount = 0f;
        pointIncreasedPerSecond = 10f;
    }
    
     void Update()
    {
        scoreText.text = (int)scoreAmount + "";
        scoreAmount += pointIncreasedPerSecond * Time.deltaTime;


    }

    private void RNG()
    {

        RadNum = Random.Range(1, 3);
        Debug.Log(RadNum);
        if (RadNum == 1)
        {
            Chaser();
        }
        else
        {
            Runner();
        }
       
    }

    private void Chaser()
    {

    }
    private void Runner()
    {

    }


    private void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.tag == "HitBlue")
            {
                Debug.Log("Taged Red");
            }
        }
    }
