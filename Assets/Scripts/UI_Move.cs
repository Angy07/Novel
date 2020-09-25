using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using CodeMonkey.Utils;
using System;

[RequireComponent(typeof(Button))]
public class UI_Move : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float step;
    private float progress;

    //public GameObject go;
    public Rigidbody2D rg;
    public RectTransform image1;
    public RectTransform canvas;
    public GameObject player;
    private GameObject first;
    private Button third;
    private Button fourth;
    private Text first1;

    private Text messageText;
    private TextWriter.TextWriterSingle textWriterSingle;

    public Savet musicState = new Savet();

    public void Awake()
    {
        //GetComponent<Button>().onClick.AddListener(PlayClickSound);
        //first = player.transform.Find("first").gameObject;
        //third = first.transform.Find("second/third").GetComponent<Button>();
        //fourth = player.transform.Find("first/second/third/fourth").GetComponent<Button>();

        musicState.musicSwitch = 5;
    }

    // Start is called before the first frame update
    void Start()
    {
        rg.DOJump(new Vector2(-4.9f, -6.2f), 3, 1, 1.2f, false);

       // go.transform.DOMoveX(12.78f, 1);

        image1.DOJumpAnchorPos(new Vector2(-47.2f, -198.0f), 280f, 1, 1.0f, false);
        transform.position = startPosition;
        if (first != null && third != null && fourth != null)
        {
            Debug.Log(first);
            Debug.Log(third);
            Debug.Log(fourth);
            Debug.Log("Hello!");

            //PlayerPrefs.SetString("Savet", JsonUtility.ToJson(musicState));
        }      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(startPosition, endPosition, progress);
        progress += step;


    }

    public void PlayClickSound()
    {
        Debug.Log("PlayClickSound");
    }
}

[Serializable]
public class Savet
{
    public int musicSwitch;

    public void SetMusicSwitch(int musicSwitch)
    {
        this.musicSwitch = musicSwitch;
    }

    public int GetMusicSwitch()
    {
        return musicSwitch;
    }
}
