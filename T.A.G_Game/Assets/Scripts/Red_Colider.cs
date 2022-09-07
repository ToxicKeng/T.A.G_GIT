using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Red_Colider : MonoBehaviour
{
    public float RadNum = 0f;


    public float scoreAmount;
    public float pointIncreasedPerSecond;
    public TMPro.TextMeshProUGUI scoreText;

    bool GameOver = false;

    Player RedPlayer;
    Player BluePlayer;

    void Start()
    {
        RNG();
        scoreAmount = 0f;
        pointIncreasedPerSecond = 10f;

        bool isRunning = (Random.Range(0, 1) == 1) ? true : false;

        RedPlayer = new Player("HitRed", isRunning);
        BluePlayer = new Player("HitBlue", !isRunning);
    }

    void Update()
    {
        if(!GameOver)
        {
            scoreText.text = (int)scoreAmount + "";
            scoreAmount += pointIncreasedPerSecond * Time.deltaTime;
        }

    }

    private void BluePlayerF()
    {
        RNG();
    }

    private void RedPlayerF()
    {

    }

    private void RNG()
    {

        RadNum = Random.Range(1, 3);
        Debug.Log(RadNum);
        if (RadNum == 1)
        {
            Chaser();
        }
        else
        {
            Runner();
        }

    }

    private void Chaser()
    {

    }
    private void Runner()
    {


    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "HitBlue")
        {
            Debug.Log("Taged Red");
            BluePlayer.isRunning = false;
            GameOver = false;
        }

    }

    class Player
    {
        public bool isRunning;
        public string TagName;
        public Player(string tag, bool isRunning)
        {
            TagName = tag;
            this.isRunning = isRunning;
        }
    }
}

