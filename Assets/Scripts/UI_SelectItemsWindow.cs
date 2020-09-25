using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SelectItemsWindow
{
    private RectTransform _windowSelectItem;

    private RectTransform _toggleManItemsGroup;
    private Toggle _notebook;
    private Toggle _knife;
    private Toggle _axe;

    private RectTransform _toggleWomanItemsGroup;
    private Toggle _pen;
    private Toggle _amulet;
    private Toggle _grenade;

    private Button _selectItemsBtn;

    private int _indexPlayerItem1;
    private int _indexPlayerItem2;

    private string _playerGender;

    public UI_SelectItemsWindow()
    {
        Init();
    }

    void Init() //Awake()
    {
        _windowSelectItem = GameObject.Find("UI_SelectItems").gameObject.GetComponent<RectTransform>();

        _toggleManItemsGroup = GameObject.Find("ToggleManItems").gameObject.GetComponent<RectTransform>();
        _notebook = GameObject.Find("Notebook").gameObject.GetComponent<Toggle>();
        _knife = GameObject.Find("Knife").gameObject.GetComponent<Toggle>();
        _axe = GameObject.Find("Axe").gameObject.GetComponent<Toggle>();

        _toggleWomanItemsGroup = GameObject.Find("ToggleWomanItems").gameObject.GetComponent<RectTransform>();
        _pen = GameObject.Find("Pen").gameObject.GetComponent<Toggle>();
        _amulet = GameObject.Find("Amulet").gameObject.GetComponent<Toggle>();
        _grenade = GameObject.Find("Grenade").gameObject.GetComponent<Toggle>();

        _selectItemsBtn = GameObject.Find("SelectItemsBtn").gameObject.GetComponent<Button>();

        _notebook.onValueChanged.AddListener((value) => 
        {          
            CheckToggle(value, PlayerItemsEnum.Notebook);
        });

        _knife.onValueChanged.AddListener((value) =>
        {
            CheckToggle(value, PlayerItemsEnum.Knife);
        });

        _axe.onValueChanged.AddListener((value) =>
        {
            CheckToggle(value, PlayerItemsEnum.Axe);
        });

        _pen.onValueChanged.AddListener((value) =>
        {
            CheckToggle(value, PlayerItemsEnum.Pen);
        });

        _amulet.onValueChanged.AddListener((value) =>
        {
            CheckToggle(value, PlayerItemsEnum.Amulet);
        });

        _grenade.onValueChanged.AddListener((value) =>
        {
            CheckToggle(value, PlayerItemsEnum.Grenade);
        });

        _selectItemsBtn.onClick.AddListener(() => SaveSelectedItem());

        _indexPlayerItem1 = 0;
        _indexPlayerItem2 = 0;

        _playerGender = SceneMainController.instance.dataManager.data.playerGender;

        CheckGender();
        Hide();
    }

    private void CheckGender()
    {
        if (_playerGender == "man")
        {
            _toggleWomanItemsGroup.gameObject.SetActive(false);
            _toggleManItemsGroup.gameObject.SetActive(true);
        }
        if (_playerGender == "woman")
        {
            _toggleManItemsGroup.gameObject.SetActive(false);
            _toggleWomanItemsGroup.gameObject.SetActive(true);
        }
    }

    public enum PlayerItemsEnum
    {
         Notebook = 1,
         Knife,
         Axe,
         Pen,
         Amulet,
         Grenade
    }

    private void CheckToggle(bool value, PlayerItemsEnum item)
    {
        if (value)
        {
            SwitchItem(item);
        }
        else
        {
           TurnOffItemToggle(item);
        }                  
    }

    private void SwitchItem(PlayerItemsEnum item)
    {
        if (_indexPlayerItem1 == 0)
        {
            _indexPlayerItem1 = (int)item;
        }
    

        else if (_indexPlayerItem2 == 0)
        {
            _indexPlayerItem2 = (int)item;
        }

        else
        {
            switch (_indexPlayerItem1)
            {
                case (int)PlayerItemsEnum.Notebook:                   
                    _notebook.isOn = false;
                    break;
                case (int)PlayerItemsEnum.Knife:
                    _knife.isOn = false;
                    break;
                case (int)PlayerItemsEnum.Axe:
                    _axe.isOn = false;
                    break;

                case (int)PlayerItemsEnum.Pen:
                    _pen.isOn = false;
                    break;
                case (int)PlayerItemsEnum.Amulet:
                    _amulet.isOn = false;
                    break;
                case (int)PlayerItemsEnum.Grenade:
                    _grenade.isOn = false;
                    break;
            }
            _indexPlayerItem1 = (int)item;
        }
    }

    private void TurnOffItemToggle(PlayerItemsEnum item)
    {
        if (_indexPlayerItem1 == (int)item)
        {
            _indexPlayerItem1 = 0;
        }
        if (_indexPlayerItem2 == (int)item)
        {
            _indexPlayerItem2 = 0;
        }
    }

    private void SaveSelectedItem()
    {
        Hide();

        SceneMainController.instance.dataManager.data.indexItems[0] = _indexPlayerItem1;
        SceneMainController.instance.dataManager.data.indexItems[1] = _indexPlayerItem2;
        Array.Sort(SceneMainController.instance.dataManager.data.indexItems);

        SceneMainController.instance.dataManager.Save(DataManager.DataTypeEnum.UserProgress);
        SceneMainController.instance.dialogueManager.DisplayNextSentence();
    }

    public void Show()
    {
        _playerGender = SceneMainController.instance.dataManager.data.playerGender;
        CheckGender();
        SceneMainController.instance.ShowPopup(_windowSelectItem);
    }

    public void Hide()
    {
        SceneMainController.instance.HidePopup(_windowSelectItem);
    }
}
