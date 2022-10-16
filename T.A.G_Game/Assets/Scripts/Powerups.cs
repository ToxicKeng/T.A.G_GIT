using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script allows the player to use power ups
public class Powerups: MonoBehaviour {
    public GameObject[] powerups;
    GameObject[] Arena;
    float countdown = 2f;

    private void GeneratePowerup() {
        while(true) {
            bool insideBounds = true;
            GameObject spawnPlatform = Arena[Random.Range(0, Arena.Length)];
            Bounds bounds = spawnPlatform.GetComponent<Renderer>().bounds;

            float randomX = Random.Range(0, bounds.size.x);
            float randomZ = Random.Range(0, bounds.size.z); //not random...

            GameObject PowerupOj = powerups[Random.Range(0, powerups.Length)];
            Vector3 powerupPos = new Vector3(bounds.min.x + randomX, bounds.size.y, bounds.min.z + randomZ); //doesn't work for ramps, need to raycast down to get new pos...
            RaycastHit hit;
            Physics.Raycast(powerupPos, Vector3.down, out hit, 1000, LayerMask.GetMask("Ground"));

            Vector3 newPos = hit.point + new Vector3(0,2,0);
            

            for(int i = 0; i < Arena.Length; i++) {
                if (!bounds.Intersects(Arena[i].GetComponent<Renderer>().bounds)) {
                    insideBounds = false;
                    GameObject powerup = Instantiate(PowerupOj, newPos, new Quaternion(90, 0,0, 0));
                    countdown = Random.Range(2, 5);
                }
            }
            if(insideBounds == false) {
                break;
            }
        }
    }

    private void Start() {
        Arena = GameObject.FindGameObjectsWithTag("GroundTag");
    }

    float timeElapsed = 0;
    private void Update() {
        GameObject[] activePowerups = GameObject.FindGameObjectsWithTag("Powerup");

        if(activePowerups.Length == 0) {
            timeElapsed += Time.deltaTime;
            if(countdown < timeElapsed) {
                GeneratePowerup();
                timeElapsed = 0;
            }
        }
    }
}
