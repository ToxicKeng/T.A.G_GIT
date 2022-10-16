using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//code used for tag detection
public class GameManager : MonoBehaviour
{
    public GameObject[] players;

    public float scoreAmount;
    public float pointIncreasedPerSecond;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI scoreTextEnd;
    public TMPro.TextMeshProUGUI role;
    public GameObject GameEndUI;
    
    bool GameOver = false;

    GameObject playerTagged;

    void Start()
    {
        playerTagged = players[Random.Range(0, players.Length)];
        print(playerTagged.name);
        playerTagged.tag = "Tagged";

        role.text = "Tagger is: " + playerTagged.name;
        playerTagged.AddComponent<Player>();
        playerTagged.GetComponent<Player>().GameEndUI = GameEndUI;

    }

    private void Update()
    {
        if(playerTagged.tag == "Player")
        {
            GameOver = true;
        }

        if(!GameOver){
            scoreText.text = (int)scoreAmount + "";
            scoreTextEnd.text = (int)scoreAmount + "";
            scoreAmount += pointIncreasedPerSecond * Time.deltaTime;

            //game stopped here
        }
    }
}
