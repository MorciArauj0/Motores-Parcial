using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject Victory;


    public void Interact()
    {
        Time.timeScale = 0f;
        Victory.SetActive(true);
        Debug.Log("salsite");
    }
    
    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("OnTriggerEnter con: " + other.gameObject.name);

    //    Character character = other.gameObject.GetComponentInParent<Character>();
    //    if(character != null && finalSign.activeSelf)
    //    {
    //        UnlockDoor();
    //    }
    //}
}
