using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DialogueDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DialogueData dialogueData = (DialogueData)target;

        EditorGUILayout.LabelField("Dialogue Nodes", EditorStyles.boldLabel);

        if (dialogueData.dialogueNodes != null)
        {
            for (int i = 0; i < dialogueData.dialogueNodes.Count; i++)
            {
                EditorGUILayout.LabelField("Node " + i.ToString(), EditorStyles.boldLabel);
                EditorGUI.indentLevel++;

                EditorGUILayout.LabelField("Node ID: " + dialogueData.dialogueNodes[i].nodeID.ToString());
                EditorGUILayout.LabelField("Dialogue Text:", dialogueData.dialogueNodes[i].dialogueText);

                if (dialogueData.dialogueNodes[i].options != null)
                {
                    for (int j = 0; j < dialogueData.dialogueNodes[i].options.Count; j++)
                    {
                        EditorGUILayout.LabelField("Option " + j.ToString(), EditorStyles.boldLabel);
                        EditorGUI.indentLevel++;

                        EditorGUILayout.LabelField("Option Text:", dialogueData.dialogueNodes[i].options[j].optionText);
                        EditorGUILayout.LabelField("Next Node ID: " + dialogueData.dialogueNodes[i].options[j].nextNodeID.ToString());

                        EditorGUI.indentLevel--;
                    }
                }

                EditorGUI.indentLevel--;
            }
        }

        // Add button to create a new dialogue node
        if (GUILayout.Button("Add Dialogue Node"))
        {
            AddDialogueNode(dialogueData);
        }
    }

    // Method to add a new dialogue node
    private void AddDialogueNode(DialogueData dialogueData)
    {
        DialogueNode newDialogueNode = new DialogueNode();
        newDialogueNode.nodeID = dialogueData.dialogueNodes.Count;
        dialogueData.dialogueNodes.Add(newDialogueNode);
    }
}
