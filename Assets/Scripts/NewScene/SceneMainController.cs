using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using System.Linq;

public class SceneMainController : MonoBehaviour
{
    private RectTransform _speaker;

    private string _character;
    private string _name;
    private string _text;
    private string _type;
    private int _nextStepId;

    private int _indexCurrentScene;
    private int _indexCurrentStep;

    public DataManager dataManager;
    public DialogueManager dialogueManager;
    public SceneController sceneController;
    public UI_Blocker uiBlocker;

    public UI_NameGenderInputWindow uiNameGenderInputWindow;
    public UI_SelectItemsWindow uiSelectItemsWindow;
    public UI_FactsWindow UiFactsWindow;
    public UI_ChangeItemsWindow UiChangeItemsWindow;

    public Dialogue dialogue;

    public static SceneMainController instance;

    public void Awake()
    {   
        instance = this;

        dataManager = new DataManager();
        dataManager.Load(DataManager.DataTypeEnum.UserProgress);
        dataManager.Load(DataManager.DataTypeEnum.Story);

        dialogueManager = new DialogueManager();

        uiBlocker = new UI_Blocker();

        uiNameGenderInputWindow = new UI_NameGenderInputWindow();

        uiSelectItemsWindow = new UI_SelectItemsWindow();

        UiFactsWindow = new UI_FactsWindow();

        UiChangeItemsWindow = new UI_ChangeItemsWindow();

        _indexCurrentScene = dataManager.data.currentSceneIndex;
        _indexCurrentStep = dataManager.data.currentStepIndex;
    }

    public void Start()
    {    
        sceneController = new SceneController();
        sceneController.StartGame();
    }

    public void Update()
    {
        dialogueManager.TypeText();
    }

    public void TriggerDialogue()
    {
       // _indexCurrentScene = idScene - 1;

        SceneStepControl();              
    }

    private void SceneStepControl()
    {
        dialogue.currentIdScene = _indexCurrentScene;

        if (_indexCurrentStep < dataManager.storyData.scenes[_indexCurrentScene].steps.Count)
        {

            _character = dataManager.storyData.scenes[_indexCurrentScene].steps[_indexCurrentStep].character;
            sceneController.SceneCharacter(_character);

            _name = dataManager.storyData.scenes[_indexCurrentScene].steps[_indexCurrentStep].name;
            dialogue.name = _name;

            if (dataManager.storyData.scenes[_indexCurrentScene].steps[_indexCurrentStep].variants.Count > 0)
            {
                switch (dataManager.data.playerGender)
                {                  
                    case "woman":
                        _text = dataManager.storyData.scenes[_indexCurrentScene].steps[_indexCurrentStep].variants[0].text;
                        dialogue.sentence = _text;
                   
                        break;
                    case "man":
                        _text = dataManager.storyData.scenes[_indexCurrentScene].steps[_indexCurrentStep].text;
                        dialogue.sentence = _text;
                      
                        break;
                }
            }
            else
            {
                _text = dataManager.storyData.scenes[_indexCurrentScene].steps[_indexCurrentStep].text;
                dialogue.sentence = _text;
            }

            _type = dataManager.storyData.scenes[_indexCurrentScene].steps[_indexCurrentStep].type;
            sceneController.CheckSentenceType(_type, _indexCurrentStep);

            switch (dataManager.data.playerGender)
            {
                case "woman":
                    CheckItemVariant();
                    break;
                case "man":
                    CheckItem();
                    break;
            }
           
          //  _nextStepId = dataManager.storyData.scenes[_indexCurrentScene].steps[_indexCurrentStep].nextStepId;

            dataManager.data.currentStepIndex = _indexCurrentStep;

            dataManager.data.currentSceneIndex = _indexCurrentScene;

            dataManager.Save(DataManager.DataTypeEnum.UserProgress);
           

            dialogueManager.StartDialogue(dialogue);   
        }
    }

    public void CheckItem()
    {
        if (dataManager.storyData.scenes[_indexCurrentScene].steps[_indexCurrentStep].itemTrigger.itemId != null)
        {
            bool result = false;

            if (dataManager.data.indexItems.Length == dataManager.storyData.scenes[_indexCurrentScene].steps[_indexCurrentStep].itemTrigger.itemId.Count)
            {
                result = dataManager.storyData.scenes[_indexCurrentScene].steps[_indexCurrentStep].itemTrigger.itemId.SequenceEqual(dataManager.data.indexItems);
            }
            else
            {
                for (int i = 0; i < dataManager.data.indexItems.Length; i++)
                {
                    bool needKey = dataManager.storyData.scenes[_indexCurrentScene].steps[_indexCurrentStep].itemTrigger.itemId.Contains(dataManager.data.indexItems[i]);
                    if (needKey)
                    {
                        result = true;
                    }
                }
            }
            if (result)
            {
                _nextStepId = dataManager.storyData.scenes[_indexCurrentScene].steps[_indexCurrentStep].itemTrigger.nextStepId;
            }
            else
            {
                _nextStepId = dataManager.storyData.scenes[_indexCurrentScene].steps[_indexCurrentStep].itemTrigger.triggerVariants.nextStepId;
            }
        }
        else
        {
            _nextStepId = dataManager.storyData.scenes[_indexCurrentScene].steps[_indexCurrentStep].nextStepId;
        }
    }

    public void CheckItemVariant()
    {
        if (dataManager.storyData.scenes[_indexCurrentScene].steps[_indexCurrentStep].variants.Count > 0 && dataManager.storyData.scenes[_indexCurrentScene].steps[_indexCurrentStep].variants[0].itemTrigger.itemId != null)
        {
            bool result = false;
          
            if (dataManager.data.indexItems.Length == dataManager.storyData.scenes[_indexCurrentScene].steps[_indexCurrentStep].variants[0].itemTrigger.itemId.Count)
            {             
                result = dataManager.storyData.scenes[_indexCurrentScene].steps[_indexCurrentStep].variants[0].itemTrigger.itemId.SequenceEqual(dataManager.data.indexItems);          
            }
            else
            {
                for (int i = 0; i < dataManager.data.indexItems.Length; i++)
                {
                    bool needKey = dataManager.storyData.scenes[_indexCurrentScene].steps[_indexCurrentStep].variants[0].itemTrigger.itemId.Contains(dataManager.data.indexItems[i]);

                    if (needKey)
                    {
                        result = true;
                    }
                }
            }
            if (result)
            {
                _nextStepId = dataManager.storyData.scenes[_indexCurrentScene].steps[_indexCurrentStep].variants[0].itemTrigger.nextStepId;
            }
            else
            {
                _nextStepId = dataManager.storyData.scenes[_indexCurrentScene].steps[_indexCurrentStep].variants[0].itemTrigger.triggerVariants.nextStepId;
            }
        }
        else
        {
            _nextStepId = dataManager.storyData.scenes[_indexCurrentScene].steps[_indexCurrentStep].nextStepId;
        }
    }

    public void CheckSentence()
    {
        _indexCurrentStep = _nextStepId - 1;

        if (_indexCurrentStep != -1)
        {
            SceneStepControl();
        }
        if (_indexCurrentStep == -1)
        {
            _indexCurrentScene = _indexCurrentScene + 1;
            _indexCurrentStep = 0;
            SceneStepControl();
        }
    }

    public void dialogueSystemAppear(RectTransform dialogueSystem)
    {
        DOTween.SetTweensCapacity(500, 125);
        dialogueSystem.DOJumpAnchorPos(new Vector2(0f, 143f), 280f, 1, 1.0f, false);
    }

    public void CharacterAppear(RectTransform speaker)
    {
        speaker.DOAnchorPos(new Vector2(339.0f, 460f), 1.2f, false);
    }

    public void ShowPopup(RectTransform currentPopup) //OnEnable
    {
        currentPopup.gameObject.SetActive(true);
        currentPopup.transform.localScale = new Vector3(0, 0, -10);
        currentPopup.DOScale(new Vector3(2, 2, 2), 0.9f);
        uiBlocker.ShowUiBlocker();
    }

    public void HidePopup(RectTransform currentPopup)
    {
        currentPopup.gameObject.SetActive(false);
        uiBlocker.HideUiBlocker();
    }

}

