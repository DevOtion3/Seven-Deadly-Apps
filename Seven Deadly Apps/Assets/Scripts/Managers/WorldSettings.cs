using UnityEngine;

public class WorldSettings : MonoBehaviour
{
    [SerializeField] private DialogueData LevelDialogueField;

    public static DialogueData LevelDialogue;

    private void Awake()
    {
        LevelDialogue = LevelDialogueField;
    }

    
}
