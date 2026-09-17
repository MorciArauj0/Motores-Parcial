using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] private GameObject finalSign;
    [SerializeField] private string scene;

    Character character;

    public void UnlockDoor()
    {
        SceneManager.LoadScene("Victory");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter con: " + other.gameObject.name);

        Character character = other.gameObject.GetComponentInParent<Character>();
        if(character != null && finalSign.activeSelf)
        {
            UnlockDoor();
        }
    }
}
