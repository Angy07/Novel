using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleScript : MonoBehaviour
{
    private GameObject change;
    private GameObject save;

    public DataManager manager;

    public bool mute;

    private Toggle _musicToggle;

    void Start()
    {
        change = GameObject.Find("Change").gameObject;
        save = GameObject.Find("Save").gameObject;

        _musicToggle = GameObject.Find("MusicToggle").GetComponent<Toggle>();

        
        _musicToggle.onValueChanged.AddListener(delegate {
            MusicButtonHandler();
        });


        manager.Load(DataManager.DataTypeEnum.UserProgress);
        mute = manager.data.musicIsMute;
        if(mute)
        {
            Debug.Log(manager.data.musicIsMute + " Simple Scene musicIsMute was true");
            MusicButtonHandler();

            mute = false;
            manager.data.musicIsMute = mute;

            Debug.Log(manager.data.musicIsMute + " Simple Scene musicIsMute now false");
        }
        else if (!mute)
        {
            Debug.Log(manager.data.musicIsMute + " Simple Scene musicIsMute was false");
            MusicButtonHandler();

            mute = true;
            manager.data.musicIsMute = mute;

            Debug.Log(manager.data.musicIsMute + " Simple Scene musicIsMute now true");
            // _musicToggle.isOn = true;

        }
    }

    public void OnButtonClick()
    {
        Debug.Log("Button is pressed Save!");
        manager.data.musicIsMute = mute;
       // manager.Save();
    }

    public void MusicButtonHandler()
    {
        if (mute)
        {
            _musicToggle.isOn = false;
            Debug.Log("I am FALSE" + "  " + _musicToggle.isOn);
           mute = false;
           // manager.data.musicIsMute = mute;
        } else
        if (!mute)
        {
            _musicToggle.isOn = true;
            Debug.Log("I am TRUE" + "  " + _musicToggle.isOn);
            mute = true;
            //manager.data.musicIsMute = mute;
        }

        //if (_musicToggle)
        //{
        //    Debug.Log("I am TRUE" + "  " + _musicToggle.isOn);
        //}
        //if (!_musicToggle)
        //{
        //    Debug.Log("I am FALSE" + "  " + _musicToggle.isOn);
        //}
    }

    void Update()
    {
        
    }
}
