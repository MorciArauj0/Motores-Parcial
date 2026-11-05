using System.Collections;
using TMPro;
using UnityEngine;

public class InteraccionUI : MonoBehaviour
{
    public static InteraccionUI Instance;

    [SerializeField] private TMP_Text texto;
    [SerializeField] private float duracion = 1.5f;
    private Coroutine rutina;

    [SerializeField] private float duracionFade = 0.3f;

    void Awake()
    {
        Instance = this;
        texto.alpha = 0f;
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

        // fade in
        while (texto.alpha < 1f)
        {
            texto.alpha = Mathf.MoveTowards(texto.alpha, 1f, Time.deltaTime / duracionFade);
            yield return null;
        }

        yield return new WaitForSeconds(duracion);

        // fade out
        while (texto.alpha > 0f)
        {
            texto.alpha = Mathf.MoveTowards(texto.alpha, 0f, Time.deltaTime / duracionFade);
            yield return null;
        }

        texto.gameObject.SetActive(false);

    }
}