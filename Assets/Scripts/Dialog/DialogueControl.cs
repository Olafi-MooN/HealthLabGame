using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("components")]
    public GameObject dialogueObject;
    public Image profile;
    public Text speechText;
    public Text actorNameText;

    [Header("Settings")]
    public float typingSpeed;
    private Sentences[] sentences;
    private int index;

    public void Speech(Sprite p, Sentences[] txt, string actorNameTxt)
    {
        dialogueObject.SetActive(true);
        profile.sprite = p;
        sentences = txt;
        actorNameText.text = actorNameTxt;
        StartCoroutine(TypeSentence());
    }


    IEnumerator TypeSentence()
    {
        if (VerifySentences()) {
            foreach (char letter in sentences[index].GetSpeechText().ToCharArray())
            {
                speechText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
    }

    public void NextSententence()
    {
        
        
        if(speechText.text == sentences[index].GetSpeechText() && VerifySentences())
        {
            if (index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                actorNameText.text = sentences[index].GeActorName();
                profile.sprite = sentences[index].GeProfileImage();
                StartCoroutine(TypeSentence());
            }
            else
            {
                speechText.text = "";
                index = 0;
                dialogueObject.SetActive(false);
            }
        }
    }

    public bool VerifySentences()
    {
        if (sentences.Length > 0)
        {
            return true;
        }

        return false;
    }
}
