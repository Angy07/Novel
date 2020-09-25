using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using CodeMonkey;


public class UI_Testing : MonoBehaviour
{
    [SerializeField] private UI_NameInputWindow nameInputWindow;
   
    private string playerName;
    private string gender;

    public void Show()
    {
        //UI_Blocker.ShowUiBlocker();
        UI_NameInputWindow.Show_Static("Как тебя зовут?", "", "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ0123456789", 14,           
        () => {
            //Cancel            
            //UI_Blocker.HideUiBlocker(); 
        },
        (string nameText) => {
            //Ok
            //UI_Blocker.HideUiBlocker();
            playerName = nameText;
            Debug.Log(playerName);
        });
    }
}
