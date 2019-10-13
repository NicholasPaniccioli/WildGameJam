using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBoxDetails
{
    public GameObject prefab;
    public string text;
}

public class DialogueBox : MonoBehaviour
{
    public GameObject canvas;
    public Text dialogue;
    public float displayTime = 3.5f;

    public GameObject dialogueObject;
    public GameObject currentDialoguePanelPrefab;
    public GameObject defaultDialoguePanelPrefab;


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
        
        dialogueObject = GameObject.Instantiate(details.prefab, Vector3.zero, Quaternion.identity);
        dialogueObject.transform.parent = canvas.transform;

        dialogueObject.SetActive(true);

        this.dialogue.text = details.text;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClosePanel()
    {
        GameObject.Destroy(dialogueObject);
    }
}
