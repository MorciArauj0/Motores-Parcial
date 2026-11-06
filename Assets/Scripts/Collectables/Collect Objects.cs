using UnityEngine;



public enum ItemID
{
    paper, paintObject, vase, broom, lintern, archiveKey, bossKey, breakKey, clockKey, conferenceKey,
    computersBook, archiversBook, meetingsBook, bathroomBook, breakroomBook
}


public class CollectObjects : MonoBehaviour, ICollectable
{
    [SerializeField] private ItemID id;
    public ItemID ID => id;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Collect()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
        }

        gameObject.SetActive(false);
        Debug.Log("recolectadoo:" + id);
        if (CompuProta.Instance != null) CompuProta.Instance.AlRecolectar(id); 
        InteraccionUI.Instance.Mostrar("agarraste " + ItemNames.Obtener(id));
    }

}
