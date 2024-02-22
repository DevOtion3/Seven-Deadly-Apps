using FMOD.Studio;
using FMODUnity;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using STOP_MODE = FMOD.Studio.STOP_MODE;

public class DialogueManager : Singleton<DialogueManager>
{
    private const int NODE_ID_OFFSET = 1;
    
    //the reason we use -1 is that dialogue lines that have no options get set to -1 automatically
    private const int END_DIALOGUE_NODE_ID = -1;

    [SerializeField] private GameObject buttonPrefab;

    private TMP_Text dialogueText;
    private GameObject buttonContainer;

    private DialogueNode currentNode;
    private DialogueData dialogueData;
    private bool inDialogue;
    private EventInstance dialogueAudioInstance;

    [SerializeField] private GameObject dialoguePanel;

    protected override void Awake()
    {
        base.Awake();
        dialogueText = dialoguePanel.GetComponentInChildren<TMP_Text>();
        buttonContainer = dialoguePanel.GetComponentInChildren<VerticalLayoutGroup>().gameObject;

        if (dialoguePanel == null)
            Debug.LogError("Missing Dialogue Panel!");
    }

    private void Start()
    {
        var emptyOption = new DialogueOption();
        dialogueData = WorldSettings.LevelDialogue;
        dialogueAudioInstance = RuntimeManager.CreateInstance(dialogueData.dialogueAudio);

        // very hacky code so designers don't have to add in empty dialogue options themselves
        foreach (var node in dialogueData.dialogueNodes)
        {
           if (node.options.Count == 0)
                node.options.Add(emptyOption);
        }
    }

    public void StartDialogue(int startingNodeID)
    {
        dialoguePanel.SetActive(true);
        SetCurrentNode(startingNodeID);
        DisplayDialogue();
        inDialogue = true;
    }
    
    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        inDialogue = false;
    }

    private void SetCurrentNode(int nodeID)
    {
        var currentIndex = 0;
        if(dialogueData.dialogueNodes.Count > 0) 
        {
            foreach (var node in dialogueData.dialogueNodes)
            {
                if (node.nodeID == nodeID)
                {
                    currentNode = node;
                    break;
                }
                else if (currentIndex >= dialogueData.dialogueNodes.Count) //Error checking in case you input an invalid nodeID
                    Debug.LogError($"Could not find Dialogue Node at ID:({nodeID})");
                currentIndex++;
            }
        }
        else
            Debug.LogError("Dialogue Node count is less than or equal to 0!");
    }

    private void DisplayDialogue()
    {
        ClearDialogueDisplay();

        dialogueText.text = currentNode.dialogueText;
        
        dialogueAudioInstance.stop(STOP_MODE.IMMEDIATE);
        dialogueAudioInstance.start();

        for (var i = 0; i < currentNode.options.Count; i++)
        {
            //this is the easiest way I could think of to do this, I feel like you can do this better with unity events but who knows
            var button = Instantiate(buttonPrefab, buttonContainer.transform);
            var optionText = button.GetComponentInChildren<TMP_Text>();
            var dialogueButton = button.GetComponent<DialogueButton>();
            dialogueButton.dialogueManager = this;

            //decrease by id offset (-1) because i is one greater than the actual nextNodeID 
            dialogueButton.SetNextNodeID(currentNode.options[i].nextNodeID - NODE_ID_OFFSET);
            dialogueButton.SetLastLine(currentNode.lastLine);
            dialogueButton.SetOptionID(i);

            if ((currentNode.options[i].nextNodeID - NODE_ID_OFFSET) == END_DIALOGUE_NODE_ID)
                optionText.text = "End Dialogue";
            else
                optionText.text = currentNode.options[i].optionText;
        }
    }

    private void ClearDialogueDisplay()
    {
        if(buttonContainer.transform.childCount > 0) 
        { 
            foreach(Transform childButton in buttonContainer.transform)
            {
                GameObject child = childButton.gameObject;
                Destroy(child);
            }
        }
    }

    public bool IsInDialogue()
    {
        return inDialogue;
    }
    
    public void OnOptionSelected(int optionIndex)
    {
        int nextNodeID = currentNode.options[optionIndex].nextNodeID;
        SetCurrentNode(nextNodeID);
        DisplayDialogue();
    }
}