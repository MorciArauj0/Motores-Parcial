using UnityEngine;
using UnityEngine.InputSystem;

public class Radio : MonoBehaviour, IInteractable
{
    private SpawnPoint spawnPoint;

    void Start()
    {
        spawnPoint = FindFirstObjectByType<SpawnPoint>();
    }

    
    public void Interact()
    {
        if (spawnPoint != null)
        {
            spawnPoint.DesactivarEnemigos();
        }
    }
}
