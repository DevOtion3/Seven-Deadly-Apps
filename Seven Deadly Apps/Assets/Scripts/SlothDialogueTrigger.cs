using UnityEngine;

public class SlothDialogueTrigger : MonoBehaviour
{
    
    [SerializeField] private DialogueManager dialogueManager;

    private void Awake()
    {   
        dialogueManager = GameObject.Find("Manager").GetComponent<DialogueManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager.StartDialogue(0);
    }


}
