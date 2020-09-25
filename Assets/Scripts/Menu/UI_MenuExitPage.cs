using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MenuExitPage : Page
{
    private Button _confirmExitTrue;
    private Button _confirmExitFalse;

    public UI_MenuExitPage()
    {
        Init();
    }

    public override void Init()
    {
        prefab = GameObject.Find("ButtonsExit").gameObject;
        _confirmExitTrue = prefab.transform.Find("TrueExit").GetComponent<Button>();
        _confirmExitFalse = prefab.transform.Find("FalseExit").GetComponent<Button>();

        _confirmExitTrue.onClick.AddListener(() => ExitTrueHandler());
        _confirmExitFalse.onClick.AddListener(() => ExitFalseHandler());

        base.Init();
    }

    private void ExitTrueHandler()
    {
        MainController.instance.soundManager.PlaySound();
        //Application.Quit();
        Debug.Log("Out");
    }

    private void ExitFalseHandler()
    {
        MainController.instance.soundManager.PlaySound();
        MainController.instance.uI_MenuManager.ShowPage(UI_MenuManager.PagesEnum.ui_MainMenu);
    }
}
