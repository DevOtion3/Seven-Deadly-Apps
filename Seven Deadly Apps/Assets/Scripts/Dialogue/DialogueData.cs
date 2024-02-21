using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

[CreateAssetMenu(fileName="New Dialogue Asset", menuName="Dialogue Asset")]
public class DialogueData : ScriptableObject
{
    [SerializeField] public EventReference dialogueAudio;
    [SerializeField] public List<DialogueNode> dialogueNodes;
}

[System.Serializable] public struct DialogueOption
{
    [Tooltip("The text that will show up on the buttons")]
    [SerializeField] public string optionText;

    [Tooltip("The ID of the Node you will go to next")]
    [SerializeField] public int nextNodeID;
}

[System.Serializable]
public struct DialogueNode
{
    [SerializeField] public int nodeID;
    [SerializeField] public string dialogueText;

    [Tooltip("None: No Special Behaviour | Execute Code: Will execute any code placed")]
    [SerializeField] public DialogueActions dialogueAction;

    [SerializeField] public bool lastLine;

    //Lists have better control over their data than arrays + are generics so can be used with any data type
    [Tooltip("Dialogue choices. If empty, will be treated like last line of dialogue!")]
    [SerializeField] public List<DialogueOption> options;
}

public enum DialogueActions
{
    None,
    ExecuteCode,
}