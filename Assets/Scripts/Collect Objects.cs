using UnityEngine;

public enum ItemID
{
    paper, paintObject, vase, lintern, archiveKey, bossKey, breakKey
}

public class CollectObjects : MonoBehaviour, ICollectable
{
    [SerializeField] private ItemID id;
    public ItemID ID => id;

    public void Collect()
    {
        
    }
}
