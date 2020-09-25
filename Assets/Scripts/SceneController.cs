using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController
{
    private RectTransform _dialogueSystem;
    private RectTransform _speaker;
    private Button _backToMenuBtn;

    private string _currentCharacter = "robert";

    private Sprite _markSprite, _robertSprite, _jamesSprite, _gregorySprite;
    private Image _speakerSpriteChange;

    public SceneController()
    {
        Init();
    }

    public void Init() //Start
    {
        _dialogueSystem = GameObject.Find("DialogueSystem").gameObject.GetComponent<RectTransform>();
        _speaker = GameObject.Find("speaker").gameObject.GetComponent<RectTransform>();

        _speakerSpriteChange = GameObject.Find("speaker").gameObject.GetComponent<Image>();
        _markSprite = Resources.Load<Sprite>("mark");
        _robertSprite = Resources.Load<Sprite>("robert");
        _jamesSprite = Resources.Load<Sprite>("james");
        _gregorySprite = Resources.Load<Sprite>("gregory");

        _backToMenuBtn = GameObject.Find("Menu").GetComponent<Button>();

        _backToMenuBtn.onClick.AddListener(() => LoadMainMenu());
    }

    public void StartGame()
    {
        SceneDialogueSystem();
        SceneMainController.instance.TriggerDialogue();
    }

    public void SceneDialogueSystem()
    {
        SceneMainController.instance.dialogueSystemAppear(_dialogueSystem);
    }

    public void SceneCharacter(string character)
    {
            switch (character)
            {
                case "robert":
                _speakerSpriteChange.sprite = _robertSprite;
                ChangedSpeakerSprite();
                break;
                case "james":
                _speakerSpriteChange.sprite = _jamesSprite;
                ChangedSpeakerSprite();
                break;
                case "mark":
                _speakerSpriteChange.sprite = _markSprite;
                ChangedSpeakerSprite();
                break;
                case "gregory":
                _speakerSpriteChange.sprite = _gregorySprite;
                ChangedSpeakerSprite();
                break;
                default:
                _speakerSpriteChange.sprite = null;
                _speakerSpriteChange.color = new Color(0, 0, 0, 0);
                break;
            }
    }

    public void ChangedSpeakerSprite()
    {
        _speakerSpriteChange.color = new Color(255, 255, 255, 2525);
        SceneMainController.instance.CharacterAppear(_speaker);
    }

    public void CheckSentenceType(string type, int currentStepIndex)
    {
        switch (type)
        {
            case "skip":
                break;
            case "input":
                CheckInput(currentStepIndex + 1);             
                break;
            case "select":
                CheckSelect(currentStepIndex);
                break;
        }
    }

    private void CheckInput(int currentStepId)
    {
        switch (currentStepId)
        {
            case 3:
                if (!SceneMainController.instance.dataManager.data.isInputPlayerData)
                    SceneMainController.instance.uiNameGenderInputWindow.Show();
                break;
            case 36:
                SceneMainController.instance.UiFactsWindow.Show("Тебя догоняют два людоеда!");
                break;
            case 46:
                SceneMainController.instance.UiChangeItemsWindow.Show("Нож не видно, но есть возможность забрать топор. Заберешь топор или пойдешь дальше без него?", "Забрать топор", "Нет. Идем дальше без топора", (int)UI_SelectItemsWindow.PlayerItemsEnum.Axe);
                break;
            case 48:
                SceneMainController.instance.UiChangeItemsWindow.Show("Есть возможность забрать топор. Заберешь топор или пойдешь дальше без него?", "Забрать топор", "Нет. Идем дальше без топора", (int)UI_SelectItemsWindow.PlayerItemsEnum.Axe);
                break;
            case 14:
                SceneMainController.instance.UiChangeItemsWindow.Show("Амулет потерян, но ты предполагаешь где могла его уронить. Это не далеко.", "Вернуться за амулетом", "Не возвращаться", (int)UI_SelectItemsWindow.PlayerItemsEnum.Amulet);
                break;
        }

    }

    private void CheckSelect(int currentStepIndex)
    {
        SceneMainController.instance.uiSelectItemsWindow.Show();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);       
    }  
}
