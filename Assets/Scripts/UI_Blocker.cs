using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Blocker
{ 
    private GameObject _uiBlocker;

    public UI_Blocker()
    {
        Init();
    }

    private void Init() //Awake
    {
        _uiBlocker = GameObject.Find("UI_Blocker");

        HideUiBlocker();
    }

    public void ShowUiBlocker()
    {
        _uiBlocker.SetActive(true);
    }

    public void HideUiBlocker()
    {
        _uiBlocker.SetActive(false);
    }
}
