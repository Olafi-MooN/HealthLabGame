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
    public bool move(GameObject moveIt, GameObject moveTo, float speed, bool canMove)
    {

        // Faz um pequena verificação que para a movimentação quando ele se aproxima do objeto destino
        if (Vector2.Distance(moveIt.transform.position, moveTo.transform.position) > 0.2f)
        {
            moveIt.transform.position = Vector2.MoveTowards(moveIt.transform.position, moveTo.transform.position, speed * Time.deltaTime);
            return true;
        } else
        {
            DialogueInit dialogueInit = FindObjectOfType<DialogueInit>();
            dialogueInit.showDialogue();
            return false;
        }

    }
}
