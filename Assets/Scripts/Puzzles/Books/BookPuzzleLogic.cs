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

    public void AddBook(BookObject book)
    {
        booksCollected.Add(book);
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

            //ActualizarBooksCollected();
            
            if (inventory.objetosEnInventario == 0)
            {
                Debug.Log("no agarraste libros");
                return;
            }
        }

        currentState = SelectionState.SelectingBook;
        return;
    }

    void ActualizarBooksCollected()
    {
        //booksCollected.Clear();

        foreach (BookObject book in books)
        {
            if (book != null && inventory.HasItem(book.ID))
            {
                booksCollected.Add(book);
            }
        }

        for(int i = 0; i < inventory.objetosEnInventario; i++)
        {
            for (int j = 0; j < booksCollected.Count; j++)
            {
                if (inventory.inventarioPublico[i] == booksCollected[j].ID)
                {

                }

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
                //selectedBook.audio.Play();
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
        selectedBook = booksCollected[index];
        Debug.Log(selectedBook.ID);
        booksCollected.Remove(selectedBook);
        Debug.Log(selectedBook.ID);
        //ActualizarBooksCollected();

        if (selectedZone == null)
        {
            return false;
        }

        //if(index < 0 || index >= booksCollected.Count)
        //{
        //    return false;
        //}

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

        //if(index < 0 || index >= zones.Length)
        //{
        //    Debug.Log("basta por favor");
        //    return false;
        //}

        if (zones[index].Occupied())
        {
            BookObject book = zones[index].RemoveBook();
            inventory.AddItem(book.ID);
            booksCollected.Add(book);
            Debug.Log("ocupadoo");
            return false;  
        }

        //ActualizarBooksCollected();

        if (booksCollected.Count == 0)
        {
            Debug.Log("agarra libros dale");
            return false;
        }

        selectedZone = zones[index];
        Debug.Log("podes seguir");
        return true;
    }


    //public int booksCollectedCount()
    //{
    //    ActualizarBooksCollected();
    //    return booksCollected.Count;
    //}

    public void CancelSelection()
    {
        selectedZone = null;
    }


}
