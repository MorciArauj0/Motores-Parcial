using UnityEngine;


public class BookObject : MonoBehaviour, ICollectable
{
    private bool isCollected = false;
    [SerializeField] private int whichBook;
    [SerializeField] private ItemID id;
    public ItemID ID => id;

    public int bookID => whichBook;

    public void Collect()
    {
        if(isCollected)
        {
            return;
        }
        isCollected = true;
        gameObject.SetActive(false);
    }

}
