using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> allDialogue;
    public Animator animator;
    public Animator character_ani;
    public Text nametext;
    public Text dialoguetext;
    [SerializeField] private string loadlevel;
    // Start is called before the first frame update
    void Start()
    {
        allDialogue = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        character_ani.SetBool("IsAppeared", true);
        animator.SetBool("IsOpen", true);
        allDialogue.Clear();
        nametext.text = dialogue.name;

        foreach (string sentence in dialogue.sentences)
        {
            allDialogue.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        print("continue");
        if(allDialogue.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = allDialogue.Dequeue();
        dialoguetext.text = sentence;
    }

    void EndDialogue()
    {
        character_ani.SetBool("IsAppeared", false);
        animator.SetBool("IsOpen", false);
        SceneManager.LoadScene(loadlevel);
    }

}
