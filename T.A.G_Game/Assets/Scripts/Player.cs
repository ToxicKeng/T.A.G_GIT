using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update


    PlayerClass player;
    private void Awake()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        player = new PlayerClass(false);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            Debug.Log(collision.gameObject.tag);
        }
    }
}
