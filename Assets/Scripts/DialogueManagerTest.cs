using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText; // Reference to the UI Text component to display dialogue
    public Button choice1Button; // Reference to the UI Button component for choice 1
    public Button choice2Button; // Reference to the UI Button component for choice 2

    private void Start()
    {
        // Start the dialogue
        StartDialogue();
    }

    void StartDialogue()
    {
        // Set initial dialogue text
        dialogueText.text = "An UNKNOWN FAMILIAR VOICE seems to talk directly in your brain";

        // Set up the choices
        choice1Button.gameObject.SetActive(true);
        choice2Button.gameObject.SetActive(true);

        // Set the text for the choice buttons
        choice1Button.GetComponentInChildren<Text>().text = "I agree sleeping is great (sleep a bit more)";
        choice2Button.GetComponentInChildren<Text>().text = "Nah, I’ve slept enough. Where am I by the way ?";
    }

    // Method to handle choice 1
    public void OnChoice1Clicked()
    {
        // Handle choice 1
        Debug.Log("Choice 1 clicked!");
        // Perform actions corresponding to choice 1, e.g., advancing the dialogue
    }

    // Method to handle choice 2
    public void OnChoice2Clicked()
    {
        // Handle choice 2
        Debug.Log("Choice 2 clicked!");
        // Perform actions corresponding to choice 2, e.g., advancing the dialogue
    }
}
