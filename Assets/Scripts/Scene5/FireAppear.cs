using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FireAppear : MonoBehaviour
{
    private SpriteRenderer _fire;

    [SerializeField]
    private  float _duration = 12f;
    private RectTransform _rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        _fire = GameObject.Find("fire_").gameObject.GetComponent<SpriteRenderer>();
        _rectTransform = GameObject.Find("fire_").gameObject.GetComponent<RectTransform>();
        Appear();
        StartFadeIn();
    }
    
    void Appear()
    {
        //_fire.DOColor(new Color(235, 235, 235, 255), _duration);

        Color color = _fire.material.color;
        color.a = 0f;
        _fire.material.color = color;

    }

    IEnumerator FadeIn()
    {
        for (float f=0.05f; f <=1; f += 0.05f)
        {
            Color color = _fire.material.color;
            color.a = f;
            _fire.material.color = color;
            yield return new WaitForSeconds(0.0005f);
        }
    }

    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.05; f -= 0.05f)
        {
            Color color = _fire.material.color;
            color.a = f;
            _fire.material.color = color;
            yield return new WaitForSeconds(0.0005f);
        }
    }

    private void StartFadeIn()
    {
        StartCoroutine("FadeIn");
    }
}
