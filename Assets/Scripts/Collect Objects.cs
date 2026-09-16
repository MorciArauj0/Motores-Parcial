using UnityEngine;

public enum ItemID
{
    paper, paintObject, vase, lintern, archiveKey, bossKey, breakKey, clockKey
}

public class CollectObjects : MonoBehaviour, ICollectable
{
    [SerializeField] private Character character;
    [SerializeField] private ItemID id;
    public ItemID ID => id;

    public void Collect()
    {
        Destroy(gameObject);
        Debug.Log("coleva0");
    }

    void Start()
    {
        character = GetComponent<Character>();
    }

   void OnTriggerStay(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if(character != null && character.IsInteracting == true)
        {
                Collect();
        }
    }

}
