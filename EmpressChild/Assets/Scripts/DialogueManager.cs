using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public DialogueBox dialogueBox;

    public List<DialogueBoxDetails> dialogueQueue;
    public bool boxActive;

    
    private static DialogueManager dialogueManager;

    public static DialogueManager Instance()
    {
        if (!dialogueManager)
        {
            dialogueManager = FindObjectOfType(typeof(DialogueManager)) as DialogueManager;
            if (!dialogueManager)
                Debug.LogError("There needs to be one active DialogueManager script on a GameObject in your scene.");
        }

        return dialogueManager;
    }
    

    // Start is called before the first frame update
    void Awake()
    {
        dialogueBox = DialogueBox.Instance();
        dialogueQueue = new List<DialogueBoxDetails>();
        boxActive = false;
    }

    public void TestDialogue1()
    {
        dialogueBox.NewDialogue(new DialogueBoxDetails() { dialogueString = "Hey Howdy!", displayTime = 2f });
    }

    // Makes a dialgue box for two seconds
    public void ShortDialogueBox(string dialogue)
    {
        dialogueQueue.Add(new DialogueBoxDetails() { dialogueString = dialogue, displayTime = 2f });
        ActivateDialogueBox();
    }

    // Makes a dialogue box for three and a half seconds
    public void MediumDialogueBox(string dialogue)
    {
        dialogueQueue.Add(new DialogueBoxDetails() { dialogueString = dialogue, displayTime = 3.5f });
        ActivateDialogueBox();
    }

    // Makes a dialogue box for 5 seconds
    public void LongDialogueBox(string dialogue)
    {
        dialogueQueue.Add(new DialogueBoxDetails() { dialogueString = dialogue, displayTime = 6f });
        ActivateDialogueBox();
    }

    // Swaps the active dialogue box
    public void AddDialoguePanelSwap(GameObject newDialoguePanel)
    {
        dialogueQueue[dialogueQueue.Count - 1].dialoguePanelObject = newDialoguePanel;// (new DialogueBoxDetails() { dialoguePanelObject = newDialoguePanel, dialogueString = "", displayTime = 0f });
        ActivateDialogueBox();
        /*
        dialogueBox.dialoguePanelObject = newDialoguePanel;
        dialogueBox.dialogue = newDialoguePanel.transform.Find("Text").GetComponent<Text>();
        */
    }


    public void ActivateDialogueBox()
    {
        if (!boxActive && dialogueQueue.Count > 0)
        {
            dialogueBox.NewDialogue(dialogueQueue[0]);
            boxActive = true;
            StartCoroutine(ActiveBox());
        }
    }
    IEnumerator ActiveBox()
    {
        yield return new WaitForSeconds(dialogueQueue[0].displayTime);
        CloseCurrentPanel();
    }

    public void CloseCurrentPanel()
    {
        dialogueBox.ClosePanel();
        dialogueQueue.RemoveAt(0);
        boxActive = false;
        ActivateDialogueBox();
    }


}
