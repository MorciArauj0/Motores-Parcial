using UnityEngine;

public class bookZone : MonoBehaviour
{
    [Header ("Datos")]
    public BookObject bookToSet;



    public bool Occupied()
    {
        if(bookToSet == null)
        {
            return false;
        }
        return true;
    }

    public void SetBook (BookObject book)
    {
        Debug.Log("seteando");

        if(Occupied() || book == null)
        {
            return;
        }

        bookToSet = book;

        book.gameObject.SetActive (true);

        book.transform.SetParent(transform);

        book.transform.localPosition = Vector3.zero;
        book.transform.localRotation = Quaternion.identity;
    }

    public BookObject RemoveBook()
    {
        Debug.Log("removiendo");
        BookObject book = bookToSet;

        if (book != null)
        {
            //book.transform.SetParent(null);
            book.gameObject.SetActive (false);
            bookToSet.transform.SetParent(null);
            bookToSet = null;
            Debug.Log("removido");
        }

        return book;
    }
    
}
