using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Puertas : MonoBehaviour, IInteractable
{
    [Header("Variables")]
    public float openAngle = 90f;

    [SerializeField] private GameObject pivot;
    private Quaternion openRotation;
    private Quaternion closedRotation;
    private bool isOpen = false;

    void Start()
    {
        closedRotation = pivot.transform.localRotation;
        openRotation = closedRotation * Quaternion.Euler(0, openAngle, 0);
    }

    public void Interact()
    {
        isOpen = !isOpen;

        pivot.transform.localRotation = isOpen ? openRotation : closedRotation;
    }
}
