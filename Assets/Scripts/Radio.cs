using UnityEngine;
using UnityEngine.InputSystem;

public class Radio : MonoBehaviour, IInteractable
{
    private SpawnPoint spawnPoint;
    private AudioSource audioSource;

    void Start()
    {
        spawnPoint = FindFirstObjectByType<SpawnPoint>();
        audioSource = GetComponent<AudioSource>();
    }

    
    public void Interact()
    {   
        if (spawnPoint != null)
        {
            spawnPoint.DesactivarEnemigos();
        }

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
