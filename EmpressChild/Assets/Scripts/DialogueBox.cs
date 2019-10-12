using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBoxDetails
{
    public GameObject dialoguePanelObject;
    public string dialogueString;
    public float displayTime;
}

public class DialogueBox : MonoBehaviour
{
    public Text dialogue;
    public float displayTime;

    public GameObject dialoguePanelObject;


    private static DialogueBox dialogueBox;

    public static DialogueBox Instance()
    {
        if (!dialogueBox)
        {
            dialogueBox = FindObjectOfType(typeof(DialogueBox)) as DialogueBox;
            if (!dialogueBox)
                Debug.LogError("There needs to be one active DialogueBox script on a GameObject in your scene.");
        }

        return dialogueBox;
    }


    public void NewDialogue(DialogueBoxDetails details)
    {
        if (details.dialoguePanelObject != null)
        {
            this.dialoguePanelObject = details.dialoguePanelObject;
            this.dialogue = details.dialoguePanelObject.transform.Find("Text").GetComponent<Text>();
        }

        dialoguePanelObject.SetActive(true);

        this.dialogue.text = details.dialogueString;
        this.displayTime = details.displayTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClosePanel()
    {
        dialoguePanelObject.SetActive(false);
    }
}
