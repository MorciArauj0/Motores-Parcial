using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Intro : MonoBehaviour
{
    [SerializeField] AudioSource dialogo;
    [SerializeField] GameManager gameManager;
    [SerializeField] private string[] dialogos;
    [SerializeField] private Dictionary<string, int> subtitulos;
    [SerializeField] private TMP_Text zonaSubtitulos;
    void Start()
    {
        zonaSubtitulos.text = dialogos[0];
    }
}
