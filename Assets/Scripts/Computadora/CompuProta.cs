using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DesbloqueoPorItem
{
    public ItemID item;
    public string idHabitacion;
}

public class CompuProta : MonoBehaviour, IInteractable
{
    public static CompuProta Instance;


    [Header("Presentación")]
    [TextArea(2, 4)]
    [SerializeField] private string[] lineasPresentacion;

    [Header("Habitaciones")]
    [SerializeField] private PistasPuzzle[] todosLosPuzzles;

    private bool sePresento = false;
    private HashSet<string> desbloqueados = new HashSet<string>();
    private Dictionary<string, int> pistasDadas = new Dictionary<string, int>();

    // lista para saber q puzzle corresponde a q boton
    private List<PistasPuzzle> disponibles = new List<PistasPuzzle>();

    void Awake()
    {
        if (Instance == null)
        {
            transform.SetParent(null, true);
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DesbloqueosIniciales();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void DesbloqueosIniciales()
    {
        foreach (var p in todosLosPuzzles)
            if (p.desbloqueadaAlInicio) desbloqueados.Add(p.idPuzzle);
    }

    public void DesbloquearHabitacion(string idPuzzle)
    {
        if (!desbloqueados.Add(idPuzzle)) return; // ya estaba desbloqueada

        PistasPuzzle puzzle = System.Array.Find(todosLosPuzzles, p => p.idPuzzle == idPuzzle);
        if (puzzle == null)
        {
            Debug.Log("no existe un puzzle con id " + idPuzzle);
            return;
        }


    }

    public void Interact()
    {
        if (!sePresento) MostrarPresentacion(0);
        else MostrarMenu();
    }

    // DIALOGO

    private void MostrarPresentacion(int i)
    {
        if (lineasPresentacion == null || i >= lineasPresentacion.Length)
        {
            sePresento = true;
            MostrarMenu();
            return;
        }

        DialogoUI.Instance.Mostrar(
     lineasPresentacion[i],
     new[] { "Continuar" },
     _ =>
     {
         MostrarPresentacion(i + 1);
     });
    }

    private void MostrarMenu()
    {
        disponibles.Clear();
        foreach (var p in todosLosPuzzles)
            if (desbloqueados.Contains(p.idPuzzle)) disponibles.Add(p);

        if (disponibles.Count == 0)
        {
            DialogoUI.Instance.Mostrar(
                "[No hay habitaciones desbloqueadas]",
                new[] { "Listo" },
                _ => DialogoUI.Instance.Cerrar());
            return;
        }

        string[] etiquetas = new string[disponibles.Count + 1];
        for (int i = 0; i < disponibles.Count; i++)
            etiquetas[i] = disponibles[i].nombreHabitacion;
        etiquetas[etiquetas.Length - 1] = "Por ahora no, gracias";

        DialogoUI.Instance.Mostrar("¿Necesitás ayuda con algo en particular?", etiquetas, ElegirHabitacion);
    }

    private void ElegirHabitacion(int i)
    {
        if (i >= disponibles.Count)
        {
            DialogoUI.Instance.Cerrar();
            return;
        }

        string pista = SiguientePista(disponibles[i]);

        DialogoUI.Instance.Mostrar(
            pista,
            new[] { "Preguntar más", "Listo" },
            j =>
            {
                if (j == 0) MostrarMenu();
                else DialogoUI.Instance.Cerrar();
            });
    }

    private string SiguientePista(PistasPuzzle puzzle)
    {
        if (puzzle.pistas == null || puzzle.pistas.Length == 0)
            return "No tengo información sobre esta sala...";

        pistasDadas.TryGetValue(puzzle.idPuzzle, out int indice);
        string pista = puzzle.pistas[Mathf.Min(indice, puzzle.pistas.Length - 1)];
        pistasDadas[puzzle.idPuzzle] = indice + 1;
        return pista;
    }

    [Header("Objeto que desbloquea habitación")]
    [SerializeField] private DesbloqueoPorItem[] desbloqueosPorItem;

    public void AlRecolectar(ItemID item)
    {
        foreach (var d in desbloqueosPorItem)
            if (d.item == item) DesbloquearHabitacion(d.idHabitacion);
    }

}