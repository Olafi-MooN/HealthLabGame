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
        DialogJson dialogJson = gameObject.AddComponent<DialogJson>();
        dialogueControl.Speech(profile, dialogJson.getJson(), actorName);
    }

}
