//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
//using System.IO;
//using LitJson;

//public class NewBehaviourScipt : MonoBehaviour
//{
//    public GameObject menuManager;
//    protected RectTransform mainMenuButtons;
//    protected RectTransform optionButtons;
//    protected RectTransform exitButtons;

//    protected Button newGameBtn;
//    protected Button optionsBtn;
//    protected Button exitBtn;
//    protected Button continueBtn;

//    protected Button backToMenuBtn;
//    protected Button musicBtn;

//    protected Button confirmExitTrue;
//    protected Button confirmExitFalse;

//    private AudioSource buttonClick;
//    private AudioSource musicMenu;

//    private Image spriteChange;
//    private Sprite musicOnSprite, musicOffSprite;

//    private int sceneToContinue;

//    public Save musicState = new Save();

//    private void Awake()
//    {
//        mainMenuButtons = menuManager.transform.Find("Canvas/Panel/ButtonsMenu").GetComponent<RectTransform>();
//        optionButtons = menuManager.transform.Find("Canvas/Panel").Find("ButtonsOptions").GetComponent<RectTransform>();
//        exitButtons = menuManager.transform.Find("Canvas/Panel").Find("ButtonsExit").GetComponent<RectTransform>();

//        newGameBtn = menuManager.transform.Find("Canvas/Panel/ButtonsMenu").Find("NewGame").GetComponent<Button>();
//        optionsBtn = menuManager.transform.Find("Canvas/Panel/ButtonsMenu").Find("Options").GetComponent<Button>();
//        exitBtn = menuManager.transform.Find("Canvas/Panel/ButtonsMenu").Find("Exit").GetComponent<Button>();
//        continueBtn = menuManager.transform.Find("Canvas/Panel/ButtonsMenu").Find("Continue").GetComponent<Button>();

//        backToMenuBtn = menuManager.transform.Find("Canvas/Panel/ButtonsOptions").Find("Menu").GetComponent<Button>();
//        musicBtn = menuManager.transform.Find("Canvas/Panel/ButtonsOptions").Find("MusicButton").GetComponent<Button>();

//        confirmExitTrue = menuManager.transform.Find("Canvas/Panel/ButtonsExit").Find("True").GetComponent<Button>();
//        confirmExitFalse = menuManager.transform.Find("Canvas/Panel/ButtonsExit").Find("False").GetComponent<Button>();

//        buttonClick = menuManager.transform.Find("ButtonClickSound").GetComponent<AudioSource>();
//        musicMenu = menuManager.transform.Find("Music").GetComponent<AudioSource>();

//        spriteChange = menuManager.transform.Find("Canvas/Panel/ButtonsOptions").Find("MusicButton").GetComponent<Image>();
//        musicOnSprite = Resources.Load<Sprite>("VioletCircleMusic");
//        musicOffSprite = Resources.Load<Sprite>("VioletCircleMusicOff");
//        CheckKey();
//    }

//    public void Start()
//    {
//        // PlayerPrefs.DeleteKey("Save");
//        if (!PlayerPrefs.HasKey("Save"))
//        {
//            spriteChange.sprite = musicOnSprite;
//            ClickSoundPlay();
//            //T();
//        }
//        else
//        {
//            musicState = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("Save"));
//            MusicState(musicState.musicSwitch);
//        }

//    }

//    public void CheckKey()
//    {
//        musicState.musicSwitch = 1;
//        Debug.Log(musicState.musicSwitch);
//    }

//    public void MusicControl()
//    {
//        if (spriteChange.sprite == musicOnSprite)
//        {
//            spriteChange.sprite = musicOffSprite;
//            musicMenu.Pause();
//            ClickSoundStop();
//        }
//        else if (spriteChange.sprite == musicOffSprite)
//        {
//            spriteChange.sprite = musicOnSprite;
//            musicMenu.Play();
//            ClickSoundPlay();
//        }
//    }

//    public void Show(Button btn)
//    {
//        if (btn == optionsBtn)
//        {
//            OptionsOpen();
//        }

//        if (btn == exitBtn)
//        {
//            ExitOpen();
//        }

//        if (btn == backToMenuBtn)
//        {
//            OptionsClose();
//        }

//        if (btn == confirmExitFalse)
//        {
//            ExitClose();
//        }

//        if (btn == newGameBtn)
//        {
//            Debug.Log(musicState.musicSwitch);
//            PlayerPrefs.SetString("Save", JsonUtility.ToJson(musicState));
//            SceneManager.LoadScene("First");
//        }

//        if (btn == confirmExitTrue)
//        {
//            //Application.Quit();
//            Debug.Log("Out");
//        }

//        if (btn == musicBtn)
//        {
//            MusicControl();
//        }

//        if (btn == continueBtn)
//        {
//            ContinueGame();
//        }
//    }

//    private void OptionsOpen()
//    {
//        mainMenuButtons.gameObject.SetActive(false);
//        optionButtons.gameObject.SetActive(true);
//    }

//    private void ExitOpen()
//    {
//        mainMenuButtons.gameObject.SetActive(false);
//        exitButtons.gameObject.SetActive(true);
//    }

//    private void OptionsClose()
//    {
//        optionButtons.gameObject.SetActive(false);
//        mainMenuButtons.gameObject.SetActive(true);
//    }

//    private void ExitClose()
//    {
//        exitButtons.gameObject.SetActive(false);
//        mainMenuButtons.gameObject.SetActive(true);
//    }

//    private void ClickSoundPlay()
//    {
//        newGameBtn.onClick.AddListener(() => buttonClick.Play());
//        optionsBtn.onClick.AddListener(() => buttonClick.Play());
//        exitBtn.onClick.AddListener(() => buttonClick.Play());
//        continueBtn.onClick.AddListener(() => buttonClick.Play());

//        musicBtn.onClick.AddListener(() => buttonClick.Play());
//        backToMenuBtn.onClick.AddListener(() => buttonClick.Play());

//        confirmExitTrue.onClick.AddListener(() => buttonClick.Play());
//        confirmExitFalse.onClick.AddListener(() => buttonClick.Play());
//    }

//    private void ClickSoundStop()
//    {
//        newGameBtn.onClick.AddListener(() => buttonClick.Stop());
//        optionsBtn.onClick.AddListener(() => buttonClick.Stop());
//        exitBtn.onClick.AddListener(() => buttonClick.Stop());
//        continueBtn.onClick.AddListener(() => buttonClick.Stop());

//        musicBtn.onClick.AddListener(() => buttonClick.Stop());
//        backToMenuBtn.onClick.AddListener(() => buttonClick.Stop());

//        confirmExitTrue.onClick.AddListener(() => buttonClick.Stop());
//        confirmExitFalse.onClick.AddListener(() => buttonClick.Stop());
//    }

//    private void ContinueGame()
//    {
//        sceneToContinue = PlayerPrefs.GetInt("SavedScene");
//        if (sceneToContinue != 0)
//        {
//            SceneManager.LoadScene(sceneToContinue);
//        }
//        else
//            return;
//    }

//    private void MusicState(int musicState) //2
//    {
//        if (musicState == 0)
//        {
//            spriteChange.sprite = musicOffSprite;
//            musicMenu.Pause();
//            ClickSoundStop();

//        }
//        else if (musicState == 1)
//        {
//            spriteChange.sprite = musicOnSprite;
//            musicMenu.Play();
//            ClickSoundPlay();
//        }
//    }
//}

//[Serializable]
//public class Save
//{
//    public int musicSwitch;

//    public void SetMusicSwitch(int musicSwitch)
//    {
//        this.musicSwitch = musicSwitch;
//    }

//    public int GetMusicSwitch()
//    {
//        return musicSwitch;
//    }
//}


