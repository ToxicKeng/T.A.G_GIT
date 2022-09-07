using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] players;

    public float scoreAmount;
    public float pointIncreasedPerSecond;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI role;

         
    bool GameOver = false;

    GameObject playerTagged;

    void Start()
    {
        playerTagged = players[Random.Range(0, players.Length)];
        print(playerTagged.name);
        playerTagged.tag = "Tagged";

        role.text = "Tagger is: " + playerTagged.name;
    }

    private void Update()
    {
        if(playerTagged.tag == "Player")
        {
            GameOver = true;
        }

        if(!GameOver){
            scoreText.text = (int)scoreAmount + "";
            scoreAmount += pointIncreasedPerSecond * Time.deltaTime;

            //game stopped here
        }
    }
}
