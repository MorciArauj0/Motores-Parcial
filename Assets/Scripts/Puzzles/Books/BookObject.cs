using UnityEngine;


public class BookObject : MonoBehaviour, ICollectable
{
    [SerializeField] private BookPuzzleLogic bookPuzzleLogic;
    [SerializeField] private BookObject myself;
    private bool isCollected = false;
    [SerializeField] private int whichBook;
    [SerializeField] private ItemID id;
    public AudioSource audio;
    [SerializeField] private GameObject PuzzleZone;
    public ItemID ID => id;
    public int bookID => whichBook;

    public void Collect()
    {
        if(isCollected)
        {
            return;
        }
        
        AudioSource myAudio = gameObject.GetComponent<AudioSource>();
        myAudio.enabled = false;
        audio.Stop();
        isCollected = true;
        gameObject.SetActive(false);
        bookPuzzleLogic.AddBook(myself);

        if(PuzzleZone.activeSelf == false)
        {
            PuzzleZone.SetActive(true);
        }
    }



}
