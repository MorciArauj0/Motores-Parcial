using Unity.VisualScripting;
using UnityEngine;

public enum InteractableItemID
{
    door, drawer, computer, painting, clock
}

public class InteractableObjects : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractableItemID id;
    public InteractableItemID ID => id;

    [SerializeField] Inventory inventory;
    [SerializeField] private ItemID itemMust;


    [SerializeField] private GameObject missingObject;
    [SerializeField] private GameObject dropObjectPrefab;
    [SerializeField] private Transform spawnPoint;

    private bool resuelto = false;

    public void Interact()
    {
        if (resuelto)
        {
            return;
        }

        if (inventory != null && inventory.HasItem(itemMust))
        {
            inventory.RemoveItem(itemMust);

            if (missingObject != null) missingObject.SetActive(true);

            if (dropObjectPrefab != null)
            {
                Vector3 pos = spawnPoint != null ? spawnPoint.position : transform.position;
                Quaternion rot = spawnPoint != null ? spawnPoint.rotation : Quaternion.identity;
                Instantiate(dropObjectPrefab, pos, rot);
            }

            resuelto = true;
            Debug.Log("A veer si anda, item usado!!");
        }
        else
        {
            Debug.Log("Necesitas este item:" + itemMust);
        }
    }

}
