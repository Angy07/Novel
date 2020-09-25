using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page
{
    protected GameObject prefab;

    public virtual void Init()
    {
        Hide();
    }

    public virtual void Hide()
    {
        prefab.SetActive(false);
    }

    public virtual void Show()
    {       
        prefab.SetActive(true);
    }
}
