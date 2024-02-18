using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private int nodeID;


    private DialogueManager dialogueManager;
    new private BoxCollider collider;

    [SerializeField] bool enterTrigger, exitTrigger;
    private void Awake()
    {
        collider = GetComponent<BoxCollider>();
        dialogueManager = GameObject.Find("Manager").GetComponent<DialogueManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && enterTrigger)
        {
            TriggerDialogue();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && exitTrigger)
        {
            TriggerDialogue();
        }
    }

    private void TriggerDialogue()
    {
        dialogueManager.StartDialogue(nodeID);
    }
}
