using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SoundManager
{   
    private GameObject _musicPrefab;
    private AudioSource _buttonClick;
    private AudioSource _musicMenu;

    public bool isMute;

    public SoundManager()
    {
        Init();
    }
    
    public void Init()
    {
        _musicPrefab = GameObject.Find("SoundManager").gameObject;
        _buttonClick = _musicPrefab.transform.Find("ButtonClickSound").GetComponent<AudioSource>();
        _musicMenu = _musicPrefab.transform.Find("Music").GetComponent<AudioSource>();
  
        isMute = MainController.instance.dataManager.data.musicIsMute;

        PlayMusic();       
    }

    public void PlaySound()
    {
        if (!isMute)
        {
            _buttonClick.Play();          
        }
    }

    public void PlayMusic()
    {
        if (!isMute)
        {
            _musicMenu.Play();
         
        } else
            _musicMenu.Pause();         
    }    
}


