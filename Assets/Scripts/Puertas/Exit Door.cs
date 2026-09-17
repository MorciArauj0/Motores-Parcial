using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] private GameObject finalSign;
    [SerializeField] private string scene;

    Character character;

    public void UnlockDoor()
    {
        SceneManager.LoadScene(scene);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Character character = collision.gameObject.GetComponent<Character>();
        if(character != null && finalSign == true)
        {
            UnlockDoor();
        }
    }
}
