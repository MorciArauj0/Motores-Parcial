using UnityEngine;

public class Puertabaño : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject pivot;

    public void Interact()
    {
        transform.Rotate(new Vector3(0, -80, 0));
    }
}
