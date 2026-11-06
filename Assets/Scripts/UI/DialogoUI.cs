using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogoUI : MonoBehaviour
{
    public static DialogoUI Instance;

    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text texto;
    [SerializeField] private Transform contenedorBotones;
    [SerializeField] private Button botonUI;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clipTecla;

    private PlayerInput playerInput;

    public bool Abierto => panel.activeSelf; // para que el gamemanager sepa que está en la pantalla de diálogo

    void Awake()
    {
        Instance = this;
        panel.SetActive(false);
    }

    public void Mostrar(string mensaje, string[] etiquetas, Action<int> alElegir)
    {
        if (!panel.activeSelf) Abrir();
        texto.text = mensaje;

        foreach (Transform hijo in contenedorBotones) Destroy(hijo.gameObject);

        for (int i = 0; i < etiquetas.Length; i++)
        {
            int indice = i;
            Button boton = Instantiate(botonUI, contenedorBotones);
            boton.GetComponentInChildren<TMP_Text>().text = etiquetas[i];
            boton.onClick.AddListener(() => 
            {
                ReproducirClick();
                alElegir(indice);
            });
        }
    }

    private void ReproducirClick()
    {
        if (audioSource != null && clipTecla != null)
        {
            audioSource.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
            audioSource.PlayOneShot(clipTecla);
        }
    }


    private void Abrir()
    {
        if (playerInput == null) playerInput = FindFirstObjectByType<PlayerInput>();
        if (playerInput != null) playerInput.DeactivateInput(); // el personaje no se mueve ni mira
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        panel.SetActive(true);
    }

    public void Cerrar()
    {
        panel.SetActive(false);
        if (playerInput != null) playerInput.ActivateInput();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}