using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    //MOVIMIENTO

    //velocidades del pj
    [SerializeField] private float speed = 5f;
    [SerializeField] private float speedRun = 15f;
    private float currentSpeed;


    //rotación del pj
    //[SerializeField] private float rotationSpeed = 120f;


    //REFERENCIAS
    private PlayerInput playerInput;
    private CharacterController characterController;


    //vector
    private Vector2 inputVector;



    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        characterController = GetComponent<CharacterController>();

        currentSpeed = speed;
    }
    

    void Update()
    {
        inputVector = playerInput.actions["Basic Move"].ReadValue<Vector2>();


        bool running = playerInput.actions["Run"].IsPressed();

        if (running)
            currentSpeed = speedRun;
        else
            currentSpeed = speed;
    }


    void FixedUpdate()
    {
        Vector3 move = new Vector3(inputVector.x, 0f, inputVector.y);

        characterController.Move(move * currentSpeed * Time.fixedDeltaTime);
    }



}
