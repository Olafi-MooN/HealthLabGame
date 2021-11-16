using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Sentences 
{   
    [Header("DialogoManegement")]
    public string speechText;
    public string profileSprite;
    public string ActorName;
    public Questions questions;

    public string GetSpeechText()
    {
        return speechText;
    }
    public string GetProfileImage()
    {
        return profileSprite;
    }
    public string GetActorName()
    {
        return ActorName;
    }
    public Questions GetQuestions()
    {
        return questions;
    }
}

[System.Serializable]
public class Questions
{
    [Header("Questions")]
    public string response1;
    public string response2;
    public string response3;
    public string points;
    public string correctResponse;
}