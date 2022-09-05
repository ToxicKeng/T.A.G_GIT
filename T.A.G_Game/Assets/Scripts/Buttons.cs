using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ScemeManagement;

public class Buttons : MonoBehaviour
{

    public string startGame = "Game";
  public void StartGame()
    {
        SceneManager.LoadScene(startGame);
    }
}
