using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Dialogue Line", menuName="Dialogue Data")]
public class DialogueData : ScriptableObject
{
    [SerializeField] public List<DialogueNode> dialogueNodes;
}

[System.Serializable] public struct DialogueOption
{
    [SerializeField] public string optionText;
    [SerializeField] public int nextNodeID;
}

[System.Serializable]
public struct DialogueNode
{
    [SerializeField] public int nodeID;
    [SerializeField] public string dialogueText;
    [SerializeField] public AudioClip voiceLine;

    [SerializeField] public DialogueActions dialogueAction;

    [SerializeField] public bool lastLine;

    //Lists have better control over their data than arrays + are generics so can be used with any data type
    [SerializeField] public List<DialogueOption> options;
}

public enum DialogueActions
{
    None,
    ExecuteCode,
}