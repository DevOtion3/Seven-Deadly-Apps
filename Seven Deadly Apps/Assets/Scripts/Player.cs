using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

/*
Moves player character in game world, may neeed seprate class to control wheter play should move or not, we'll see
*/

public class Player : MonoBehaviour{
    public InputActionAsset controls;
    Dictionary<string, InputAction> inputs;

    public CharacterController characterController;

    public bool isCombat;

    public float moveSpeed = 1;

    public float combatMoveSpeed = 1;

    void Start(){
        inputs = new Dictionary<string, InputAction>();
        InputActionMap inputMap = controls.FindActionMap("Player");
        inputMap.Enable();
        inputs.Add("Movement", inputMap.FindAction("Movement"));
    }

    void Update(){
        Vector2 input = inputs["Movement"].ReadValue<Vector2>();
        Vector3 movement = new Vector3();
        movement += transform.forward * input.y;
        movement += transform.right * input.x;
        movement *= isCombat ? combatMoveSpeed : moveSpeed;
        characterController.Move(movement);
    }
}
