using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue ()
    {
        dialogue.name = MainSceneController.instance.GetCharcterName("scene1", "robert");
        //dialogue.sentences = MainSceneController.instance.GetReplics("scene1", "robert", "1appear");
        //DialogueManager.instance.StartDialogue(dialogue);
    }
}
