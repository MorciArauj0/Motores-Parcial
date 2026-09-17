using UnityEngine;

public class LockedDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private Puertas puerta;

    [SerializeField] private Inventory inventory;
    [SerializeField] private ItemID itemMust;

    private bool unlocked = false;

    public void Interact()
    {
        if (unlocked)
        {
            puerta.Toggle();
            return;
        }

        if (inventory != null && inventory.HasItem(itemMust))
        {
            inventory.RemoveItem(itemMust);
            unlocked = true;
            puerta.Toggle();
        }
    }

}
