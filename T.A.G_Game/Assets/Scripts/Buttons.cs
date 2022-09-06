using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadSettings()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void LoadQuit()
    {
        Debug.Log("Quit");
    }
}
