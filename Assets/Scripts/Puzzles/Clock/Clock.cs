using UnityEngine;

public class Clock : MonoBehaviour, IInteractable
{
    [Header("Apertura Puerta")]
    [SerializeField] private GameObject puerta;
    [SerializeField] private GameObject pivotPuerta;
    [SerializeField] private Transform puertass;
    [SerializeField] private GameObject exterior;
    [SerializeField] private AudioClip SFXAbrirPuerta;
    [SerializeField] private AudioSource abrirPuerta;
    public void Interact()
    {
        exterior.SetActive(true);
    }

    void Update()
    {
        
        if (exterior.activeSelf)
        {
            pivotPuerta.transform.eulerAngles = new Vector3(0f, -90f, 0f);
        }
    }
    public void PuertaTeOdio()
    {
        Destroy(puerta);
    }

}
