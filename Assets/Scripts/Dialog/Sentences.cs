using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Sentences 
{   
    [Header("Objects")]
    public string speechText;
    public string profileSprite;
    public string ActorName;

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
}
