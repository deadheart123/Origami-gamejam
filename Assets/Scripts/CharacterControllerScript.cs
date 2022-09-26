using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControllerScript : MonoBehaviour
{
    private CharacterController controller;
    private PlayerInputActions playerInputActions;
    private InputAction movement;

    [SerializeField] private float speed = 7.5f;
    private Vector3 velocity = new Vector3(0, 0, 0);

    private Vector3 moveVector;

    private bool isGrounded = true;
    [SerializeField] private GameObject groundCheckObject;
    [SerializeField] private float JumpHeight = 1;
    [SerializeField] private float gravityMultiplier = 1.8f;

    //[SerializeField] private float LookSpeed = 0.75f;

    [SerializeField] private Camera mainCamera;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        movement = playerInputActions.Player.Move;
        movement.Enable();

        playerInputActions.Player.Jump.performed += Jump;
        playerInputActions.Player.Jump.Enable();

        playerInputActions.Player.Interact.performed += Interact;
        playerInputActions.Player.Interact.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Player.Move.Disable();
        playerInputActions.Player.Jump.Disable();
        playerInputActions.Player.Interact.Disable();
    }

    void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }

    private void Gravity()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
        else
        {
            velocity.y += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        }
    }

    private void GroundCheck()
    {
        RaycastHit hit;
        float distance = 0.5f;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, distance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void Move()
    {
        moveVector = Quaternion.Euler(0, mainCamera.transform.eulerAngles.y, 0) * new Vector3(movement.ReadValue<Vector2>().x, 0, movement.ReadValue<Vector2>().y);

        controller.Move(speed * Time.deltaTime * moveVector);
        controller.Move(velocity * Time.deltaTime);

        /*if (moveVector != Vector3.zero)
        {
            transform.forward = Vector3.Lerp(transform.forward, moveVector, LookSpeed);
        }*/
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        if (isGrounded)
        {
            isGrounded = false;
            velocity.y = 0;
            velocity.y += Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y);
        }
    }

    private void Interact(InputAction.CallbackContext obj)
    {
        Debug.Log("Interact");
    }

    private void FixedUpdate()
    {
        GroundCheck();
        Gravity();

        Move();
    }

    void Update()
    {
        
    }
}
