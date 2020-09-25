using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager
{
    public SaveData data;
    public StoryData storyData;

    private string _path;
    private string _json;
    private string _jsonURL;

    public DataManager()
    {
       
    }

    public enum DataTypeEnum
    {
        UserProgress,
        Story
    }

    public void Save(DataTypeEnum dataType)
    {
        string path = GetPath(dataType);

        _json = JsonUtility.ToJson(data);

        File.WriteAllText(path, _json);

        Debug.Log(_json + " Save json ");
    }

    public void Load(DataTypeEnum dataType)
    {
        string path = GetPath(dataType);
        bool newData = false;

        if (File.Exists(path))
        {
            _json = File.ReadAllText(path);

            if (_json == null || _json == "")
            {
                newData = true;
            }
            else
            {
                switch(dataType)
                {
                    case DataTypeEnum.UserProgress:
                        data = JsonUtility.FromJson<SaveData>(_json);
                        break;

                    case DataTypeEnum.Story:
                        storyData = JsonUtility.FromJson<StoryData>(_json);
                        break;
                }
            }
        }
        else
        {
            File.Create(path);
            newData = true;
            Debug.LogWarning("New json was creating!");         
        }
        if (newData)
        {
            data = new SaveData();
            Save(dataType);
        }
    }

    private string GetPath(DataTypeEnum dataType)
    {
        switch (dataType)
        {
            case DataTypeEnum.UserProgress:
                _jsonURL = "/savingData.json";
                _path = Application.persistentDataPath + _jsonURL;
                break;
            case DataTypeEnum.Story:
                _jsonURL = "/Story.json";
                _path = Application.dataPath + "/Resources" + _jsonURL;
                break;
        }
        return _path;
    }
}




