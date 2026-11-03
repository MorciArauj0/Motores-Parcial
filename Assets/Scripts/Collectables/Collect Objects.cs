using UnityEngine;

public enum ItemID
{
    paper, paintObject, vase, broom, lintern, archiveKey, bossKey, breakKey, clockKey, conferenceKey, 
    archiversBook, meetingsBook, bathroomBook, breakroomBook, computersBook
}

public class CollectObjects : MonoBehaviour, ICollectable
{
    [SerializeField] private ItemID id;
    public ItemID ID => id;

    public void Collect()
    {
        gameObject.SetActive(false);
        Debug.Log("recolectadoo:" + id);
        InteraccionUI.Instance.Mostrar("agarraste " + id);
    }

}
