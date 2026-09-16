using UnityEngine;

public class ControlLuces : MonoBehaviour
{
    [Header("Luces")]
    [SerializeField] private Renderer[] luces;

    [Header("Colores")]
    [SerializeField] private Color prendida = Color.yellow;
    [SerializeField] private Color apagada = Color.black;

    void Start()
    {
        PrenderLuces();
    }

    void PrenderLuces()
    {
        int loopsRestantes = GameManager.Instance.loopsRestantes;

        for (int i = 0; i < luces.Length; i++)
        {
            bool prender = i < loopsRestantes;
            if (prender)
            {
                luces[i].material.color = prendida;
            }
            else
            {
                luces[i].material.color = apagada;
            }
        }
    }
}
