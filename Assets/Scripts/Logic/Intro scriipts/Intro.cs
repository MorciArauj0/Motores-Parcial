using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Intro : MonoBehaviour
{
    [SerializeField] AudioSource dialogo;
    [SerializeField] GameManager timeLoop;
    [SerializeField] GameObject gameManager;
    [SerializeField] private string[] dialogos;
    //[SerializeField] private Dictionary<string, int> subtitulos;
    [SerializeField] private TMP_Text zonaSubtitulos;
    [SerializeField] private GameObject subtitulos;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject camaraIntro;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerIntro;
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject reloj;

    [SerializeField] private float timer;
    bool resetTimer = false;

    void Start()
    {   
        
    }

    void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame) 
        {
            endIntro();
        }

        //timer += Time.deltaTime;
        if(dialogo.isPlaying == false)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = dialogo.time;
        }

        subtitulos.SetActive(true);
        zonaSubtitulos.text = dialogos[0];

        animIntro();
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
            dialogo.Stop();
        }
    }

    void animIntro()
    {
        if (dialogo.isPlaying == false)
        {
            if(resetTimer == true)
            {
                zonaSubtitulos.text = dialogos[14];
                panel.SetActive(false);
                playerIntro.SetActive(true);
                timer = 0;
                resetTimer = true;
            }

            if (timer >= 3f)
            {
                zonaSubtitulos.text = dialogos[15];
                playerIntro.SetActive(false);
                player.SetActive(true);
                camaraIntro.SetActive(false);
            }
            if (timer >= 3.5f)
            {
                timeLoop.timer = 0;
                endIntro();
            }
        }
    }

    public void endIntro()
    {
        panel.SetActive(false);
        camaraIntro.SetActive(false);

        player.SetActive(true);
        inventory.SetActive(true);
        reloj.SetActive(true);
        gameManager.SetActive(true);
    }
}
