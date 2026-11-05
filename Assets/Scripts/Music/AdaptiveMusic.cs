using UnityEngine;
using UnityEngine.Audio;

public class AdaptiveMusic : MonoBehaviour
{
    public AudioMixer mixer;

    private AudioMixerSnapshot exploracion;
    private AudioMixerSnapshot tension;
    private AudioMixerSnapshot urgencia;

    private int estadoActual = 0;

    void Start()
    {
        exploracion = mixer.FindSnapshot("Exploracion");
        tension = mixer.FindSnapshot("Tension");
        urgencia = mixer.FindSnapshot("Urgencia");

        exploracion.TransitionTo(0f);
    }

    void Update()
    {
        if (GameManager.Instance == null) return;

        float restante = GameManager.Instance.loopDuracion
            - GameManager.Instance.TiempoActual;

        float porcentajeRestante = restante
            / GameManager.Instance.loopDuracion;

        if (porcentajeRestante <= 0.25f && estadoActual < 2)
        {
            urgencia.TransitionTo(2f);
            estadoActual = 2;
        }
        else if (porcentajeRestante <= 0.60f && estadoActual < 1)
        {
            tension.TransitionTo(3f);
            estadoActual = 1;
        }
    }
}