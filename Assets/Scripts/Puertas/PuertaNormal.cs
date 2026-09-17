using UnityEngine;

public class PuertaNormal : MonoBehaviour, IInteractable
{
    [SerializeField] private Puertas puerta;

    public void Interact()
    {
        puerta.Toggle();
    }
}
