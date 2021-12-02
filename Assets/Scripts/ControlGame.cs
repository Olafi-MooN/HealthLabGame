using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGame : MonoBehaviour
{
    private DialogueInit dialogueInit;
    private MoveNPC moveNPC;
    public int action = 0;
    public static int stepDialog = 0;

    private bool move = true;
    private bool canMoveNPC = true;

    public void setAction(int action)
    {
        this.action = action;
    }
    public int getAction()
    {
        return this.action;
    }

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<DialogueInit>().HideDialogue();
        moveNPC = FindObjectOfType<MoveNPC>();
    }

    // Update is called once per frame
    void Update()
    {

        switch (action)
        {
            case 0:
                if (canMoveNPC)
                {
                    canMoveNPC = moveNPC.Move(GameObject.Find("DadSprite"), GameObject.Find("ChairOne"), 2, 0.2f, "up", "idleafter");
                } else
                {
                    stepDialog = 1;
                }
                break;

            case 1:
               
                if (move)
                {
                    move = moveNPC.Move(GameObject.Find("DadSprite"), GameObject.Find("bed_blue"), 2, 0f, "right", "idlefront");
                } 

                break;

            case 2:

                if (move)
                {
                    move = moveNPC.Move(GameObject.Find("DadSprite"), GameObject.Find("reception"), 2, 0f, "left", "idlefront");
                }

                break;
        }
    }

}
