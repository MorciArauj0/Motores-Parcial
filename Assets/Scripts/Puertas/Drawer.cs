using UnityEngine;
using UnityEngine.InputSystem;

public class Drawer : MonoBehaviour
{
    [Header("Variables")]

    [SerializeField] private GameObject drawer;
    [SerializeField] private Animator anim;
    private InputAction Interact;
    private bool isOpen = false;
    private bool isClose = true;

    void Start()
    {
        anim = GetComponent<Animator>();
        Interact = InputSystem.actions.FindAction("Interact");
    }
    private void OnCollisionStay(Collision collision)
    {
        //if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButton(0))
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("zona cajon");
            if (Keyboard.current.eKey.wasPressedThisFrame || Mouse.current.leftButton.isPressed)
            {
                if (isOpen == false && isClose == true)
                {
                    anim.SetBool("Opening", true);
                    anim.SetBool("Closing", false);
                    isOpen = true;
                    isClose = false;
                }

                if (isOpen == true && isClose == false)
                {
                    anim.SetBool("Opening", false);
                    anim.SetBool("Closing", true);

                    isOpen = false;
                    isClose = true;
                }
                Debug.Log("te odio new input system");
            }
        }
    }

}
