using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Move : MonoBehaviour
{
    public float Speed;

    float MovementX;
    float MovementY;

    Rigidbody Rb;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        MovementX = 0;
        MovementY = 0; 
        
    }

    // Update is called once per frame
    void Update()
    {
        Rb.velocity = new Vector3(MovementX * Speed * Time.deltaTime, MovementY * Speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MovementY = 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MovementY = -1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MovementX = -1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MovementX = 1;
        }
    }
}
