using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class BathroomPuzzle : MonoBehaviour
{
    [Header("Colecta")]
    [SerializeField] private List<GameObject> bathroomCollect = new List<GameObject>();
    [SerializeField] private Inventory inventory;
    [SerializeField] private ItemID vase;
    [SerializeField] private ItemID paper;
    [SerializeField] private ItemID broom;

    [Header("Puertas")]
    [SerializeField] private GameObject correctDoor;
    [SerializeField] private List<GameObject> othersDoors;

    [Header("Puzzle")]
    [SerializeField] private GameObject reward;

    private bool correctDoorOpen = false;
    private bool allDoorsClose = true;

    private bool collectComplete = false;
    private bool allObjectsSetted = false;


    private bool puzzleComplete = false;

    
    void Update()
    {
        //recolección de objetos
        Vector3 rotacionPuertaCorrecta = correctDoor.transform.eulerAngles;

        for (int i = 0; i <= 2; i++)
        {
            if (bathroomCollect[i].activeSelf == true)
            { 
                collectComplete = false;
                break;
            }
            else
            {
                collectComplete = true;
                if (Keyboard.current.gKey.wasPressedThisFrame) { Debug.Log("listo colecta"); }
            }
        }
        


        //colocar objetos
        if(inventory.HasItem(vase) || inventory.HasItem(broom) || inventory.HasItem(paper))
        {
            allObjectsSetted = false;
        }
        else
        {
            allObjectsSetted = true;
            if (Keyboard.current.qKey.wasPressedThisFrame) { Debug.Log("pusiste todo, tal vez"); }
        }

        //puertas
        for(int i = 0; i <= 2; i++)
        {
            int doorsClosed = 0;
            Vector3 rotacion = bathroomCollect[i].transform.eulerAngles;
            Vector3 cerrado = new Vector3 (0, 0, 0);
            if(rotacion != cerrado)
            {
                doorsClosed++;
                if (doorsClosed == 3)
                {
                    allDoorsClose = true;
                    if (Keyboard.current.xKey.wasPressedThisFrame) { Debug.Log("todo cerrado"); }
                    break;
                }
                if (Keyboard.current.xKey.wasPressedThisFrame) { Debug.Log("todo cerrado"); }
            }
            else
            {
                doorsClosed = 0;
                allDoorsClose = false;
                if (Keyboard.current.xKey.wasPressedThisFrame) { Debug.Log("alguna abierta"); }
                break;
            }

            
        }

        if(rotacionPuertaCorrecta != new Vector3 (0, 90, 0))
        {
            correctDoorOpen = false;
        }
        else
        {
            correctDoorOpen = true;
            if (Keyboard.current.hKey.wasPressedThisFrame) { Debug.Log("puerta correcta abierta"); }
        }

        //condiciones puzzle

        if (collectComplete == true && allDoorsClose == true && correctDoorOpen == true && allObjectsSetted == true)
        {
            puzzleComplete = true;
            Debug.Log("listo baño");
        }


        if(puzzleComplete == true)
        {
            reward.SetActive (true);
            Debug.Log("llave");
        }
    }
}
