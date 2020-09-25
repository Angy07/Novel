using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;
using DG.Tweening;

public class UI_NameGenderInputWindow
{
    private TMP_InputField _inputFieldPlayerName;
    private ToggleGroup _toggleGenderGroup;
    private Button _dataPlayerBtn;

    private RectTransform _windowPlayerData;

    private string _validCharacters = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ0123456789";

    private int _characterLimit = 14;

    public UI_NameGenderInputWindow()
    {
        Init();
    }

    //OnEnable

    private void Init() //Awake
    {

        _windowPlayerData = GameObject.Find("UI_NameInputWindow").gameObject.GetComponent<RectTransform>();
        _inputFieldPlayerName = GameObject.Find("InputPlayerName").gameObject.GetComponent<TMP_InputField>();
        _toggleGenderGroup = GameObject.Find("ToggleGenderGroup").gameObject.GetComponent<ToggleGroup>();
        _dataPlayerBtn = GameObject.Find("InputNameGenderBtn").gameObject.GetComponent<Button>();

        PlayerNameInputField();

        _dataPlayerBtn.onClick.AddListener(() => PlayerInputedData());

        Hide();
    }

    private void PlayerNameInputField()
    {
        _inputFieldPlayerName.characterLimit = _characterLimit;
        _inputFieldPlayerName.onValidateInput = (string text, int charIndex, char addedChar) =>
        {
            return ValidateChar(_validCharacters, addedChar);
        };
    }

    private void PlayerInputedData()
    {
        SceneMainController.instance.dataManager.data.playerName = _inputFieldPlayerName.text;
        CheckToggle();
    }

    private  void CheckToggle()
    {      
        Toggle toggle = _toggleGenderGroup.ActiveToggles().FirstOrDefault();   
        switch (toggle.name)
        {
            case "Woman":
                SceneMainController.instance.dataManager.data.playerGender = "woman";
                break;
            case "Man":
                SceneMainController.instance.dataManager.data.playerGender = "man";
                break;
        }

        if(_inputFieldPlayerName != null && _inputFieldPlayerName.text != "")
        {
            Hide();

            //Debug.Log(SceneMainController.instance.dataManager.data.playerName);
            //Debug.Log(SceneMainController.instance.dataManager.data.playerGender);

            SceneMainController.instance.dataManager.data.isInputPlayerData = true;
           
            SceneMainController.instance.dataManager.Save(DataManager.DataTypeEnum.UserProgress);
            SceneMainController.instance.dialogueManager.DisplayNextSentence();        
        }    
    }

    private char ValidateChar(string validCharacters, char addedChar)
    {
        if (validCharacters.IndexOf(addedChar) != -1)
        {
            return addedChar;
        }
        else
        {
            return '\0';
        }      
    }

    public void Show()
    {       
        SceneMainController.instance.ShowPopup(_windowPlayerData);  
    }

    public void Hide()
    {
        SceneMainController.instance.HidePopup(_windowPlayerData);
    }

}
