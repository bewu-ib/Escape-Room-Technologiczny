using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickDialogue : MonoBehaviour
{
    public Dialogue dialogue;
    private bool big;

    public bool twoOptions;
    public Dialogue dialogue2;
    public string conditionName;

    public GameObject toShow;
    public Animator toShowAnim;

    public void OnMouseDown()
    {
        if (!twoOptions || !FindObjectOfType<ProgressManager>().bools[conditionName])
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue, toShow, toShowAnim);
        }
        else
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue2, toShow, toShowAnim);
        }
    }

    public void OnMouseOver()
    {
        if (big != true)
        {
            big = true;
            transform.localScale = new Vector3(1.2f * transform.localScale[0], 1.2f * transform.localScale[1], 0);
        }
    }

    public void OnMouseExit()
    {
        if (big == true)
        {
            transform.localScale = new Vector3(0.833f * transform.localScale[0], 0.833f * transform.localScale[1], 0);
            big = false;
        }
    }
}
