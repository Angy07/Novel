using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UI_ChangeItemsWindow
{
    private RectTransform _uiChangeItemsWindow;
    private Text _question;
    private Button _newItemSetBtn;

    private ToggleGroup _answerItemGroup;
    private Toggle _firstAnswer;
    private Toggle _secondAnswer;

    private int _currentItemIndex;

    public UI_ChangeItemsWindow() {

        Init();
    }

    void Init()
    {
        _uiChangeItemsWindow = GameObject.Find("UI_ChangeItems").gameObject.GetComponent<RectTransform>();
        _question = _uiChangeItemsWindow.transform.Find("Question").GetComponent<Text>();
        _answerItemGroup = _uiChangeItemsWindow.transform.Find("ToggleItemAnswerGroup").GetComponent<ToggleGroup>();
        _firstAnswer = _answerItemGroup.transform.Find("FirstAnswer").gameObject.GetComponent<Toggle>();
        _secondAnswer = _answerItemGroup.transform.Find("SecondAnswer").gameObject.GetComponent<Toggle>();
        _newItemSetBtn = _uiChangeItemsWindow.transform.Find("InputNewItemSetBtn").GetComponent<Button>();      
        _newItemSetBtn.onClick.AddListener(() => NewitemSetButtonHandler());

         Hide();
    }

    private void NewitemSetButtonHandler()
    {
        CheckToggleVariant();
        Hide();
        SceneMainController.instance.dataManager.Save(DataManager.DataTypeEnum.UserProgress);
        SceneMainController.instance.dialogueManager.DisplayNextSentence();
    }

    public void Show(string currentText, string firstAnswerText, string secondAnswerText, int itemIdex)
    {
        _question.text = currentText;
        _firstAnswer.GetComponentInChildren<Text>().text = firstAnswerText;
        _secondAnswer.GetComponentInChildren<Text>().text = secondAnswerText;
        _currentItemIndex = itemIdex;
        SceneMainController.instance.ShowPopup(_uiChangeItemsWindow);     
    }

    public void Hide()
    {
        SceneMainController.instance.HidePopup(_uiChangeItemsWindow);
    }

    private void CheckToggleVariant()
    {
        Toggle toggle = _answerItemGroup.ActiveToggles().FirstOrDefault();
        switch (toggle.name)
        {
            case "FirstAnswer":             
                break;
            case "SecondAnswer":
                for (int i = 0; i < SceneMainController.instance.dataManager.data.indexItems.Length; i++)
                {
                    
                    if (SceneMainController.instance.dataManager.data.indexItems[i] == _currentItemIndex)
                    {
                        SceneMainController.instance.dataManager.data.indexItems[i] = 0;
                    }
                    Array.Sort(SceneMainController.instance.dataManager.data.indexItems);
                }
                break;
        }   
    }

}
