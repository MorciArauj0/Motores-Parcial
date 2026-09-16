using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem;

public class Raycast : MonoBehaviour
{
    public LayerMask layermask;

    void Update()
    {
        //todo lo que esta aca en update es visual, despues lo podemos borrar pero me parece mas util mantenerlo por ahora asi vemos las lineas
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 10f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10f, Color.green);
        }
    }

    public void OnGet(InputValue value)
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 10f))
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
                collectable.Collect();
                return;
            }
        }
    }
}
 