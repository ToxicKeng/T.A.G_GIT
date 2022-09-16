using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMap : MonoBehaviour
{
    public static bool SelectingMap = false;
    public GameObject SelcectMapUI;
    public GameObject BlueMapping;
    public GameObject RedMapping;
    public GameObject BlackMapping;
    private void Start()
    {
        SelcectMapUI.SetActive(true);
        Time.timeScale = 0f;
        SelectingMap = true;
    }
    public void BlueMap()
    {
        SelcectMapUI.SetActive(false);
        BlueMapping.SetActive(true);
        RedMapping.SetActive(false);
        BlackMapping.SetActive(false);
        Time.timeScale = 1f;
        SelectingMap = false;

    }
    public void RedMap()
    {
        SelcectMapUI.SetActive(false);
        BlueMapping.SetActive(false);
        RedMapping.SetActive(true);
        BlackMapping.SetActive(false);
        Time.timeScale = 1f;
        SelectingMap = false;
    }
    public void BlackMap()
    {
        SelcectMapUI.SetActive(false);
        BlueMapping.SetActive(false);
        RedMapping.SetActive(false);
        BlackMapping.SetActive(true);
        Time.timeScale = 1f;
        SelectingMap = false;
    }

}
