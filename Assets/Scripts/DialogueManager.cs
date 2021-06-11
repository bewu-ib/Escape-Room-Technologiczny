using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    private GameObject objectToShow;
    private Animator toShowAnimator;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue, GameObject toShow = null, Animator toShowAnim = null)
    {
        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        objectToShow = toShow;
        toShowAnimator = toShowAnim;
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        if (sentence.StartsWith("$SHOW")) {
            objectToShow.SetActive(true);
            toShowAnimator.SetBool("isOpen", true);

            animator.SetBool("isOpen", false);
        }
        else if (sentence.StartsWith("$EXITGAME"))
        {
            Application.Quit();
        }
        else {
            StartCoroutine(TypeSentence(sentence));
        }
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            for (int i = 0; i < 2; i++)
            {
                yield return 0;
            }
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }
}
