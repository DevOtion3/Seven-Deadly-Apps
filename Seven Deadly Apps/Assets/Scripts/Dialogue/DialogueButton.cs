using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueButton : MonoBehaviour
{
    public int nextNodeID { get; private set; }
    public bool lastLine {  get; private set; }
    public int optionID {  get; private set; }
    public DialogueManager dialogueManager;

    public void ContinueDialogue()
    {
        if(lastLine)
            dialogueManager.EndDialogue();
        else
            dialogueManager.OnOptionSelected(optionID);
    }

    public void SetOptionID(int value)
    {
        optionID = value;
    }
    
    public void SetNextNodeID(int Value)
    {
        nextNodeID = Value;
    }
    
    public void SetLastLine(bool Value)
    { 
        lastLine = Value;
    }
}
