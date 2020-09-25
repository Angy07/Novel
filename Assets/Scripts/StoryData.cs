using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[Serializable]
public class StoryData
{
    public List<Scene> scenes;
}

[Serializable]
public class Scene
{
    public int id;
    public List<Step> steps;
}


[Serializable]
public class Step
{
    public int id;

    public string character;
    public string name;
    public string text;
    public string type;

    public int nextStepId;

    public List<Variant> variants;
    public ItemTrigger itemTrigger;
}

[Serializable]
public class Variant
{
    public string text;
    public ItemTrigger itemTrigger;
}

[Serializable]
public class ItemTrigger
{
    public List<int> itemId;
    public int nextStepId;
    public TriggerVariant triggerVariants;
}


[Serializable]
public class TriggerVariant
{
    public int nextStepId;
}




