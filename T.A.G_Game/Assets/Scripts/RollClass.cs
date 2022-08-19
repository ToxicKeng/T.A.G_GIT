using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollClass
{
    public Transform transform;
    public Rigidbody body;

    public const float G = 9.81f;

    public Keys[] keys = new Keys[5];


    public float MoveSpeed = 5f;
    public float JumpVelocity = 1500f;

    public float lockPos;

    float velocity = 0;

    float distance;

    public RollClass(Transform transform, Rigidbody body, Keys[] keys, float distance, float lockPos)
    {
        this.keys = keys;
        this.transform = transform;
        this.body = body;
        this.distance = distance;
        this.lockPos = lockPos;
    }

    public void Move()
    {
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, distance, LayerMask.GetMask("Ground"));
        transform.rotation = Quaternion.Euler(lockPos, 180, lockPos);
        Vector3 direction = Vector3.zero;

        for (int i = 0; i < keys.Length; i++)
        {
            if (Input.GetKey(keys[i].keyCode))
            {
                if (keys[i].direction.y > 0 && isGrounded)
                {
                    if (isGrounded)
                    {
                        body.AddForce(Vector3.up * JumpVelocity, ForceMode.Acceleration);
                    }
                    continue;
                }
                direction += keys[i].direction;
                body.rotation = Quaternion.Euler(keys[i].Rotation);
            }
        }
        Vector3 rotaitonDirection = direction;
        rotaitonDirection.y = 0;

        if (!isGrounded)
        {
            velocity += Time.deltaTime * G;
        } else
        {
            velocity = -0.02f;
        }

        //if(isJumping)
        //{
        //    body.AddForce((Vector3.up * JumpVelocity) * (JumpTime / TimeElapsed), ForceMode.Acceleration);
        //    TimeElapsed += Time.deltaTime;
        //}
        //if(TimeElapsed >= JumpTime)
        //{
        //    isJumping = false;
        //}

        transform.rotation = Quaternion.LookRotation(rotaitonDirection);
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