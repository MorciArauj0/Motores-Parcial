using UnityEngine;

public enum BooksID
{
    archiversBook, meetingsBook, bathroomBook, breakroomBook, bossBook
}

public class booksCollect : MonoBehaviour
{
    [SerializeField] private BooksID booksID;
    public BooksID zoneBook => booksID;

    public void Collect()
    {
        gameObject.SetActive(false);
        Debug.Log("libro recolectado:" + booksID);
    }
}
