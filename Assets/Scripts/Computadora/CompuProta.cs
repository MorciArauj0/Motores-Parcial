using UnityEngine;
using System.Collections.Generic;

public class CompuProta : MonoBehaviour
{
    private static CompuProta Instance;
    private Character jugador;
    private bool unMensaje = false; // para que el debug me devuelva un dialogo a la vez xd

    //// para testear si cuando se reinicia el loop se mantiene la computadora sin reiniciar
    private Queue<string> mensajes = new Queue<string>();

    private void CargarMensajes()
    {
        mensajes.Enqueue("dialogo 1 de 5");
        mensajes.Enqueue("dialogo 2 de 5");
        mensajes.Enqueue("dialogo 3 de 5");
        mensajes.Enqueue("dialogo 4 de 5");
        mensajes.Enqueue("dialogo 5 de 5");
    }

    private void MostrarSiguienteMensaje()
    {
        if (mensajes.Count > 0)
        {
            string mensaje = mensajes.Dequeue();
            Debug.Log(mensaje);
        }
        else
        {
            Debug.Log("se terminaron los dialogos");
        }
    }

    ////

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            CargarMensajes(); // para testear
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (character != null) jugador = character;
        unMensaje = false;
    }

    private void OnTriggerExit(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (character != null) jugador = null;
    }

    private void Update()
    {
        if (jugador != null && jugador.publicInteracting && !unMensaje)
        {
            MostrarSiguienteMensaje(); // para testear
            unMensaje = true;
        }
    }

}