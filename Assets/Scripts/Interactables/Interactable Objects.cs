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
    [SerializeField] private GameObject dropObject;


    //hola
    public void Interact()
    {
        if (inventory != null && inventory.HasItem(itemMust))
        {
            inventory.RemoveItem(itemMust);

            missingObject.SetActive(true);
            if (dropObject != null) dropObject.SetActive(true);

            Debug.Log("A veer si anda, item usado!!");
        }
        else
        {
            Debug.Log("Necesitas este item:" + itemMust);
        }
    }

}
