using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Variables")]
    Character character;
    [SerializeField] private List<ItemID> InventoryList = new List<ItemID>();
    public int objetosEnInventario => InventoryList.Count;

    [SerializeField] private InventoryUI inventoryUI;

    void Start()
    {
        character = GetComponent<Character>();
    }

    public void AddItem(ItemID id)
    {
        if(!InventoryList.Contains(id))
        {
            InventoryList.Add(id);
            Debug.Log("al inventario" + id);
            ActualizarUI();
        }
        Debug.Log("ya lo tenes");
    }

    public bool HasItem(ItemID id)
    {
        return InventoryList.Contains(id);
    }

    public void RemoveItem(ItemID id)
    {
        InventoryList.Remove(id);
        ActualizarUI();
    }
    void ActualizarUI()
{
    if (inventoryUI != null)
    {
        inventoryUI.ActualizarInventario(InventoryList);
    }
}
}
