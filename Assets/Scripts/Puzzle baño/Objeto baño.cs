using Unity.VisualScripting;
using UnityEngine;

public class Puzzlebaño : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject missingObject;
    public void Interact()
    {
        missingObject.SetActive(true);
    }


}
