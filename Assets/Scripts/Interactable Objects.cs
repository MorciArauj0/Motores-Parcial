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


    //Puzzle del baño y cuadro (Creo que esta mal)
    [SerializeField] private GameObject missingObject;
    public void Interact()
    {
        missingObject.SetActive(true);
    }


}
