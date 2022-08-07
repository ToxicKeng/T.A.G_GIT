using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    [SerializeField] float move;
    float yVelocity = 0;
    [SerializeField] LayerMask ground;
    [SerializeField] Transform PlayerContainer;
    [SerializeField]
    private Rigidbody rb;
    public float lockPos;

    float lockpos = 0;

    const float G = 667.4f;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {

        transform.rotation = Quaternion.Euler(lockPos, 180, lockPos);

        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            rb.velocity = new Vector3(0, rb.velocity.y, -5f);

        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, +90, 0);
            rb.velocity = new Vector3(0f, rb.velocity.y, 5f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rb.velocity = new Vector3(-5f, rb.velocity.y, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, +180, 0);
            rb.velocity = new Vector3(5f, rb.velocity.y, 0);

        }

    }
}