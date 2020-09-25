using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using LitJson;

public class UI_MenuManager
{
    private Page _currentPage;

    private Page _menuOptionsPage;
    private Page _menuExitPage;
    private Page _mainMenuPage;

    public UI_MenuManager()
    {
        Init();
    }

    public enum PagesEnum
    {
        ui_MenuOption,
        ui_MenuExit,
        ui_MainMenu
    }

    public void Init()
    {
        _menuOptionsPage = new UI_MenuOptionsPage();
       _menuExitPage = new UI_MenuExitPage();
       _mainMenuPage = new UI_MainMenuPage();
        
        _currentPage = _mainMenuPage;
        _currentPage.Show();
    }

    public void ShowPage(PagesEnum page)
    {
        _currentPage.Hide();
        
        switch (page)
        {
            case PagesEnum.ui_MenuOption:
                _currentPage = _menuOptionsPage;
                break;
            case PagesEnum.ui_MenuExit:
                _currentPage = _menuExitPage;
                break;
            case PagesEnum.ui_MainMenu:
                _currentPage = _mainMenuPage;
                break;
        }
            _currentPage.Show();
    }
}

