using Unity.VisualScripting;
using UnityEngine;

public enum InteractableItemID
{
    door, drawer, computer
}
public class InteractableObjects : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemID id;
    public ItemID ID => id;

    //Puzzle del baño y cuadro (Creo que esta mal)
    [SerializeField] private GameObject missingObject;
    public void Interact()
    {
        missingObject.SetActive(true);
    }


}
