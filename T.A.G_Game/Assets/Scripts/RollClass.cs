using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class RollClass
{
    public Transform transform;
    public Rigidbody body;

    public const float G = 5.3f;

    public Keys[] keys = new Keys[5];

    public KeyCode Jump;

    public float MoveSpeed = 5f;
    public float JumpVelocity = 10;

    public float lockPos;

    float velocity = 0;

    public RollClass(Transform transform, Rigidbody body, Keys[] keys, KeyCode JumpKey)
    {
        this.keys = keys;
        this.transform = transform;
        this.body = body;
        this.Jump = JumpKey;
    }

    public void Move()
    {
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

        if (rotaitonDirection.magnitude != 0)
        {
            transform.rotation = Quaternion.LookRotation(rotaitonDirection);
        }

        direction = direction.normalized * MoveSpeed * 2;
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