using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    private SpriteRenderer rend;
    private Sprite textBack0, textBack1, textBack2, textBack3, textBack4, textBack5;
    private bool isAttaking =  true;
    private float attackTimer;

    // Start is called before the first frame update
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        textBack0 = Resources.Load<Sprite>("text_back_0");
        textBack1 = Resources.Load<Sprite>("text_back_1");
        textBack2 = Resources.Load<Sprite>("text_back_2");
        textBack3 = Resources.Load<Sprite>("text_back_3");
        textBack4 = Resources.Load<Sprite>("text_back_4");
        textBack5 = Resources.Load<Sprite>("text_back_5");
        rend.drawMode = SpriteDrawMode.Tiled;
        rend.size = new Vector2(352, 72);
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            this.isAttaking = true;
        }

        if (this.isAttaking)
        {
           this.attackTimer += Time.deltaTime;

            if (this.attackTimer >= 0.05f)
            {

                rend.size = new Vector2(352, 72);
                rend.sprite = textBack5;
            }
                if (this.attackTimer >= 0.1f)
                {
                    rend.size = new Vector2(352, 72);
                    rend.sprite = textBack4;
              
            }
                if (this.attackTimer >= 0.15f)
                {
                    rend.size = new Vector2(352, 72);
                    rend.sprite = textBack3;
                
            }
                if (this.attackTimer >= 0.2f)
                {
                    rend.size = new Vector2(352, 72);
                    rend.sprite = textBack2;
              
            }
            if (this.attackTimer >= 0.25f)
            {
                rend.size = new Vector2(352, 72);
                rend.sprite = textBack1;
                
            }
            if (this.attackTimer >= 0.3f)
                {
                //this.isAttaking = false;
               // this.attackTimer = 0f;
                rend.size = new Vector2(352, 72);
                rend.sprite = textBack0;
               
                }
        }
       
    }
}
