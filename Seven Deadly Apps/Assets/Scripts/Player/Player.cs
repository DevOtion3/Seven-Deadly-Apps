using UnityEngine;
using FMODUnity; 
public class Player : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 2f;
    [SerializeField] private float runSpeed = 3f;

    private Animator animator;
    private CharacterController characterController;
    private FMOD_AnimationEvent animEvent;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        animEvent = GetComponent<FMOD_AnimationEvent>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        bool isMoving = moveDirection.magnitude > 0.1f;
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        if (isMoving)
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            
        }

        //SO MUCH BETTER THAN 30 IF/ELSE STATEMENTS
        float moveSpeed = isMoving ? (isRunning ? runSpeed : walkSpeed) : 0f;

        animator.SetFloat("MoveSpeed", moveSpeed);
        animEvent.SetParameter("Speed", moveSpeed);

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

    }
}
