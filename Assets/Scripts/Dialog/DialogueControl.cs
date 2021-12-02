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
    public Button btnContinue;
    public GameObject PanelQuestions;

    [Header("Settings")]
    public float typingSpeed;
    private Sentences[] sentences;
    private int index;
    private Sprite[] sprites;
    private int action = 0;
    public bool responseError;


    public void Start()
    {
        sprites = LoadSprite("profiles");
    }


    public void Speech(Sentences[] txt, bool resetSettings)
    {

        if(resetSettings)
        {
            index = 0;
            responseError = false;
        }
        sprites = LoadSprite("profiles");
        dialogueObject.SetActive(true);
        sentences = txt;
        actorNameText.text = txt[0].GetActorName();
        profile.sprite = sprites[int.Parse(txt[0].GetProfileImage())];
        QuestionControl(txt[0].GetQuestions());
        StartCoroutine(TypeSentence());

    }


    IEnumerator TypeSentence()
    {
        if (VerifySentences()) {
            if(responseError)
            {
                PanelQuestions.SetActive(false);
                btnContinue.gameObject.SetActive(true);

                foreach (char letter in sentences[index].GetQuestions().getInCorrectResponse().ToCharArray())
                {
                    speechText.text += letter;
                    yield return new WaitForSeconds(typingSpeed);
                }

                responseError = false;

            } 
            else
            {
                foreach (char letter in sentences[index].GetSpeechText().ToCharArray())
                {
                    speechText.text += letter;
                    yield return new WaitForSeconds(typingSpeed);
                }
            }
            
        }
    }

    private Sprite[] LoadSprite(string path)
    {
        return Resources.LoadAll<Sprite>(path);
    }

    public void NextSententence()
    {
        if(((speechText?.text == sentences[index]?.GetSpeechText()) || (speechText?.text == sentences[index]?.GetQuestions().getInCorrectResponse()) ) && VerifySentences())
        {
            if(responseError)
            {
                speechText.text = "";
                StartCoroutine(TypeSentence());
                return;
            }
            if (index < sentences.Length - 1)
            {
                index++;
                QuestionControl(sentences[index].GetQuestions());
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
                action++;
                FindObjectOfType<ControlGame>().setAction(action);
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

    public void QuestionControl(Questions question)
    {
        if (question?.response1 != null)
        {
            btnContinue.gameObject.SetActive(false);
            PanelQuestions.SetActive(true);

            GameObject.Find("TextResponseA").GetComponent<Text>().text = question.response1;
            GameObject.Find("TextResponseB").GetComponent<Text>().text = question.response2;
            GameObject.Find("TextResponseC").GetComponent<Text>().text = question.response3;

            Button btnResponseA = GameObject.Find("ResponseA").GetComponent<Button>();
            if (btnResponseA != null) btnResponseA.onClick.AddListener(delegate { selectButtonQuestion(btnResponseA.tag, question); });

            Button btnResponseB = GameObject.Find("ResponseB").GetComponent<Button>();
            if (btnResponseB != null) btnResponseB.onClick.AddListener(delegate { selectButtonQuestion(btnResponseB.tag, question); });

            Button btnResponseC = GameObject.Find("ResponseC").GetComponent<Button>();
            if (btnResponseC != null) btnResponseC.onClick.AddListener(delegate { selectButtonQuestion(btnResponseC.tag, question); });

        } else
        {
            PanelQuestions.SetActive(false);
            btnContinue.gameObject.SetActive(true);

        }
    }

    public void selectButtonQuestion(string tag, Questions question)
    {
        Text scoreGame = GameObject.Find("ScoreGame").GetComponent<Text>();
        if (question.correctResponse == tag)
        {
            scoreGame.text = (int.Parse(scoreGame.text) + int.Parse(question.points)).ToString();
            responseError = false;
            NextSententence();
        } else
        {
            scoreGame.text = (int.Parse(scoreGame.text) - int.Parse(question.points)).ToString();
            responseError = true;
            NextSententence();
        }
    }
 }
