using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{

    [Header("Buttons")]

    public GameObject ButtonsOption;
    public GameObject ButtonsExitConfirm;
    public GameObject ButtonNewGame;

    [Header("SOunds")]
    public Object[] objects;
        
    public GameObject ButtonExit;
    public GameObject ButtonOption;


    public void ShowExitButtons()
    {
        ButtonsOption.SetActive(false);
        ButtonsExitConfirm.SetActive(true);
        ButtonNewGame.SetActive(false);
        ButtonExit.SetActive(false);
        ButtonOption.SetActive(false);
    }

    public void ShowOptionsButtons()
    {
        ButtonsOption.SetActive(true);
        ButtonsExitConfirm.SetActive(false);
        ButtonNewGame.SetActive(false);
        ButtonExit.SetActive(false);
        ButtonOption.SetActive(false);
    }

    public void Exit()
    {
        //Application.Quit();
        Debug.Log("Out");
    }

    public void Play()
    {
        SceneManager.LoadScene("First");
    }

    public void BackInMenu()
    {
        // SceneManager.LoadScene("Menu");
        ButtonsOption.SetActive(false);
        ButtonsExitConfirm.SetActive(false);
        ButtonNewGame.SetActive(true);
        ButtonExit.SetActive(true);
        ButtonOption.SetActive(true);
    }
}
