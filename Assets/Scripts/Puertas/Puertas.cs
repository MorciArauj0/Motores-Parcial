using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Puertas : MonoBehaviour
{
    [Header("Variables")]
    public float openAngle = -90f;

    [SerializeField] private GameObject pivot;
    [SerializeField] private BoxCollider door;
    //[SerializeField] private Animator anim;

    private Quaternion openRotation;
    private Quaternion closedRotation;
    private bool isOpen = false;

    void Start()
    {

        //anim = GetComponent<Animator>();
        closedRotation = pivot.transform.localRotation;
        openRotation = closedRotation * Quaternion.Euler(0, openAngle, 0);
    }

    public void Toggle()
    {
        Animator anim = pivot.GetComponent<Animator>();
        isOpen = !isOpen;

        if(isOpen)
        {
            //anim.Play("Open");
            anim.SetTrigger("Open");
            anim.SetBool("isClosed", false);
            door.enabled = false;
        }
        else
        {
            //anim.Play("Close");
            anim.SetTrigger("Close");
            door.enabled = false;
            //anim.SetBool("isClosed", true);
        }

        //pivot.transform.localRotation = isOpen ? openRotation : closedRotation;
        // cambia de posicion ya con la animacion
    }

    public void Collider()
    {
        door.enabled = true;
    }
}
