using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BooksPuzzleManager : MonoBehaviour, IInteractable
{
    [Header("Colecta")]
    [SerializeField] private List<ItemID> books = new List<ItemID>();
    [SerializeField] private Inventory inventory;
    private ItemID bookToSet;

    [Header("Puzzle")]
    [SerializeField] private GameObject selectedZone;
    [SerializeField] private GameObject puzzleCamera;
    [SerializeField] private GameObject reward;

    [Header("Libros")]
    [SerializeField] private GameObject bathroom;
    [SerializeField] private GameObject computers;
    [SerializeField] private GameObject archivers;
    [SerializeField] private GameObject restRoom;
    [SerializeField] private GameObject meetings;

    private GameObject bookSelected;

    [Header("Posicion")]
    [SerializeField] private Transform first;
    [SerializeField] private Transform second;
    [SerializeField] private Transform third;
    [SerializeField] private Transform fourth;
    [SerializeField] private Transform fifth;

    private Transform zoneToSet;

    private List<bool> zones;

    bool firstZone = false;
    bool secondZone = false;
    bool thirdZone = false;
    bool fourthZone = false;
    bool fifthZone = false;


    void Start()
    {
        zones.Add(firstZone);
        zones.Add(secondZone);
        zones.Add(thirdZone);
        zones.Add(fourthZone);
        zones.Add(fifthZone);
        //Vector3 firstBook = first.transform.position;
        //Vector3 secondBook = second.transform.position;
        //Vector3 thirBook = third.transform.position;
        //Vector3 fourthBook = fourth.transform.position;
        //Vector3 fifthBook = fifth.transform.position;
    }


    void Update()
    {
        if (puzzleCamera.activeSelf == true)
        {
            if (Keyboard.current.digit1Key.wasPressedThisFrame)
            {
                selectedZone.transform.position = first.position;
                zoneToSet = first;
                firstZone = true; 
                othersToFalse();
            }
            else if (Keyboard.current.digit2Key.wasPressedThisFrame)
            {
                selectedZone.transform.position = second.position;
                zoneToSet = second;
                secondZone = true;
                othersToFalse();
            }

            else if (Keyboard.current.digit3Key.wasPressedThisFrame)
            {
                selectedZone.transform.position = third.position;
                zoneToSet = third;
                thirdZone = true;
                othersToFalse();
            }

            else if (Keyboard.current.digit4Key.wasPressedThisFrame)
            {
                selectedZone.transform.position = fourth.position;
                zoneToSet = fourth;
                fourthZone = true;
                othersToFalse();
            }

            else if (Keyboard.current.digit5Key.wasPressedThisFrame)
            {
                selectedZone.transform.position = fifth.position;
                zoneToSet = fifth;
                fifthZone = true;
                othersToFalse();
            }
        }
    }

    public void othersToFalse()
    {
        

        for(int i = 0; i  < zones.Count; i++)
        {
            int selected = zones.IndexOf(true);
            if (i != selected)
            {
                zones[i] = false;
                break;
            }
            else
            {

            }
        }
    }


    public void SetBook()
    {
        if(firstZone == true && Keyboard.current.eKey.wasPressedThisFrame)
        {
          Vector3 pos = zoneToSet != null ? zoneToSet.position : transform.position;
          Quaternion rot = zoneToSet != null ? zoneToSet.rotation : Quaternion.identity;
          Instantiate(bookSelected, pos, rot);
            
        }
    }

    public void Interact()
    {
        PuzzleMode();
    }

    void PuzzleMode()
    {

        puzzleCamera.SetActive(true);
        selectedZone.SetActive(true);

        Debug.Log("libros");
    }

    //void setBook()
    //{
    //    inventory.HasItem(bookToSet);
    //    //GameObject selectedBook;


     


    //}

    //public void CheckPuzzle()
    //{
    //    foreach (bookZone space in books)
    //    {
    //        if (slot == null || !slot.IsOccupied)
    //            return;
    //    }

    //    foreach (BookSlot slot in slots)
    //    {
    //        BookData book = slot.GetPlacedBook();

    //        if (book.bookID != slot.requiredBookID)
    //        {
    //            Debug.Log("Orden incorrecto");
    //            return;
    //        }
    //    }

    //    CompletePuzzle();
    //}
}

