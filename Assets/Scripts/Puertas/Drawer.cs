using UnityEngine;
using UnityEngine.InputSystem;

public class Drawer : MonoBehaviour, IInteractable
{
    [Header("Variables")]

    [SerializeField] private GameObject drawer;
    [SerializeField] private GameObject lantern;
    [SerializeField] private Animator anim;
    private InputAction Interaction;
    private bool isOpen = false;
    private bool isClose = true;

    public bool Opened => isOpen; 

    void Start()
    {
        anim = GetComponent<Animator>();
        Interaction = InputSystem.actions.FindAction("Interact");
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("zona cajon");
            Interact();
        }
    }

    public void Interact()
    {
        if (isOpen == false && isClose == true)
        {
            anim.SetBool("Opening", true);
            anim.SetBool("Closing", false);
            isOpen = true;
            isClose = false;
            Debug.Log("tendria que abrirse");
        }

            if(lantern.activeSelf == false)
        {
            if (isOpen == true && isClose == false)
            {
                anim.SetBool("Opening", false);
                anim.SetBool("Closing", true);

                isOpen = false;
                isClose = true;
                Debug.Log("tendria que cerrarse");
            }
        }
        
        Debug.Log("te odio new input system");
        //}
    }

}
