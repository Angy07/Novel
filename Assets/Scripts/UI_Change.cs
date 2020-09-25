using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UI_Change : MonoBehaviour
{
    private Image nameBack, man, textBack;

    public Sprite textBack0, textBack1, textBack2, textBack3, textBack4, textBack5, man0, man1, man2, man3, man4, man5;

    private bool isAttaking = true;
    private float attackTimer;


    // Conversation/message/backgroundHeader
    // Start is called before the first frame update
    void Start()
    {
        nameBack = transform.Find("Conversation/message/backgroundHeader").GetComponent<Image>();
        nameBack.color = new Color(1, 1, 1, 0);

        textBack = transform.Find("Conversation/message/background").GetComponent<Image>();
        textBack.color = new Color(1, 1, 1, 0);

        man = transform.Find("Image").GetComponent<Image>();
        man.color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    this.isAttaking = true;
        //}

        if (this.isAttaking)
        {
            this.attackTimer += Time.deltaTime;
            

            if (this.attackTimer >= 1f)
            {
                nameBack.color = new Color(1, 1, 1, 1);
                nameBack.sprite = textBack5;

                textBack.color = new Color(1, 1, 1, 1);
                textBack.sprite = textBack5;

                man.color = new Color(1, 1, 1, 1);        
                man.sprite = man5;
            }
            if (this.attackTimer >= 1.01f)
            {
                nameBack.sprite = textBack4;
                textBack.sprite = textBack4;
                man.sprite = man4;
            }
            if (this.attackTimer >= 1.02f)
            {
                nameBack.sprite = textBack3;
                textBack.sprite = textBack3;
                man.sprite = man3;
            }
            if (this.attackTimer >= 1.05f)
            {
                nameBack.sprite = textBack2;
                textBack.sprite = textBack2;
                man.sprite = man2;
            }
            if (this.attackTimer >= 1.07f)
            {
                nameBack.sprite = textBack1;
                textBack.sprite = textBack1;
                man.sprite = man1;
            }
            if (this.attackTimer >= 1.09f)
            {
                this.isAttaking = false;
                this.attackTimer = 0f;
                nameBack.sprite = textBack0;
                textBack.sprite = textBack0;
                man.sprite = man0;



            }
        }

    }
}
