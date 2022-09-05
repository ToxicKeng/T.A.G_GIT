using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollClass
{
    public Transform transform;
    public Rigidbody body;

    public const float G = 9.81f;

    public Keys[] keys = new Keys[5];

    public KeyCode Jump;

    public float MoveSpeed = 5f;
    public float JumpVelocity = 10;

    public float lockPos;

    float velocity = 0;
    float velocityJump;
    public bool isGrounded = false;

    float distance;
    CapsuleCollider collider;

    public RollClass(Transform transform, Rigidbody body, Keys[] keys, float distance, KeyCode JumpKey)
    {
        this.keys = keys;
        this.transform = transform;
        this.body = body;
        this.distance = distance;
        this.Jump = JumpKey;
        collider = transform.GetComponent<CapsuleCollider>();
    }

    public void Move()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, collider.height, LayerMask.GetMask("Ground"));
        transform.rotation = Quaternion.Euler(lockPos, 180, lockPos);
        Vector3 direction = Vector3.zero;

        for (int i = 0; i < keys.Length; i++)
        {
            if (Input.GetKey(keys[i].keyCode))
            {
                direction += keys[i].direction;
                body.rotation = Quaternion.Euler(keys[i].Rotation);
            }
        }
        Vector3 rotaitonDirection = direction;
        rotaitonDirection.y = 0;

        if (isGrounded)
        {
            velocity = 5f;
        }
        else
        {
            velocity += Time.deltaTime * G;
        }
        if (Input.GetKeyDown(Jump) && isGrounded )
        {
            velocityJump = JumpVelocity;
            //body.AddForce(Vector3.up * JumpVelocity * 10, ForceMode.Impulse);
            
        }
            //transform.Translate(new Vector3(0, velocityJump, 0) * Time.deltaTime);


        if (rotaitonDirection.magnitude != 0)
        {
            transform.rotation = Quaternion.LookRotation(rotaitonDirection);
        }

        direction = direction.normalized * MoveSpeed;
        direction.y = -velocity;

        body.velocity = direction;
    }
    [System.Serializable]

    public struct Keys
    {
        public KeyCode keyCode;
        public Vector3 direction;
        public Vector3 Rotation;
        public Keys(KeyCode code, Vector3 dir, Vector3 Rotation)
        {
            this.keyCode = code;
            this.direction = dir;
            this.Rotation = Rotation;
        }
    }
}