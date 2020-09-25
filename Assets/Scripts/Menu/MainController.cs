using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public DataManager dataManager;
    public SoundManager soundManager;
    public UI_MenuManager uI_MenuManager;

    public static MainController instance;

    private void Awake()
    {
        instance = this;

        dataManager = new DataManager();
        dataManager.Load(DataManager.DataTypeEnum.UserProgress);
        soundManager = new SoundManager();
        uI_MenuManager = new UI_MenuManager();
    }

    void OnApplicationQuit()
    {
        dataManager.Save(DataManager.DataTypeEnum.UserProgress);
    }
}
