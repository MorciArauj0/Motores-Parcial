using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Cinemachine;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]

public class Character : MonoBehaviour
{
    //============================================
    //MOVIMIENTO/VARIABLES
    //============================================

    [Header("Velocidades")]
    [SerializeField] private float normalSpeed = 10f;
    [SerializeField] private float sprintSpeed = 15f;


    [Header("Rotación")]
    [SerializeField] private float rotationSpeed = 120f;


    [Header("Cámara")]
    [SerializeField] private Transform cameraTransform;


    [Header("Animaciones")]
    [SerializeField] private Animator animator;


    [Header("Gravedad")]
    private float gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 3f;
    private float verticalVelocity;


    //============================================
    //REFERENCIAS Y VARIABLES INTERNAS
    //============================================

    private PlayerInput playerInput;
    private CharacterController characterController;


    [Header("Vector")]
    private Vector2 inputVector;
    private Vector2 look;


    private float speed;
    private float pitch = 0f;
    public bool IsInteracting => playerInput.actions["Interact"].IsPressed();


    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        speed = normalSpeed;
    }

    void Update()
    {
        //gravedad
        bool isGrounded = characterController.isGrounded;
        if (isGrounded && verticalVelocity < 0f)
        {
            verticalVelocity = -2f;
        }

        verticalVelocity += gravity * gravityMultiplier * Time.deltaTime;

        //movimiento
        inputVector = playerInput.actions["Basic Move"].ReadValue<Vector2>();

        //velocidad
        bool running = playerInput.actions["Run"].IsPressed();

        if (running)
            speed = sprintSpeed;
        else
            speed = normalSpeed;

        //camara
        look = playerInput.actions["Camera Direction"].ReadValue<Vector2>();


        //funciones
        HandleMovement();
        HandleLook();
        ApplyGravity();
        HandleAnimations();
    }

    private void HandleMovement()
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 move = (forward * inputVector.y) + (right * inputVector.x);
        characterController.Move(move * speed * Time.deltaTime);
    }

    private void HandleLook()
    {
        float mouseX = look.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);

        pitch -= look.y * rotationSpeed * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    private void ApplyGravity()
    {
        Vector3 gravityVector = new Vector3(0f, verticalVelocity, 0f);
        characterController.Move(gravityVector * Time.deltaTime);
    }

    private void HandleAnimations()
    {
        bool isWalking = animator.GetBool("IsWalking");
        bool isRunning = animator.GetBool("IsRunning");

        if (inputVector.magnitude > 0f)
        {
            if (speed == sprintSpeed && !isRunning)
            {
                animator.SetBool("IsRunning", true);
                animator.SetBool("IsWalking", false);
                
            }
            else if (speed == normalSpeed && !isWalking)
            {
                animator.SetBool("IsWalking", true);
                animator.SetBool("IsRunning", false);
            }
        }
        else
        {
            if (isWalking || isRunning)
            {
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsRunning", false);
            }
        }
    }
}
