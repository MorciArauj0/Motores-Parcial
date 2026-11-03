using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SetBooks : MonoBehaviour, IInteractable
{
    [Header("Colecta")]
    [SerializeField] private List<BooksID> books = new List<BooksID>();
    [SerializeField] private Inventory inventory;

    [Header("Ordenar")]
    [SerializeField] private GameObject selectedZone;
    [SerializeField] private GameObject puzzleCamera; 

    //ocultar al jugador

    [SerializeField] private Transform first;
    [SerializeField] private Transform second;
    [SerializeField] private Transform third;
    [SerializeField] private Transform fourth;
    [SerializeField] private Transform fifth;

    [Header("Puzzle")]
    [SerializeField] private GameObject reward;

    void Start()
    {
        Vector3 firstBook = first.transform.position;
        Vector3 secondBook = second.transform.position;
        Vector3 thirBook = third.transform.position;
        Vector3 fourthBook = fourth.transform.position;
        Vector3 fifthBook = fifth.transform.position;
    }

    public void Interact()
    {
        PuzzleMode();
    }

    void Update()
    {
        if (puzzleCamera.activeSelf == true)
        {
            if (Keyboard.current.digit1Key.wasPressedThisFrame)
            {
                selectedZone.transform.position = first.position;
            }

            else if (Keyboard.current.digit2Key.wasPressedThisFrame)
            {
                selectedZone.transform.position = second.position;
            }

            else if (Keyboard.current.digit3Key.wasPressedThisFrame)
            {
                selectedZone.transform.position = third.position;
            }

            else if (Keyboard.current.digit4Key.wasPressedThisFrame)
            {
                selectedZone.transform.position = fourth.position;
            }

            else if (Keyboard.current.digit5Key.wasPressedThisFrame)
            {
                selectedZone.transform.position = fifth.position;
            }
        }
    }

    void PuzzleMode()
    {
        puzzleCamera.SetActive(true);
        selectedZone.SetActive(true);

        Debug.Log("libros");
    }
}
