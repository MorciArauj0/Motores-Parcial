using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startPanel : MonoBehaviour
{
    [SerializeField] private GameObject controlPanel;
    [SerializeField] private GameObject LoadingScreen;
    [SerializeField] Slider LoadingScreenSlider;

    private void Awake()
    {
        controlPanel.SetActive(false);
        LoadingScreen.SetActive(false);
    }

    public void startGame()
    {
         controlPanel.SetActive(false);

        TryLoadScene("Office");
    }

    public void TryLoadScene(string sceneName)
    {
        if (sceneLoadingCoroutine == null)
        {
            sceneLoadingCoroutine = StartCoroutine(Loadscene(sceneName));
        }
    }

    Coroutine sceneLoadingCoroutine;

    public void showControls()
    {
        controlPanel.SetActive(true);
    }

    IEnumerator Loadscene(string sceneName)
    {
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(sceneName);

        LoadingScreen.SetActive(true);

        while (!loadingOperation.isDone)
        {  
            Debug.Log(loadingOperation.progress);
            LoadingScreenSlider.value = loadingOperation.progress / 0.9f;
            yield return null;
        }

        LoadingScreenSlider.value = 1f;

        LoadingScreen.SetActive(false);

        sceneLoadingCoroutine = null;
    }
}
