using System;
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
    [SerializeField]private AudioSource sfxGeneral;
    [SerializeField] private AudioClip sfxLlave;

    private void Start()
    {

    }

    public void Collect()
    {
        reproducirSfx();

        gameObject.SetActive(false);
        Debug.Log("recolectadoo:" + id);

        if (CompuProta.Instance != null) CompuProta.Instance.AlRecolectar(id); 
        InteraccionUI.Instance.Mostrar("agarraste " + ItemNames.Obtener(id));
    }

    private void reproducirSfx()
    {
        AudioClip clip = sfxGeneral.clip;

        if (id == ItemID.bossKey || id == ItemID.breakKey || id == ItemID.clockKey || id == ItemID.conferenceKey || id == ItemID.archiveKey)
        {
            clip = sfxLlave;
        }

        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
        }
    }

}
