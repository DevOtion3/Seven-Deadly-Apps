using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlothDialogue : MonoBehaviour
{
    private DialogueManager dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        // Check if dialogueManager is not null before calling StartDialogue
        if (dialogueManager != null)
        {
            dialogueManager.StartDialogue(0);
        }
        else
        {
            Debug.LogError("DialogueManager reference is null.");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
