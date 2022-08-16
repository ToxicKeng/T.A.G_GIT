using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollClass
{
    public Transform transform;
    public Rigidbody body;

    public const float G = 667.4f;

    public Keys[] keys = new Keys[4];
    public float MoveSpeed = 5f;

    public float lockPos;

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
        /*Vector3 rotation = Quaternion.EulerAngles()*/
        for(int i = 0; i < keys.Length; i++)
        {
            Debug.Log(keys[i].keyCode);
            if (Input.GetKey(keys[i].keyCode))
            {
                direction += keys[i].direction;
                Debug.Log(direction);
                body.rotation = Quaternion.Euler(keys[i].Rotation);
            }
        }
        direction = direction.normalized * MoveSpeed;

        body.velocity = direction;

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            body.velocity = new Vector3(0, 5f, 0).normalized * MoveSpeed;
        }
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
