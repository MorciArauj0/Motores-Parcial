using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SetBooks : MonoBehaviour
{
    [Header("Colecta")]
    [SerializeField] private List<BooksID> books = new List<BooksID>();
    [SerializeField] private Inventory inventory;

    [Header("Ordenar")]
    [SerializeField] private GameObject selectedZone;
    [SerializeField] private GameObject puzzleCamera; 

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

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (Keyboard.current.eKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame)
            {
                puzzleCamera.SetActive(true);
                selectedZone.SetActive(true);
            }

            if (puzzleCamera.activeSelf == true)
            {
                if (Keyboard.current.digit1Key.wasPressedThisFrame)
                {
                    selectedZone.transform.position = first.position;
                }
                else if (Keyboard.current.digit2Key.wasPressedThisFrame)
                {
                    selectedZone.transform.position = first.position;
                }
            }
        }
        
    }
    void Update()
    {
        
    }
}
