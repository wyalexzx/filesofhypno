using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogeManager : MonoBehaviour
{

    public Text nameText;
    public Text DialogueText;


    private Queue<string> sentences;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    
    public void StartDialogue (Dialoge dialogue)
    {
        Debug.Log("starting conversation with " + dialogue.name);

        nameText.text = dialogue.name;


        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentence.enqueue(sentence);
        }

        DisplayNextSetence();

    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            endDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        DialogueText.text = sentence;

    }

    void EndDialogue()
    {
        Debug.Log("End of conversation. ");
    }
}
