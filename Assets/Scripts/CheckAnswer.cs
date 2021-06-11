using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckAnswer : MonoBehaviour
{
    public string correct;
    public string boolName;
    public Button button;
    public InputField input;
    public GameObject questionObject;
    public Animator animator;

    public Dialogue afterSolved;

    private void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(Check);
        input.Select();
    }

    public void Check()
    {
        if (input.text.ToLower() == correct)
        {
            FindObjectOfType<ProgressManager>().bools[boolName] = true;

            animator.SetBool("isOpen", false);
            questionObject.SetActive(false);
            FindObjectOfType<DialogueManager>().StartDialogue(afterSolved);
        }
        else
        {
            input.text = "";
            input.animator.SetTrigger("wrong");
            input.Select();
        }
    }
}
