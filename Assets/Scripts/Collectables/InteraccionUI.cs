using System.Collections;
using TMPro;
using UnityEngine;

public class InteraccionUI : MonoBehaviour
{
    public static InteraccionUI Instance;

    [SerializeField] private TMP_Text texto;
    [SerializeField] private float duracion = 1.5f;
    private Coroutine rutina;

    void Awake()
    {
        Instance = this;
        texto.gameObject.SetActive(false);
    }

    public void Mostrar(string mensaje)
    {
        if (rutina != null) StopCoroutine(rutina);
        rutina = StartCoroutine(InteraccionMostrar(mensaje));
    }

    private IEnumerator InteraccionMostrar(string mensaje)
    {
        texto.text = mensaje;
        texto.gameObject.SetActive(true);
        yield return new WaitForSeconds(duracion);
        texto.gameObject.SetActive(false);
    }
}