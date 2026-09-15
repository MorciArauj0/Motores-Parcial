using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Acceso al componente Character Controller
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        speed = normalSpeed;
    }
    // Acceso al componente Character Controller

    // Variables
    [SerializeField] private int normalSpeed;
    [SerializeField] private int runningSpeed;
    [SerializeField] private int rotateSpeed;

    private Vector3 move;
    private int speed;
    private int rotate;
    // Variables

    //Handles -> métodos con lógicas 

    private void HandleMovement()
    {
        // Hasta ahí llega mi conocimiento
    }

    private void HandleRotation ()
    {
        float rotation = rotate * rotateSpeed * Time.deltaTime;
    }

    private void HandleCollect()
    {
        
    }

    //Handles -> métodos con lógicas 

    // Eventos del mapa de movimiento
    public void OnBasicMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector3>();
    }

    public void OnCameraDirection(InputAction.CallbackContext context)
    {
        rotate = context.ReadValue<int>();
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            speed = runningSpeed;
        }
        if (context.canceled)
        {
            speed = normalSpeed;
        }
    }

    public void OnGet(InputAction.CallbackContext context)
    {

    }
    // Eventos del mapa de movimiento
}
