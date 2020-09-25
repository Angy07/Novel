using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_FactsWindow
{
    private RectTransform _factWindow;
    private Text _factText;
    private Button _agreeFactBtn;

    public UI_FactsWindow()
    {
        Init();
    }

    void Init() //Awake()
    {
        _factWindow = GameObject.Find("UI_Facts").gameObject.GetComponent<RectTransform>();
        _factText = _factWindow.transform.Find("FactText").GetComponent<Text>();
        _agreeFactBtn = _factWindow.transform.Find("OkBtn").GetComponent<Button>();

        _agreeFactBtn.onClick.AddListener(() => AgreeButtonHandler());

        Hide();
    }

    private void AgreeButtonHandler()
    {
        Hide();
        SceneMainController.instance.dialogueManager.DisplayNextSentence();
    }

    public void Show(string currentText)
    {
        _factText.text = currentText;
        SceneMainController.instance.ShowPopup(_factWindow);
    }

    public void Hide()
    {
        SceneMainController.instance.HidePopup(_factWindow);
    }
}
