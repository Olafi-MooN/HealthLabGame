using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGame : MonoBehaviour
{
    private DialogueInit dialogueInit;
    private MoveNPC moveNPC;
    private bool canMoveNPC = true;

    // Start is called before the first frame update
    void Start()
    {
        dialogueInit = FindObjectOfType<DialogueInit>();
        moveNPC = FindObjectOfType<MoveNPC>();
        dialogueInit.HideDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMoveNPC)
        {
            canMoveNPC = moveNPC.move(GameObject.Find("DadSprite"), GameObject.Find("ChairOne"), 2, true);
        }
    }
}
