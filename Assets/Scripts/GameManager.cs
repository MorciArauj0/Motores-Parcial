using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Configuración del Loop")]
    [SerializeField] public float loopDuracion = 300f;
    [SerializeField] public int loopsRestantes = 5;
    private float timer = 0f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= loopDuracion)
        {
            Debug.Log("Reset por timer");
            ReiniciarLoop();
        }

        // para testear
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            Debug.Log("Reset manual");
            ReiniciarLoop();
        }
        //
    }

    public void ReiniciarLoop()
    {
        loopsRestantes--;
        timer = 0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        if (loopsRestantes <= 0)
        {
            Debug.Log("se terminaron los loops");
            SceneManager.LoadScene("GameOver");
        }
        else { 
            Debug.Log("quedan " +  loopsRestantes + " loops restantes");
        }
    }
}