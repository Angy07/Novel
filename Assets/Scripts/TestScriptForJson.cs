using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class TestScriptForJson : MonoBehaviour
{
    public StoryData testJson;
    public StoryData testJson2;
    private string _json;
    //public List<StoryData> steps;
    TextAsset text;

    public void Load()
    {
        text = new TextAsset();
        string path = @"E:/Angy/Myjson.json";
        //string path = Application.persistentDataPath + "/savingData.json";

        if (File.Exists(path))
        {
            _json = File.ReadAllText(path);
            Debug.Log(_json);

            if (_json == null || _json == "")
            {
                Debug.Log("nothing");
            }
            else
                Debug.Log(Application.persistentDataPath);

           // TextAsset asset = Resources.Load("Myjson") as TextAsset;
            testJson = JsonUtility.FromJson<StoryData>(_json);
           // TextAsset text = new TextAsset();
           // AssetDatabase.CreateAsset(text, Application.persistentDataPath + "/Myjson.json");
           // testJson2 = JsonUtility.FromJson<StoryData>(text.text);


            if (testJson != null)
            {
                Debug.Log("not null");
            }
        }
        else
        {
            Debug.Log("can not find file");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Load();
        Debug.Log("How are you?");

        
       //foreach(Step step in testJson.scenes[0].steps)
       // {
       //     Debug.Log(step.text);
         
       // }

        Debug.Log(testJson.scenes[1-1].steps[4].text);
        Debug.Log(Application.persistentDataPath);
   
        // Debug.Log(testJson.id);
    }


}

