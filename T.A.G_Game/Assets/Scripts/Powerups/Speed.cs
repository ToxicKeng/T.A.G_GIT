using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    bool active = false;
    float duration = 3f;
    float speedBuff = 1.15f;
    float timeElapsed = 0;
    float timeAlive = 0;
    Collider Player;
    private void Start() {
        transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
    }

    private void Update() {
        transform.Rotate(Vector3.forward * Time.deltaTime * 25);
        if(active) {
            Rigidbody rb = Player.transform.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(rb.velocity.x * speedBuff, rb.velocity.y, rb.velocity.z * speedBuff);
            if(duration < timeElapsed) {
                active = false;
                Destroy(gameObject);
            }
            timeElapsed += Time.deltaTime;
        }
        if (5 < timeAlive && active == false) {
            Destroy(gameObject);
        }
        timeAlive += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) {
        if(active != true) {
            Player = other;
            active = true;
            Destroy(transform.GetComponent<MeshFilter>());
            Destroy(transform.GetComponent<Renderer>());
        }
    }
}
