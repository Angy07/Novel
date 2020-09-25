using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerOld: MonoBehaviour
{
    private Text _nameText;
    private Text _dialogueText;
    private Button _continueReadBtn;

    private Queue<string> _needSentenses;

    public static DialogueManagerOld instance;

    private string _currentString;

    private void Awake()
    {
        _nameText = GameObject.Find("name").gameObject.GetComponent<Text>();
        _dialogueText = GameObject.Find("dialogueField").gameObject.GetComponent<Text>();
        _continueReadBtn = GameObject.Find("continueReadBtn").gameObject.GetComponent<Button>();
        _continueReadBtn.onClick.AddListener(() => DisplayNextSentence());

        instance = this;

        _needSentenses = new Queue<string>();
    } 

    public void StartDialogue(Dialogue dialogue)
    {
        _nameText.text = dialogue.name;

        _needSentenses.Clear();

        string[] s = new string[2];
        s[0] = "hi";
        s[1] = "hello";

        foreach (string sentence in s/*dialogue.sentences*/)
        {
            _needSentenses.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (_currentString != null && _dialogueText.text.Length != _currentString.Length)
        {
            StopAllCoroutines();

            _dialogueText.text = _currentString;

            CheckKeyPhrases(_currentString);

            _continueReadBtn.GetComponentInChildren<Text>().text = "CONTINUE";
        }
        else
        {
            if (_needSentenses.Count == 0)
            {
                EndDialogue();
                return;
            }

            string sentence = _needSentenses.Dequeue();

            StopAllCoroutines();

            StartCoroutine(TypeSentence1(sentence));

            _currentString = sentence;
        }
    }

    IEnumerator TypeSentence1(string sentence)
    {
        _continueReadBtn.GetComponentInChildren<Text>().text = "ALL TEXT";

        _dialogueText.text = "";
        for (int i = 0; i <= sentence.Length; i++)
        {
            _dialogueText.text = sentence.Substring(0, i);
            yield return null;
        }
        CheckKeyPhrases(sentence);

        _continueReadBtn.GetComponentInChildren<Text>().text = "CONTINUE";
    }

    private void CheckKeyPhrases(string phrase)
    {
        switch (phrase)
        {
            case "Кто ты? Можешь назвать свое имя?":
                // FirstSceneController.instance.Show();
                Debug.Log("Dialogue manager?");
                break;
            case "Ветер усиливается.":
                Debug.Log("Yes, dialogue manager");
                break;
        }
    }

    void EndDialogue()
    {
        Debug.Log("The end");
    }
}
