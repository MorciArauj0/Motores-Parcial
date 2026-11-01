using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BathroomInteractions : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractableItemID id;
    public InteractableItemID ID => id;

    [SerializeField] Inventory inventory;
    [SerializeField] private ItemID itemMust;
    [SerializeField] private ItemID finalItem;

    [SerializeField] private List<GameObject> bathroomCollect = new List<GameObject>();
    [SerializeField] private GameObject missingObject;
    [SerializeField] private GameObject dropObjectPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject settedObject;

    private bool resuelto = false;
    private bool allPieces = false;

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

            if (missingObject != null) missingObject.SetActive(true);

            if (dropObjectPrefab != null)
            {
                settedObject.SetActive(true);

                if (bathroomCollect == null)
                {
                    allPieces = true;
                }
            }
            
            Debug.Log("A veer si anda, item usado!!");
        }
        else
        {
            Debug.Log("Necesitas este item:" + itemMust);
        }

        if(finalItem == ItemID.vase && allPieces)
        {
            Vector3 pos = spawnPoint != null ? spawnPoint.position : transform.position;
            Quaternion rot = spawnPoint != null ? spawnPoint.rotation : Quaternion.identity;
            Instantiate(dropObjectPrefab, pos, rot);

            resuelto = true;

        }
    }

}
