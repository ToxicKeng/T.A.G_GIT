using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll1 : MonoBehaviour
{
    RollClass rollData;
    [SerializeField] Transform PlayerContainer;
    private Rigidbody rb;
    [SerializeField] CapsuleCollider col;
    public float LockPos;
    public KeyCode Jump;

    public RollClass.Keys[] keys = new RollClass.Keys[4];

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        float distance = GetComponent<CapsuleCollider>().height / 2 + 0.3f;
        rollData = new RollClass(PlayerContainer, rb, keys, distance, Jump);
    }

    // Update is called once per frame
    private void Update()
    {
        rollData.Move();
    }
}
