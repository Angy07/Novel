using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class UI_NameInputWindow : MonoBehaviour
{
    private static UI_NameInputWindow instance;

    private Button_UI okBtn;
    private Button_UI cancelBtn;
    private TextMeshProUGUI questionText;
    private TMP_InputField inputFieldName;

    public RectTransform window;

    private Toggle man;
    private Toggle woman;

    public UnityEvent onCompleteCallback;


    public void OnEnable()
    {
        transform.localScale = new Vector3(0, 0, 0);
        window.DOScale(new Vector3(1, 1, 1), 0.9f);     
    }

    private void Awake()
    {
        instance = this;     

        okBtn = transform.Find("okBtn").GetComponent<Button_UI>();
        cancelBtn = transform.Find("cancelBtn").GetComponent<Button_UI>();
        questionText = transform.Find("questionText").GetComponent<TextMeshProUGUI>();
        inputFieldName = transform.Find("inputFieldName").GetComponent<TMP_InputField>();

        man = transform.Find("man").GetComponent<Toggle>();
        woman = transform.Find("woman").GetComponent<Toggle>();

        Hide();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            okBtn.ClickFunc();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cancelBtn.ClickFunc();
        }
    }

    private void Show(string titleString, string inputString, string validCharacters, int characterLimit, Action onCancel, Action<string> onOk)
    {
        gameObject.SetActive(true);
        transform.SetAsLastSibling();

        questionText.text = titleString;

        inputFieldName.characterLimit = characterLimit;

        inputFieldName.onValidateInput = (string text, int charIndex, char addedChar) =>
        {
            return ValidateChar(validCharacters, addedChar);
        };

        inputFieldName.text = inputString;

         man.onValueChanged.AddListener(delegate { ToggleValueChanged(man, woman); });
         woman.onValueChanged.AddListener(delegate { ToggleValueChanged(man, woman); });

        cancelBtn.ClickFunc = () =>
        {
            Hide();
            onCancel();
        };

        okBtn.ClickFunc = () =>
        {
            Hide();
            onOk(inputFieldName.text);

        };
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private char ValidateChar(string validCharacters, char addedChar)
    {
        if(validCharacters.IndexOf(addedChar) != -1)
        {
            return addedChar;
        } else {
            return '\0';
        }
    }

    public static void Show_Static(string titleString, string inputString, string validCharacters, int characterLimit, Action onCancel, Action<string> onOk)
    {
        instance.Show(titleString, inputString,validCharacters, characterLimit, onCancel, onOk);
    }

    private string ToggleValueChanged(Toggle man,Toggle woman)      
    {
        if (man.isOn)
        {
         
            Debug.Log("man");       
            return "man";
        }
        else if(woman.isOn)
        {
         
            Debug.Log("woman");         
            return "woman";
        } else
        {
            Debug.Log("nothing");
            return "nothing";
        }
    }

}
