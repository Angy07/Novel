using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class UI_MainMenuPage : Page
{
    private Button _newGameBtn;
    private Button _optionsBtn;
    private Button _exitBtn;
    private Button _continueBtn;

    private DataManager _dataManager;
    private SoundManager _soundManager;

    public UI_MainMenuPage()
    {
        _dataManager = MainController.instance.dataManager;
        _soundManager = MainController.instance.soundManager;

        Init();
    }

    public override void Init()
    {
        prefab = GameObject.Find("ButtonsMenu").gameObject;
        _newGameBtn = prefab.transform.Find("NewGame").GetComponent<Button>();
        _optionsBtn = prefab.transform.Find("Options").GetComponent<Button>();
        _exitBtn = prefab.transform.Find("Exit").GetComponent<Button>();
        _continueBtn = prefab.transform.Find("Continue").GetComponent<Button>();

        _newGameBtn.onClick.AddListener(() => NewGameHandler());
        _optionsBtn.onClick.AddListener(() => OptionsHandler());
        _exitBtn.onClick.AddListener(() => ExitHandler());
        _continueBtn.onClick.AddListener(() => ContinueHandler());

        base.Init();
    }

    private void NewGameHandler()
    {
        _dataManager.data.currentSceneIndex = 0;
        _dataManager.data.currentStepIndex = 0;
        _dataManager.data.isInputPlayerData = false;
        _dataManager.Save(DataManager.DataTypeEnum.UserProgress); // save
        _soundManager.PlaySound();
        SceneManager.LoadScene("FirstScene");
    }

    private void OptionsHandler()
    {
        _soundManager.PlaySound();
        MainController.instance.uI_MenuManager.ShowPage(UI_MenuManager.PagesEnum.ui_MenuOption);
    }

    private void ExitHandler()
    {
        _soundManager.PlaySound();
        MainController.instance.uI_MenuManager.ShowPage(UI_MenuManager.PagesEnum.ui_MenuExit);
    }

    private void ContinueHandler()
    {
        _dataManager.Save(DataManager.DataTypeEnum.UserProgress); // save
        _soundManager.PlaySound();
        SceneManager.LoadScene("FirstScene");
    }
}

