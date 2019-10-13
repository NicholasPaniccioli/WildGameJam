using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public bool aldreadyTriggered = false;

    public GameObject dialgouePrefab;
    public string dialogue;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = DialogueManager.Instance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!aldreadyTriggered)
        {
            dialogueManager.CreateDialogueBox(new DialogueBoxDetails() { prefab = dialgouePrefab, text = dialogue });
            aldreadyTriggered = true;
        }
    }
}
