using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;


    private void Awake()
    {
        Instance = this;
    }

    public void ActualizarVolumenGhost(AudioSource fuente, float distancia, float distanciaMax)
    {
        float porcentaje = Mathf.Clamp01(1f - (distancia / distanciaMax));
        fuente.volume = porcentaje * porcentaje;
    }

    public void ActualizarPitchGhost(AudioSource fuente, bool persiguiendo)
    {
        float pitchObjetivo = persiguiendo ? 1.2f : 1f;
        fuente.pitch = Mathf.Lerp(fuente.pitch, pitchObjetivo, Time.deltaTime * 2f);
    }
}
