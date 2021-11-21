using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogJson : MonoBehaviour
{
    [Header("Dialog")]
    private StreamReader leitor;
    [SerializeField] private string json;
    [SerializeField] private DialogSentences falas;


    public Sentences[] getJson()
    {
        leitor = new StreamReader(Application.dataPath + "/Scripts/Dialog/DialogJson/jsconfig1.json");
        json = leitor.ReadToEnd();
 
        falas = JsonUtility.FromJson<DialogSentences>(json);
     
        return falas.falas;
    }
}
