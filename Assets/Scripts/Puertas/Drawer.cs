using UnityEngine;
using UnityEngine.InputSystem;

public class Drawer : MonoBehaviour
{
    [Header("Variables")]
    public float openPosition = -0.01583f;

    [SerializeField] private GameObject drawer;
    [SerializeField] private Animator anim;
    private InputAction Interact;
    private Quaternion openRotation;
    private Quaternion closedRotation;
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

    //void Start()
    //{
    //    closedRotation = drawe.transform.localRotation;
    //    openRotation = closedRotation * Quaternion.Euler(0, openAngle, 0);
    //}

    //public void Toggle()
    //{
    //    isOpen = !isOpen;

    //    drawer.transform.localPosition = openPosition;
    //}
}
