using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToggleMy : MonoBehaviour
{
    public Toggle toggle;
   // public Sprite hold;
    public Graphic m_Graphic;
    Color m_MyColor;
    Sprite onHover, offHover;
    //bool y = true;

    private Image spriteChange;
 
    // Start is called before the first frame update
    void Start()
    {
        spriteChange = GameObject.Find("Checkmark").GetComponent<Image>();
        onHover = Resources.Load<Sprite>("muteHold1");
        offHover = Resources.Load<Sprite>("VioletCircleMusicOff");

        //toggle.tag = "HoverOff";
       // m_MyColor = Color.red;
       //m_Graphic.color = m_MyColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject() && toggle.isOn == true)
        {
            toggle.tag = "HoverOn";
            if (EventSystem.current.currentSelectedGameObject != null /*&& EventSystem.current.currentSelectedGameObject.CompareTag("HoverOn")*/)
            {
                Debug.Log("Bye!");
            }
            
            Debug.Log("Hi!");
            //toggle.graphic.color = new Color(0f, 10f, 0f);
            //ColorBlock cb = toggle.colors;
            // cb.highlightedColor = new Color(0f, 10f, 0f);
            //toggle.colors = cb;
            //(Input.GetMouseButtonDown(0) && toggle.isOn == true)
            // m_MyColor = Color.Lerp(Color.yellow, Color.white, Mathf.PingPong(Time.time, 1));
             m_MyColor = Color.Lerp(Color.yellow, Color.yellow, Mathf.PingPong(Time.time, 1));
            // m_Graphic.color = m_MyColor;
            spriteChange.sprite = onHover;
        }
        else
        {
            spriteChange.sprite = offHover;
            
            toggle.tag = "HoverOff";
            Debug.Log("Tab!");
        }
       
        //else
        //{
        //    //toggle.graphic.color = new Color(1f, 10f, 1f);
        //}
    }
}
