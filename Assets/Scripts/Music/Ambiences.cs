using Unity.VisualScripting;
using UnityEngine;

public class Ambiences : MonoBehaviour
{
    [SerializeField] private GameObject officeAmbience;
    [SerializeField] private GameObject otherAmbience;

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            officeAmbience.SetActive(false);
            otherAmbience.SetActive(true);
        }   
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            officeAmbience.SetActive(true);
            otherAmbience.SetActive(false);
        }
    }
}
