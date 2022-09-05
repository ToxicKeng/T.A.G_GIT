using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Colider : MonoBehaviour
{
    public float RadNum = 0f;

    void Start()
    {
        RNG();
    }
    
     void Update()
    {
     



    }

    private void RNG()
    {

        RadNum = Random.Range(1, 3);
        Debug.Log(RadNum);
       
    }


    private void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.tag == "HitBlue")
            {
                Debug.Log("Taged Red");
            }
        }
    }
