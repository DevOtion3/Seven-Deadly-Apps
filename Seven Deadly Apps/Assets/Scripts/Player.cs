using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

/*
Moves player character in game world, may neeed seprate class to control wheter play should move or not, we'll see
*/

public class Player : MonoBehaviour{

    #region Consts
    private const int GRAVITY_MULTIPLIER = 50;
    #endregion

    public InputActionAsset controls;
    Dictionary<string, InputAction> inputs;

    private CharacterController characterController;

    public bool isCombat;

    public float moveSpeed = 1;

    public float combatMoveSpeed = 1;

    float gravityVelocity;

    [SerializeField] private DialogueManager dialogueManager;

    private void Awake()
    {
        //This is bad!
        //dialogueManager = GameObject.Find("Manager").GetComponent<DialogueManager>();

        characterController = GetComponent<CharacterController>();
    }

    private void Start(){
        inputs = new Dictionary<string, InputAction>();
        InputActionMap inputMap = controls.FindActionMap("Player");
        inputMap.Enable();
        inputs.Add("Movement", inputMap.FindAction("Movement"));
    }

    private void Update(){

        PlayerInput();
        Debugging();
    }

    private void PlayerInput()
    {
        Vector2 input = inputs["Movement"].ReadValue<Vector2>();
        Vector3 movement = new Vector3();
        movement += transform.forward * input.y;
        movement += transform.right * input.x;
        movement *= isCombat ? combatMoveSpeed : moveSpeed;
        movement.y = Mathf.Clamp(characterController.velocity.y + (Physics.gravity.y * Time.deltaTime), Physics.gravity.y * GRAVITY_MULTIPLIER, 0);
        characterController.Move(movement * Time.deltaTime);
    }

   private void Debugging()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            dialogueManager.StartDialogue(0);
        }
    }
}
