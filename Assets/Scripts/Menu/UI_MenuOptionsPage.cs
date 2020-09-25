using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_MenuOptionsPage : Page
{
    private Button _backToMenuBtn;

    private Sprite _onMusic, _offMusic;
    private Image _spriteChange;
 
    private Button _musicBtn;

    private DataManager _dataManager;
    private SoundManager _soundManager;

    public UI_MenuOptionsPage()
    {
        _dataManager = MainController.instance.dataManager;
        _soundManager = MainController.instance.soundManager;

        Init();
    }

    public override void Init()
    {
        prefab = GameObject.Find("ButtonsOptions").gameObject;
        _backToMenuBtn = prefab.transform.Find("Menu").GetComponent<Button>();     

        _musicBtn = prefab.transform.Find("MusicButton").GetComponent<Button>();

        _spriteChange = GameObject.Find("MusicButton").GetComponent<Image>();
        _onMusic = Resources.Load<Sprite>("VioletCircleMusic");
        _offMusic = Resources.Load<Sprite>("VioletCircleMusicOff");

        _backToMenuBtn.onClick.AddListener(() => BackToMenuButtonHandler());
        _musicBtn.onClick.AddListener(() => MusicButtonHandlerBtn());

        base.Init();

        CheckSprite();
    }

    private void BackToMenuButtonHandler()
    {                
        _soundManager.PlaySound();
        MainController.instance.uI_MenuManager.ShowPage(UI_MenuManager.PagesEnum.ui_MainMenu);
    }

    private void MusicButtonHandlerBtn()
    {
        if (_soundManager.isMute)
        {
            _soundManager.isMute = false;
            _soundManager.PlayMusic();
            _soundManager.PlaySound();

            _spriteChange.sprite = _onMusic;
            _dataManager.data.musicIsMute = _soundManager.isMute;
        }
        else
        {
            _soundManager.isMute = true;
            _soundManager.PlayMusic();
          
            _spriteChange.sprite = _offMusic;
            _dataManager.data.musicIsMute = _soundManager.isMute;
        }
    }

    private void CheckSprite()
    {
        if (_soundManager.isMute)
        {           
            _spriteChange.sprite = _offMusic;
        }
        else
        {   
            _spriteChange.sprite = _onMusic;
        }
    }
}
