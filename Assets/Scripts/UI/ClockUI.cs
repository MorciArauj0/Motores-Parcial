using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour
{
    [SerializeField] private Image timerFill;
    [SerializeField] private Image detallesReloj;

    void Update()
    {
        if (GameManager.Instance != null)
        {
            float tiempoRestante = GameManager.Instance.loopDuracion - GameManager.Instance.TiempoActual;

            float porcentaje = Mathf.Clamp01(tiempoRestante / GameManager.Instance.loopDuracion);

            timerFill.fillAmount = porcentaje;
            detallesReloj.fillAmount = porcentaje;
        }
    }
}