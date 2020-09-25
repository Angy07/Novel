using UnityEngine;
using UnityEngine.UI;

public class DialogueManager 
{
    private Text _nameText;
    private Text _dialogueText;
    private Button _continueReadBtn;

    private string _needSentense;

    private string _currentSentence;
  
    private float _timer;
    private float _typeTime;
    private float _delay = 0.0005f;

    private int _indexCharacter = 1;

    public DialogueManager()
    {
        Init();
    }
 
    private void Init() //Awake
    {
        _nameText = GameObject.Find("name").gameObject.GetComponent<Text>();
        _dialogueText = GameObject.Find("dialogueField").gameObject.GetComponent<Text>();
        _continueReadBtn = GameObject.Find("continueReadBtn").gameObject.GetComponent<Button>();
        _continueReadBtn.onClick.AddListener(() => DisplayNextSentence());
    }

    public void TypeText() //Update
    {      
        _timer += 1 * Time.deltaTime;

        if (_timer >= _typeTime && _dialogueText.text.Length < _currentSentence.Length)
        {

            _dialogueText.text = _currentSentence.Substring(0, _indexCharacter);
          
            _continueReadBtn.GetComponentInChildren<Text>().text = "ВЕСЬ ТЕКСТ";

            _indexCharacter++;

            _typeTime = _timer + _delay;
        }

        if (_dialogueText.text.Length == _currentSentence.Length)
        {
            _continueReadBtn.GetComponentInChildren<Text>().text = "ПРОДОЛЖИТЬ";
            _indexCharacter = 1;
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        _nameText.text = dialogue.name;

        _needSentense = dialogue.sentence;

        _currentSentence = InsertName(_needSentense);

        _dialogueText.text = "";
    }

    public void DisplayNextSentence()
    {
        if (_continueReadBtn.GetComponentInChildren<Text>().text == "ВЕСЬ ТЕКСТ")
        {
            _dialogueText.text = _currentSentence;
        }
        else
        {
            SceneMainController.instance.CheckSentence();
        }    
    }
   
    private string InsertName(string sentence)
    {      
        if (sentence.IndexOf('_') != -1)
        {
            string modified = sentence.Replace("_", SceneMainController.instance.dataManager.data.playerName);
            return modified;
        }
        else
            return sentence;
    }
}

