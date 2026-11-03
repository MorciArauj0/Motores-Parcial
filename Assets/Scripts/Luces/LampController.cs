using UnityEngine;

public class LampController : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private Light lampLight;
    [SerializeField] private ParticleSystem lampParticles;
    [SerializeField] private GameObject Plane;

    public void ApagarLuz()
    {
        lampLight.color = Color.black; // Pone la luz negra

        var main = lampParticles.main; // Pone partículas negras
        main.startColor = Color.black;

        lampParticles.Clear();// Elimina particulas existentes

        
        Plane.SetActive(false);// Saca el coso amarillo de la punta de la lámpara
    }
}