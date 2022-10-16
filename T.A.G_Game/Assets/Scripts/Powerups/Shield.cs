using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shield : MonoBehaviour
{
    bool active = false;
    float duration = 3f;
    float timeElapsed = 0;
    float timeAlive = 0;
    Collider Player;
    [SerializeField] Material ShieldMaterial;
    GameObject shieldSphere;
    string PrevTag;
    private void Start() {
        transform.rotation = Quaternion.Euler(new Vector3(90,0,0));
    }

    private void Update() {
        transform.Rotate(Vector3.forward * Time.deltaTime * 25);
        if (active) {
            shieldSphere.transform.position = Player.transform.position;
            if (duration < timeElapsed) {
                active = false;
                Destroy(shieldSphere);
                Player.tag = PrevTag;
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
            active = true;
            Player = other;

            Destroy(transform.GetComponent<MeshFilter>());
            Destroy(transform.GetComponent<Renderer>());

            shieldSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            float radius = Player.GetComponent<CapsuleCollider>().height + 0.5f;
            shieldSphere.transform.localScale = new Vector3(radius, radius, radius);
            shieldSphere.GetComponent<Renderer>().material = ShieldMaterial;
            Destroy(shieldSphere.GetComponent<SphereCollider>());
            Destroy(shieldSphere.GetComponent<BoxCollider>());
            PrevTag = Player.tag;
            Player.tag = "Shielded_Player";
        }
    }
}
