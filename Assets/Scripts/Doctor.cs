using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : MonoBehaviour
{
    public Animator animator;
    public float speed;

    void Update()
    {
        FindObjectOfType<Move>().Movement(speed, animator);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "blueBed")
        {
            FindObjectOfType<DialogueInit>().showDialogue("action02.json");
        }
        if (collision.gameObject.tag == "reception")
        {
            FindObjectOfType<DialogueInit>().showDialogue("action03.json");
        }
    }
}