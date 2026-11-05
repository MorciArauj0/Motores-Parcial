using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Pantallas")]
    public GameObject gameOverScreen;
    public GameObject victoryScreen;
    public Button restartButton;
    public Button menuButton;
    private bool gameOverActivo = false;


    [Header("Configuración del Loop")]
    [SerializeField] public float loopDuracion = 300f;
    [SerializeField] public int loopsRestantes = 5;
    private float timer = 0f;
    public float TiempoActual => timer;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            enabled = false;
            Destroy(gameObject);
            return;
        }

        //congelar mouse
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {
        gameOverActivo = false;
        ReferenciasUI();
    }

    void Update()
    {
        if (gameOverActivo) return;

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

        //congelar mouse
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            bool dialogoAbierto = DialogoUI.Instance != null && DialogoUI.Instance.Abierto;
            if (!dialogoAbierto)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

    }

    public void ReiniciarLoop()
    {
        if (gameOverActivo) return;

        loopsRestantes--;
        timer = 0f;

        if (loopsRestantes <= 0)
        {
            gameOver();
            return;
        } 

        gameOverActivo = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    //=========================================
    //PANTALLAS DE GAME OVER Y VICTORIA (sufrí) (falta asignarle la condicion de vic al juego)
    //=========================================
    public void gameOver()
    {
        if (gameOverActivo) return;

        gameOverActivo = true;

        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }

    public void Victory()
    {
        if (victoryScreen != null)
        {
            victoryScreen.SetActive(true);
        }
    }

    public void ReiniciarEscena()
    {
        Time.timeScale = 1f;

        if (GameManager.Instance != null)
        {
            Destroy(GameManager.Instance.gameObject);
        }
        SceneManager.LoadScene("Office");
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f;

        if (GameManager.Instance != null)
        {
            Destroy(GameManager.Instance.gameObject);
        }
        SceneManager.LoadScene("Start");
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ReferenciasUI();
    }

    void ReferenciasUI()
    {
        gameOverScreen = GameObject.FindWithTag("gameOver");
        victoryScreen = GameObject.FindWithTag("victory");

        if (gameOverScreen != null)
        {
            Button[] botones = gameOverScreen.GetComponentsInChildren<Button>(true);
            foreach (Button b in botones)
            {
                if (b.gameObject.name == "Reiniciar")
                {
                    restartButton = b;
                    restartButton.onClick.RemoveAllListeners();
                    restartButton.onClick.AddListener(ReiniciarEscena);
                }
                else if (b.gameObject.name == "Menu")
                {
                    menuButton = b;
                    menuButton.onClick.RemoveAllListeners();
                    menuButton.onClick.AddListener(IrAlMenu);
                }
            }

            gameOverScreen.SetActive(false);
        }

        if (victoryScreen != null)
        {
            victoryScreen.SetActive(false);
        }
    }
}