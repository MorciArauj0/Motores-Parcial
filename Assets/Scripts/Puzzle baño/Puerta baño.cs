using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Puertabaño : MonoBehaviour, IInteractable
{
    public float openAngle = 90f;

    [SerializeField] private GameObject pivot;
    private Quaternion openRotation;
    private Quaternion closedRotation;


    public void Interact()
    {
        openRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, openAngle, 0));
        Debug.Log ("Se abrio");
    }
}
