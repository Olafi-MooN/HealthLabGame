﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInit : MonoBehaviour
{
    public Sprite profile;
    public Sentences[] speechText;
    public string actorName;

    //private DialogueControl dialogueControl;

    public void Start()
    {
       
    }

    public void HideDialogue()
    {
        Canvas canvasDialogue = GameObject.Find("CanvasDialogue").GetComponent<Canvas>();
        canvasDialogue.enabled = false;
    }

    public void showDialogue()
    {
        Canvas canvasDialogue = GameObject.Find("CanvasDialogue").GetComponent<Canvas>();
        canvasDialogue.enabled = true;

        DialogueControl dialogueControl = FindObjectOfType<DialogueControl>();

        DialogJson dialogJson = gameObject.AddComponent<DialogJson>();
        dialogueControl.Speech(dialogJson.getJson());
    }

}
