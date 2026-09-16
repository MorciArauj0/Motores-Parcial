using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;



public class Inventory : MonoBehaviour
{

    Character character;
    public event Action<Inventory> OnInventoryChange;

    [SerializeField] private List<ItemID> InventoryList = new List<ItemID>();

    public void OnTriggerStay(Collider other)
    {
        CollectObjects item = other.gameObject.GetComponent<CollectObjects>();
        if(item != null && character.publicInteracting == true)
        {
            Debug.Log("al iventario");
            InventoryList.Add(item.ID);
            //Destroy(other.gameObject);
            //OnInventoryChange.Invoke(???);
            //Una variable que indique el estado de la lista
        }
    }

    void Start()
    {
        character = GetComponent<Character>();
    }
}
