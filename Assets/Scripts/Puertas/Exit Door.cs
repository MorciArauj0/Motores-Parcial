using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private GameManager gameManager;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    public void Interact()
    {
        gameManager.gameOver();
        gameManager.VictoryText();
        Debug.Log("salsite");
    }

}
