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

    private SoundManager soundM;

    private void Start()
    {
        soundM = FindObjectOfType<SoundManager>();

        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(Check);
        input.Select();
    }

    public void Check()
    {
        if (input.text.ToLower() == correct)
        {
            FindObjectOfType<ProgressManager>().bools[boolName] = true;
            soundM.playEffect(soundM.correct);

            animator.SetBool("isOpen", false);
            questionObject.SetActive(false);
            FindObjectOfType<DialogueManager>().StartDialogue(afterSolved);
        }
        else
        {
            soundM.playEffect(soundM.incorrect);

            input.text = "";
            input.animator.SetTrigger("wrong");
            input.Select();
        }
    }
}
