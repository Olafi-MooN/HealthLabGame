using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

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
    private Sprite[] sprites;


    public void Start()
    {
        sprites = LoadSprite("profiles");
    }


    public void Speech(Sentences[] txt)
    {

        sprites = LoadSprite("profiles");
        dialogueObject.SetActive(true);
        sentences = txt;
        actorNameText.text = txt[0].GetActorName();
        profile.sprite = sprites[int.Parse(txt[0].GetProfileImage())];
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

    private Sprite[] LoadSprite(string path)
    {
        return Resources.LoadAll<Sprite>(path);
    }

    public void NextSententence()
    {
        if(speechText.text == sentences[index].GetSpeechText() && VerifySentences())
        {
            if (index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                actorNameText.text = sentences[index].GetActorName();
                profile.sprite = sprites[int.Parse(sentences[index].GetProfileImage())];
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
