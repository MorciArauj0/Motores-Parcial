using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.ProBuilder.Shapes;

public class Puertas : MonoBehaviour
{
    [Header("Variables")]
    public float openAngle = -90f;

    [Header("Sonido")]
    [SerializeField] private AudioClip sonidoPuerta;
    [SerializeField] private AudioMixerGroup grupoSFX;
    private AudioSource audioPuerta;

    [SerializeField] private GameObject pivot;
    [SerializeField] private BoxCollider door;
    private Quaternion openRotation;
    private Quaternion closedRotation;
    private bool isOpen = false;

    void Awake()
    {
        audioPuerta = gameObject.AddComponent<AudioSource>();

        audioPuerta.playOnAwake = false;
        audioPuerta.loop = false;
        audioPuerta.spatialBlend = 1f;
        audioPuerta.clip = sonidoPuerta;
        audioPuerta.outputAudioMixerGroup = grupoSFX;
    }

    void Start()
    { 
        closedRotation = pivot.transform.localRotation;
    }

    public void Toggle()
    {
        Animator anim = pivot.GetComponent<Animator>();
        isOpen = !isOpen;

        if (isOpen)
        {
            //anim.Play("Open");
            anim.SetTrigger("opening");
            anim.SetBool("isClosed", false);
            door.enabled = false;

            if (sonidoPuerta != null)
            {
                audioPuerta.Play();
            }

        }
        else
        {
            //anim.Play("Close");
            anim.SetTrigger("closing");
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
