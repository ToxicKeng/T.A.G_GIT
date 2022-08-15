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

    [SerializeField] KeyCode[] keys = new KeyCode[4];
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        float distance = GetComponent<CapsuleCollider>().height / 2 + 0.1f;
        rollData = new RollClass(PlayerContainer, rb, keys, distance, LockPos);
    }

    // Update is called once per frame
    private void Update()
    {
        rollData.Move();
    }
}
