using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNPC : MonoBehaviour
{
    public void Start()
    {

    }

    // A função moveIt recebera dois argumentos
    // MoveIt: "Mova esse" objeto atual
    // MoveTo: "Mova Para" objeto destino
    public bool Move(GameObject moveIt, GameObject moveTo, float speed, float approximateDistance, string direction, string directionStop)
    {

        // Faz um pequena verificação que para a movimentação quando ele se aproxima do objeto destino
        if (Vector2.Distance(moveIt.transform.position, moveTo.transform.position) > approximateDistance)
        {
            AnimationNPC(moveIt.GetComponent<Animator>(), direction, moveIt);
            moveIt.transform.position = Vector2.MoveTowards(moveIt.transform.position, moveTo.transform.position, speed * Time.deltaTime);
            return true;
        }
        else
        {
            AnimationNPC(moveIt.GetComponent<Animator>(), directionStop, moveIt);
            if (ControlGame.stepDialog == 0)
            {
                DialogueInit dialogueInit = FindObjectOfType<DialogueInit>();
                dialogueInit.showDialogue("action01.json");
            }
            return false;


        }

    }

    public void AnimationNPC(Animator animator, string direction, GameObject obj)
    {
        switch (direction)
        {
            case "up":
                animator.SetBool("up", true);
                animator.SetBool("right", false);
                animator.SetBool("idlefront", false);
                animator.SetBool("idleafter", false);
                break;
            case "right":
                animator.SetBool("up", false);
                animator.SetBool("right", true);
                animator.SetBool("idlefront", false);
                animator.SetBool("idleafter", false);
                break;
            case "left":
                animator.SetBool("up", false);
                animator.SetBool("right", true);
                animator.SetBool("idlefront", false);
                animator.SetBool("idleafter", false);
                obj.transform.Rotate(0f, 180f, 0f);
                break;
            case "idlefront":
                animator.SetBool("up", false);
                animator.SetBool("right", false);
                animator.SetBool("idlefront", true);
                animator.SetBool("idleafter", false);
                break;
            case "idleafter":
                animator.SetBool("up", false);
                animator.SetBool("right", false);
                animator.SetBool("idlefront", false);
                animator.SetBool("idleafter", true);
                break;
        }

    }
}
