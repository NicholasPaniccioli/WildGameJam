using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceptionistDialogue : MonoBehaviour
{
    public string[] dialogue;
    //public Text text;
    private DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Awake()
    {
        dialogueManager = DialogueManager.Instance();
        //text = gameObject.GetComponent<Text>();
        dialogueManager.dialogueQueue[0].text = dialogue[Random.Range(0, dialogue.Length)];
        //text.text 
    }
}
