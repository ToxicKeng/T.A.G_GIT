using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollClass
{
    public Transform transform;
    public Rigidbody body;

    public const float G = 667.4f;

    public KeyCode[] keys;
    public float MoveSpeed = 5f;

    public float lockPos;

    float distance;
    public RollClass(Transform transform, Rigidbody body, KeyCode[] Keys , float distance, float lockPos)
    {
        this.keys = Keys;
        this.transform = transform;
        this.body = body;
        this.distance = distance;
        this.lockPos = lockPos;
    }

    public void Move()
    {
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, distance, LayerMask.GetMask("Ground"));
        transform.rotation = Quaternion.Euler(lockPos, 180, lockPos);

        if (Input.GetKey(keys[2]))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            body.velocity = new Vector3(0, body.velocity.y, -5f).normalized * MoveSpeed;
        }
        if (Input.GetKey(keys[0]))
        {
            transform.rotation = Quaternion.Euler(0, +90, 0);
            body.velocity = new Vector3(0f, body.velocity.y, 5f).normalized * MoveSpeed;
        }
        if (Input.GetKey(keys[1]))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            body.velocity = new Vector3(-5f, body.velocity.y, 0).normalized * MoveSpeed;
        }
        if (Input.GetKey(keys[3]))
        {
            transform.rotation = Quaternion.Euler(0, +180, 0);
            body.velocity = new Vector3(5f, body.velocity.y, 0).normalized * MoveSpeed;

        }
        if (Input.GetKey(keys[0]) && Input.GetKey(keys[3]))
        {
            transform.rotation = Quaternion.Euler(0, +135, 0);
            body.velocity = new Vector3(5f, body.velocity.y, 5f).normalized * MoveSpeed;
        }
        if (Input.GetKey(keys[0]) && Input.GetKey(keys[1]))
        {
            transform.rotation = Quaternion.Euler(0, +45, 0);
            body.velocity = new Vector3(-5f, body.velocity.y, 5f).normalized * MoveSpeed;
        }
        if (Input.GetKey(keys[2]) && Input.GetKey(keys[3]))
        {
            transform.rotation = Quaternion.Euler(0, -135, 0);
            body.velocity = new Vector3(5f, body.velocity.y, -5f).normalized * MoveSpeed;
        }
        if (Input.GetKey(keys[2]) && Input.GetKey(keys[1]))
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
            body.velocity = new Vector3(-5f, body.velocity.y, -5f).normalized * MoveSpeed;
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            body.velocity = new Vector3(0, 5f, 0).normalized * MoveSpeed;
        }
    }

}
