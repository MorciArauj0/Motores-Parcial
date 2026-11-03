using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class bookZone : MonoBehaviour
{
    [Header ("Datos")]
    //public ItemID neededBook;
    public CollectObjects correctBook;


    //[Header("Posicion")]
    //public Transform first;
    //public Transform second;
    //public Transform third;
    //public Transform fourth;
    //public Transform fifth;

    [Header("Variables privadas")]
    private CollectObjects settedBook;
    private Transform settedPosition;
    public bool Setted = false;

   
    //[SerializeField] private List<GameObject> booksPlace = new List<GameObject>();

    void Update()
    {
        if(settedBook != null)
        {
            Setted = true;
        }
    }

    public bool TrySetBook(CollectObjects book)
    {
        settedBook = book;

        if(Setted == true || book == null)
        {
            return false;
        }

        if (book != correctBook)
        {
            return false;
        }

        Debug.Log("libro " + book.ID + " puesto.");

        return true;
    }
    
}
