using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControlScript : MonoBehaviour
{
    private Transform _sceneBackground1;
    private Transform _sceneBackground2;

    private SpriteRenderer _mainBackgroundPicture;

    private Sprite _backgroundHouse; 
    private Sprite _backgroundFindObject;

    private string _currentBackground;

    void Start()
    {
        _sceneBackground1 = GameObject.Find("SceneBackground1").gameObject.GetComponent<Transform>();
        _sceneBackground2 = GameObject.Find("SceneBackground2").gameObject.GetComponent<Transform>();

        _mainBackgroundPicture = GameObject.Find("SceneBackgroundPicture").gameObject.GetComponent<SpriteRenderer>();
        _backgroundHouse = Resources.Load<Sprite>("Background3/ВackgroundHouse");
        _backgroundFindObject = Resources.Load<Sprite>("Background3/BackgroundFindObject");

        _sceneBackground1.gameObject.SetActive(false);
        _currentBackground = " _sceneBackground1";
    }

 
    public void Swow(string  first)
    {
        _sceneBackground1.gameObject.SetActive(true);
    }

    public void Hide()
    {
        _sceneBackground1.gameObject.SetActive(false);
    }



}
