using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Roll1 : MonoBehaviour
{
    RollClass rollData;
    [SerializeField] Transform PlayerContainer;
    private Rigidbody rb;
    [SerializeField] CapsuleCollider col;
    public float LockPos;
    public KeyCode Jump;
    private float G = 14.5f;
    private float yVelocity = 0;
    public float JumpMultiplier = 1;

    public RollClass.Keys[] keys = new RollClass.Keys[4];

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rollData = new RollClass(PlayerContainer, rb, keys, Jump);
    }

    // Update is called once per frame
    bool isGrounded = true;
    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, col.height/2 + 0.3f, LayerMask.GetMask("Ground"));
        rollData.Move();

        if (isGrounded) {
            yVelocity = 0f;
        } else {
            yVelocity += Time.deltaTime * -G;
        }

        if (isGrounded && Input.GetKey(Jump)) {
            rb.velocity = Vector3.zero;
            yVelocity = 8 * JumpMultiplier;
        }
        transform.Translate(Vector3.up * yVelocity * Time.deltaTime);
    }
}
