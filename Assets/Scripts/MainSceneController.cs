using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using DG.Tweening;
using System.IO;
using LitJson;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneController : MonoBehaviour
{
    private string jsonString;
    private JsonData itemData; 
    public GameObject mainSceneCotroller;

    public static MainSceneController instance;

    public void Awake()
    {
        instance = this;
    }

    private void InitJson()
    {
        jsonString = File.ReadAllText(Application.dataPath + "/Resources/json1.json");
        itemData = JsonMapper.ToObject(jsonString);
    }

    public string[] GetReplics(string sceneName, string character, string appear)
    {
        InitJson();

        int replicsCount = itemData[sceneName]["characters"][character]["replics"][appear].Count;
        string[] messageArray1 = new string[replicsCount];

        for (int i = 0; i < replicsCount; i++)
        {
            messageArray1[i] = (string)itemData[sceneName]["characters"][character]["replics"][appear][i];
        }
        return messageArray1;
    }

    public string GetCharcterName(string sceneName, string character)
    {
        InitJson();
        string characterName = (string)itemData[sceneName]["characters"][character]["name"];
        return characterName;
    }

    public void SceneObjectAppear(RectTransform background, RectTransform backgroundHeader, RectTransform speaker, Text speakerName)
    {
        DOTween.SetTweensCapacity(500, 125);
        background.DOJumpAnchorPos(new Vector2(0.0f, -28.2f), 280f, 1, 1.0f, false);
        backgroundHeader.DOJumpAnchorPos(new Vector2(0.0f, -60.0f), 280f, 1, 1.0f, false);
        speaker.DOAnchorPos(new Vector2(339.0f, 436.2f), 1.2f, false);      
    }

    public void SceneObjectAppear(RectTransform dialogueSystem, RectTransform speaker)
    {
        DOTween.SetTweensCapacity(500, 125);  
        dialogueSystem.DOJumpAnchorPos(new Vector2(0f, 143f), 280f, 1, 1.0f, false);       
        speaker.DOAnchorPos(new Vector2(339.0f, 460f), 1.2f, false);
    }

}
