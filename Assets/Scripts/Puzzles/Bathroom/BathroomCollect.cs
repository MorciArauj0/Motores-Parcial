using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BathroomCollect : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractableItemID id;
    public InteractableItemID ID => id;

    [SerializeField] Inventory inventory;
    [SerializeField] private ItemID itemMust;

    [SerializeField] private GameObject settedObject;

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
            settedObject.SetActive(true);

            Debug.Log("A veer si anda, item usado!!");
        }       
        else
        {
            Debug.Log("Necesitas este item:" + itemMust);
        }
    }

}
