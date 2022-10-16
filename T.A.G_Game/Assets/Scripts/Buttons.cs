using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//code for UI
public class Buttons : MonoBehaviour
{
   
   
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadUI()
    {
        SceneManager.LoadScene("UI");
    }
   
}
