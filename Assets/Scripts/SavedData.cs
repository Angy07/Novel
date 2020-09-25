using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public string playerName;
    public string playerGender;

    public int currentStepIndex;
    public int currentSceneIndex;

    public bool musicIsMute;
    public bool isInputPlayerData;

    public int[] indexItems = new int[2];

    public SaveData()
    {
        musicIsMute = true;
        playerName = "Player";
        playerGender = "man";
        currentStepIndex = 0;
        isInputPlayerData = false;
        indexItems[0] = 0;
        indexItems[1] = 0;
    }
}
