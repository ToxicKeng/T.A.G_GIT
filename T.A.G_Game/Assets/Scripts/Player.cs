using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.tag = "Player";
            collision.gameObject.tag = "Tagged";
            Debug.Log("Game ended");
        }
    }
}
