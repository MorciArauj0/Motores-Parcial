using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Drawer : MonoBehaviour, IInteractable
{
    [Header("Variables")]

    [SerializeField] private GameObject drawer;
    [SerializeField] private Animator anim;

    //[SerializeField] private InsideDrawer inside;


    private InputAction Interaction;
    private bool isOpen = false;
    private bool isClose = true;
    private bool closeIT = false;
    private bool openIT = true;

    public bool Opened => isOpen; 

    void Start()
    {
        anim = GetComponent<Animator>();
        Interaction = InputSystem.actions.FindAction("Interact");
        //inside = GetComponent<InsideDrawer>();

        //inside.Collected += CloseDrawer;
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
        if (openIT == true)
        {
            anim.SetBool("Opening", true);
            anim.SetBool("Closing", false);
            isOpen = true;
            isClose = false;
            Debug.Log("tendria que abrirse");
        }

        if (closeIT == true)
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
    }

    //private void CloseDrawer(bool collected)
    //{
    //    lanternCollected = true;
    //}

    public void canCloseDrawer()
    {
        closeIT = true;
        openIT = false;
    }

    public void canOpenDrawer()
    {
        closeIT = false;
        openIT = true;
    }

}
