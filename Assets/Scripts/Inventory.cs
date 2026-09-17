using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Variables")]
    Character character;
    [SerializeField] private List<ItemID> InventoryList = new List<ItemID>();


    void Start()
    {
        character = GetComponent<Character>();
    }

    public void AddItem(ItemID id)
    {
        InventoryList.Add(id);
        Debug.Log("al inventario" + id);
    }

    public bool HasItem(ItemID id)
    {
        return InventoryList.Contains(id);
    }

    public void RemoveItem(ItemID id)
    {
        InventoryList.Remove(id);
    }
    
}
