using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("Iconos de los seis espacios")]
    [SerializeField] private Image[] slots;

    [Header("Imagenes de los objetos")]
    [SerializeField] private Sprite[] itemSprites;

    [Header("IDs de los objetos")]
    [SerializeField] private ItemID[] itemIDs;

    void Start()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].enabled = false;
        }
    }

    public void ActualizarInventario(System.Collections.Generic.List<ItemID> items)
    {
        for (int i = 0; i < slots.Length; i++) // para que queden vacios los slots
        {
            slots[i].sprite = null;
            slots[i].enabled = false;
        }


        for (int i = 0; i < items.Count && i < slots.Length; i++) // para poner los objetos que tiene el jugador
        {
            for (int j = 0; j < itemIDs.Length; j++)
            {
                if (items[i] == itemIDs[j])
                {
                    if (itemSprites[j] != null)
                    {
                        slots[i].sprite = itemSprites[j];
                        slots[i].enabled = true;
                    }

                    break;
                }
            }
        }
    }
}