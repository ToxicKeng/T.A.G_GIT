using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//code for the pause menu
public class Pause : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject PauseUI;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }
    void PauseGame()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void MapSelect()
    {

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("UI");
    }
}
