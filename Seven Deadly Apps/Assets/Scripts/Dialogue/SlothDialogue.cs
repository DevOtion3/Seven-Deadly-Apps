using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlothDialogue : MonoBehaviour
{
    private DialogueManager DialogueManager;

    // Start is called before the first frame update
    void Start()
    {

        DialogueManager.StartDialogue(0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
