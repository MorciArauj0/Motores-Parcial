using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BookPuzzleLogic : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private BooksPuzzleManager puzzleManager;

    [SerializeField] private bookZone[] zones;
    [SerializeField] private BookObject[] books;
    [SerializeField] private List<BookObject> booksCollected = new List<BookObject>();
    //public bookZone[] slots;
    private bookZone selectedZone;
    private BookObject selectedBook;

    //libro o slot??
    private enum SelectionState
    {
        SelectingZone, SelectingBook
    }
    private SelectionState currentState = SelectionState.SelectingZone;

    //libro o slot??

    //teclas de botones
    private Key[] numberKeys = { Key.Digit1, Key.Digit2, Key.Digit3, Key.Digit4, Key.Digit5 };

    void Update()
    {
        if(currentState == SelectionState.SelectingZone)
        {
            SelectZone();
        }
        else if (currentState == SelectionState.SelectingBook)
        {
            SelectBook();
        }
    }

    void SelectZone()
    {
        for (int i = 0; i < zones.Length; i++)
        {
            if(Keyboard.current[numberKeys[i]].wasPressedThisFrame)
            {
                selectedZone = zones[i];
            }
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            selectedZone = null;
            return;
        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if(selectedZone == null)
            {
                return;
            }

            if (selectedZone.Occupied())
            {
                Debug.Log(selectedZone.Occupied());
                return;
            }

            ChangeBooksCollected();
            if(inventory.objetosEnInventario == 0)
            {
                Debug.Log("no agarraste libros");
                return;
            }
            Debug.Log("me superpongo, hola");
        }

        currentState = SelectionState.SelectingBook;
        return;
    }

    void ChangeBooksCollected()
    {
        booksCollected.Clear();

        foreach (BookObject book in  books)
        {
            if (book != null && inventory.HasItem(book.ID))
            {
                booksCollected.Add(book);
            }
        }
    }
    void SelectBook()
    {
        for (int i = 0; i < booksCollected.Count; i++)
        {
            if (Keyboard.current[numberKeys[i]].wasPressedThisFrame)
            {
                selectedBook = booksCollected[i];
                Debug.Log("seleccionaste libro " + i);
            }
        }

        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            selectedZone = null;
            selectedBook = null;
            currentState = SelectionState.SelectingZone;

            return;
        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if( selectedZone == null)
            {
                return;
            }
        }


    }


    public bool SetInventoryBook(int index)
    {
        ChangeBooksCollected();

        if(selectedZone == null)
        {
            return false;
        }

        if(index < 0 || index >= booksCollected.Count)
        {
            return false;
        }

        selectedBook = booksCollected[index];

        if(!inventory.HasItem(selectedBook.ID))
        {
            return false;
        }

        inventory.RemoveItem(selectedBook.ID);
        selectedZone.SetBook(selectedBook);
        Debug.Log("LIBRO COLOCATE POR FAVOR");

        selectedZone = null;
        selectedBook = null;

        puzzleManager.CheckAnswer();

        return true;

    }

    public bool TrySelectZone(int index)
    {

        if(index < 0 || index >= zones.Length)
        {
            Debug.Log("basta por favor");
            return false;
        }

        if (zones[index].Occupied())
        {
            inventory.AddItem(zones[index].RemoveBook().ID);

            Debug.Log("ocupadoo");
            return false;  
        }

        ChangeBooksCollected();

        if(booksCollected.Count == 0)
        {
            Debug.Log("agarra libros dale");
            return false;
        }

        selectedZone = zones[index];
        Debug.Log("podes seguir");
        return true;
    }


    public int booksCollectedCount()
    {
        ChangeBooksCollected();
        return booksCollected.Count;
    }

    public void CancelSelection()
    {
        selectedZone = null;
    }

}
