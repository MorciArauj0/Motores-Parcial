using UnityEngine;

public class ControlLuces : MonoBehaviour
{
    [Header("Luces")]
    [SerializeField] private LampController [] luces;

    
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

            if (!prender)
            {
                luces[i].ApagarLuz();
            }
            
        }
    }
}
