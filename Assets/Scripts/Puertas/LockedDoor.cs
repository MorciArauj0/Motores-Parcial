using UnityEngine;
using UnityEngine.Audio;

public class LockedDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private Puertas puerta;

    [SerializeField] private Inventory inventory;
    [SerializeField] private ItemID itemMust;

    [Header("Sonido")]
    [SerializeField] private AudioClip sonidoPuerta;
    [SerializeField] private AudioMixerGroup grupoSFX;
    private AudioSource audioPuerta;

    private bool unlocked = false;

    void Awake()
    {
        audioPuerta = gameObject.AddComponent<AudioSource>();

        audioPuerta.playOnAwake = false;
        audioPuerta.loop = false;
        audioPuerta.spatialBlend = 1f;
        audioPuerta.clip = sonidoPuerta;
        audioPuerta.outputAudioMixerGroup = grupoSFX;
    }

    public void Interact()
    {
        if(!unlocked)
        {
            if (sonidoPuerta != null)
            {
                audioPuerta.Play();
            }
        }
        

        if (unlocked)
        {
            puerta.Toggle();
            return;
        }

        if (inventory != null && inventory.HasItem(itemMust))
        {
            inventory.RemoveItem(itemMust);
            unlocked = true;
            puerta.Toggle();
        }
    }

}
