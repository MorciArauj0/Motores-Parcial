using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Intro : MonoBehaviour
{
    [Header("Activar")]
    [SerializeField] GameObject gameManager;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerIntro; // y después desactivar
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject reloj;

    [Header("Desactivar")]
    [SerializeField] private GameObject subtitulos;
    [SerializeField] private GameObject omitirIntro;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject camaraIntro;

    [Header("Componentes")]
    [SerializeField] AudioSource dialogo;
    [SerializeField] GameManager timeLoop;

    [Header("Variables")]
    [SerializeField] private string[] dialogos;
    [SerializeField] private TMP_Text zonaSubtitulos;
    [SerializeField] private float timer;
    bool resetTimer = false;
    bool resetLoop = false;
    bool introOmitida = false;
    bool primerLoop = true;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame) 
        {
            endIntro();
            omitirIntro.SetActive(false);
            introOmitida = true;
        }

        //timer += Time.deltaTime;
        if(primerLoop == true)
        {
            if (dialogo.isPlaying == false)
            {
                timer += Time.deltaTime;
                animIntro();
            }
            else
            {
                timer = dialogo.time;
                zonaSubtitulos.text = dialogos[0];
                ChangeSubtitles();
                subtitulos.SetActive(true);
            }
        }
        else
        {
            endIntro();
            omitirIntro.SetActive(false);
            introOmitida = true;
        }

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
            dialogo.Stop();
        }
    }

    void animIntro()
    {
        if (dialogo.isPlaying == false)
        {
            if(resetTimer == false)
            {
                if(introOmitida == false)
                {
                    zonaSubtitulos.text = dialogos[14];
                    panel.SetActive(false);
                    playerIntro.SetActive(true);
                }
                
                timer = 0;
                resetTimer = true;
            }

            if (timer >= 3.5f)
            {
                zonaSubtitulos.text = dialogos[15];
                playerIntro.SetActive(false);                
                camaraIntro.SetActive(false);

                player.SetActive(true);

                if (timer >= 4f && resetLoop == false)
                {
                    timeLoop.timer = 0;
                    omitirIntro.SetActive(false);
                    subtitulos.SetActive(false);
                    endIntro();
                    resetLoop = true;
                }
            }  
        }
    }

    public void endIntro()
    {
        //en caso de saltar la intro
        dialogo.Stop();
        subtitulos.SetActive(false);
        panel.SetActive(false);
        camaraIntro.SetActive(false);
        playerIntro.SetActive(false);
        player.SetActive(true);
        //en caso de saltar la intro

        inventory.SetActive(true);
        reloj.SetActive(true);
        gameManager.SetActive(true);

        primerLoop = false;
    }
}
