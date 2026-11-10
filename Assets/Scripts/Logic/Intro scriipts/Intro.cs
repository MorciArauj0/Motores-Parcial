using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Intro : MonoBehaviour
{
    [SerializeField] AudioSource dialogo;
    [SerializeField] GameManager gameManager;
    [SerializeField] private string[] dialogos;
    //[SerializeField] private Dictionary<string, int> subtitulos;
    [SerializeField] private TMP_Text zonaSubtitulos;
    [SerializeField] private GameObject subtitulos;

    private float timer;

    void Start()
    {
        zonaSubtitulos.text = dialogos[0];
    }

    void Update()
    {
        timer += Time.deltaTime;
        ChangeSubtitles();
    }

    public void ChangeSubtitles()
    {
        if (timer >= 4.08f)
        {
            zonaSubtitulos.text = dialogos[1];
        }
        if (timer >= 7.13f)
        {
            zonaSubtitulos.text = dialogos[2];
        }
        if (timer >= 10.14f)
        {
            zonaSubtitulos.text = dialogos[3];
        }
        if (timer >= 15.02f)
        {
            zonaSubtitulos.text = dialogos[4];
        }
        if (timer >= 18.81f)
        {
            zonaSubtitulos.text = dialogos[5];
        }
        if (timer >= 23.16f)
        {
            zonaSubtitulos.text = dialogos[6];
        }
        if (timer >= 28.70f)
        {
            zonaSubtitulos.text = dialogos[7];
        }
        if (timer >= 34.04f)
        {
            zonaSubtitulos.text = dialogos[8];
        }
        if (timer >= 37.42f)
        {
            zonaSubtitulos.text = dialogos[9];
        }
        if (timer >= 40.64f)
        {
            zonaSubtitulos.text = dialogos[10];
        }
        if (timer >= 44.15f)
        {
            zonaSubtitulos.text = dialogos[11];
        }
        if (timer >= 48.67f)
        {
            zonaSubtitulos.text = dialogos[12];
        }
        if (timer >= 52.51f)
        {
            zonaSubtitulos.text = dialogos[13];
        }
        if (timer >= 55.84f)
        {
            subtitulos.SetActive(false);
        }
    }
}
