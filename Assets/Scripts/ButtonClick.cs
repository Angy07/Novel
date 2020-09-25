using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonClick : MonoBehaviour
{
    private static bool stateBtn = true;

    public void Awake()
    {
        GetComponent<Button>().onClick.AddListener(PlayClickSound);
    }

    public void PressOn()
    {
        stateBtn = true;
    }

    public void PressOff()
    {
        stateBtn = false;
    }

    public void PlayClickSound()
    {
        if (stateBtn == false)
        {
            GameObject.Find("AudioSource").GetComponent<AudioSource>().Pause();        
        }
        if (stateBtn == true)
        {
            GameObject.Find("AudioSource").GetComponent<AudioSource>().Play();
        }
    }
}
