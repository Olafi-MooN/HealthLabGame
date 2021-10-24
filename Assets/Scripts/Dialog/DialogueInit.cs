using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInit : MonoBehaviour
{
    public Sprite profile;
    public Sentences[] speechText;
    public string actorName;

    private DialogueControl dialogueControl;

    public void Start()
    {
        dialogueControl = FindObjectOfType<DialogueControl>();
        showDialogue();
    }

    public void showDialogue()
    {
        dialogueControl.Speech(profile, speechText, actorName);
    }

}
