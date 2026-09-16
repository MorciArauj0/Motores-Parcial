using UnityEngine;

public enum ItemID
{
    paper, paintObject, vase, lintern, archiveKey, bossKey, breakKey
}

public class CollectObjects : MonoBehaviour, ICollectable
{
    [SerializeField] private Character character;
    [SerializeField] private ItemID id;
    public ItemID ID => id;

    public void Collect()
    {
        if(character.interacting == true)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        character = GetComponent<Character>();
    }

   void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && character.interacting == true)
        {
            Collect();
        }
    }
}
