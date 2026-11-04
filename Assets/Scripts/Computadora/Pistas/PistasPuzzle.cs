using UnityEngine;

[CreateAssetMenu(fileName = "PistasPuzzle", menuName = "Loop/Pistas de puzzle")]
public class PistasPuzzle : ScriptableObject
{
    public string idPuzzle;
    public string nombreHabitacion; // lo q dice el boton
    public bool desbloqueadaAlInicio;

    [TextArea(2, 4)]
    public string[] pistas;
}