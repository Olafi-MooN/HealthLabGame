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
}