using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    bool active = false;
    float duration = 3f;
    float timeElapsed = 0;
    float timeAlive = 0;
    Collider Player;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * 25);

        if (active)
        {
            Player.GetComponent<Roll1>().JumpMultiplier = 1.5f;
            if (duration < timeElapsed)
            {
                Player.GetComponent<Roll1>().JumpMultiplier = 1f;
                active = false;
            }
            timeElapsed += Time.deltaTime;
        }
        if (5 < timeAlive && active == false)
        {
            Destroy(gameObject);
        }
        timeAlive += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Player = other;
        Destroy(transform.GetComponent<MeshFilter>());
        Destroy(transform.GetComponent<Renderer>());
    }
}
