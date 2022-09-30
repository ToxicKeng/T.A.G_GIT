using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static bool GameEnded = false;
    public GameObject GameEndUI;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.tag = "Player";
            collision.gameObject.tag = "Tagged";
            Debug.Log("Game ended");
            GameEnded = true;
        }
    }
    void Update()
    {
        if (GameEnded == true)
        {
            EndGame();
        }
    }
    void EndGame()
    {
        GameEndUI.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void MainMenu()
    {
        GameEnded = false;
        SceneManager.LoadScene("UI");
        
    }
    public void Restart()
    {
        MainMenu();
        SceneManager.LoadScene("Game");
    }

}
