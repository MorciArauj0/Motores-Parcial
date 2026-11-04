using UnityEngine;
using UnityEngine.SceneManagement;

public class startPanel : MonoBehaviour
{
    [SerializeField] private GameObject controlPanel;
    public void startGame()
    {
        SceneManager.LoadScene("Office");
    }

    public void showControls()
    {
        controlPanel.SetActive(true);
    }
}
