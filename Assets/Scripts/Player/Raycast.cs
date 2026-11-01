using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem;

public class Raycast : MonoBehaviour
{
    [Header("Variables")]
    public LayerMask layermask;
    float radius = 2.5f;
    public Inventory inventory;


    public void OnInteract(InputValue value)
    {
        if (Physics.SphereCast(transform.position, radius, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 10f, layermask))
        {
            GameObject target = hitinfo.collider.gameObject;

            IInteractable interactable = target.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
                Debug.Log("Interactuandooo"); //esto tambien se puede borrar despues pero sirve de guia jeje
                return;
            }

            ICollectable collectable = target.GetComponent<ICollectable>();
            if (collectable != null)
            {
                inventory.AddItem(collectable.ID);
                collectable.Collect();
                return;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + transform.forward * 10f, radius);
    }
}
 