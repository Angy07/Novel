using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using CodeMonkey;
using DG.Tweening;
using System.IO;
using LitJson;
using UnityEngine.SceneManagement;

[Serializable]
public class Conversation : MainSceneController
{
    private Text messageTextStart;
    private float timer = 0;

    private Text messageText;
    private TextWriter.TextWriterSingle textWriterSingle;
    private string playerName;

    public RectTransform background;
    public RectTransform backgroundHeader;
    public RectTransform speaker;
    public Text speakerName;

    protected int currentSceneIndex;
    protected Button backToMenuBtn;

    public void Show()
    {
        //UI_Blocker.ShowUiBlocker();
        UI_NameInputWindow.Show_Static("Как тебя зовут?", "", "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ0123456789", 14,
        () =>
        {
            //Cancel            
            //UI_Blocker.HideUiBlocker();
        },
        (string nameText) =>
        {
            //Ok
            //UI_Blocker.HideUiBlocker();
            playerName = nameText;
       
            Debug.Log(playerName);
          
        });
    }

    private void Awake()
    {
        backToMenuBtn = mainSceneCotroller.transform.Find("Canvas").Find("Menu").GetComponent<Button>();
        Debug.Log(backToMenuBtn + " 1");

        messageText = transform.Find("message/background").Find("messageText").GetComponent<Text>();
        string message = "_";
        int i = 0;

        transform.Find("message").GetComponent<Button_UI>().ClickFunc = () =>
        {
            if (textWriterSingle != null && textWriterSingle.IsActive())
            {
                // Currently active TextWriter
                textWriterSingle.WriteAllAndDestroy();
                i--;
            }
            else
            { 
                string[] messageArray = base.GetReplics("scene1", "robert", "1appear");

                if (i < messageArray.Length)
                {
                    message = messageArray[i];
                    textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .05f, true, true);                
                }
                else
                {
                    textWriterSingle = TextWriter.AddWriter_Static(messageText, "-", .05f, true, true);
                }
                
            }
            if (message == "Кто ты? Можешь назвать свое имя?")
            {
                Show();
            }
            i++;
        };      
    }

    private void Start()
    {
        Debug.Log(backToMenuBtn);
        backToMenuBtn.onClick.AddListener(() => LoadMainMenu());
        SceneObjectAppear(background, backgroundHeader, speaker, speakerName);
        speakerName.text = base.GetCharcterName("scene1", "robert");       
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1.3f && timer <= 1.9f)
        {       
            messageTextStart = transform.Find("message/background").Find("messageText").GetComponent<Text>();
            messageTextStart.text = "Не может быть!";
            messageTextStart.color = new Color(0, 0, 0, 0);
            messageTextStart.DOColor(new Color(0, 0, 0, 1), 0.6f);
        }
    }

    public void LoadMainMenu()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        SceneManager.LoadScene(0);
    }
}
