using UnityEngine;

public enum ItemID
{
    paper, paintObject, vase, lintern, archiveKey, bossKey, breakKey, clockKey
}

public class CollectObjects : MonoBehaviour, ICollectable
{
    [SerializeField] private ItemID id;
    public ItemID ID => id;

    public void Collect()
    {
        gameObject.SetActive(false);
        Debug.Log("recolectadoo:" + id);
    }

}
