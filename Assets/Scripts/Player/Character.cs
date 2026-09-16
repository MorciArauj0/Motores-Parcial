using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Unity.Cinemachine;

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


    [Header("Objeto")]
    [SerializeField] private GameObject objectPrefab;



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

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        characterController = GetComponent<CharacterController>();

        speed = normalSpeed;
    }

    void Update()
    {
        inputVector = playerInput.actions["Basic Move"].ReadValue<Vector2>();


        bool running = playerInput.actions["Run"].IsPressed();

        if (running)
            speed = sprintSpeed;
        else
            speed = normalSpeed;


        look = playerInput.actions["Camera Direction"].ReadValue<Vector2>();


        HandleMovement();
        HandleLook();
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

}
