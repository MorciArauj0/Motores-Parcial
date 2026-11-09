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

    private bool correctDoorOpen;
    private bool allDoorsClose = true;

    private bool collectComplete = false;
    private bool allObjectsSetted = false;


    private bool llaveColectada = false;
    private bool puzzleComplete = false;

    Vector3 abierto = new Vector3(0, 90, 0);

    void Update()
    {
        
        Vector3 rotacionPuertaCorrecta = correctDoor.transform.eulerAngles;

        //recolección de objetos
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
        if(othersDoors[0].transform.eulerAngles != abierto && othersDoors[1].transform.eulerAngles != abierto && othersDoors[2].transform.eulerAngles != abierto)
        {
            allDoorsClose = true;
        }
        else
        {
            allDoorsClose = false;
        }

        
        
        //for (int i = 0; i <3; i++)
        //{
        //    Vector3 rotacionActual = othersDoors[i].transform.eulerAngles;

        //    if (Keyboard.current.zKey.wasPressedThisFrame) { Debug.Log("Puerta " + i + " " + rotacionActual); }

        //    if (rotacionActual != new Vector3(0, 90, 0))
        //    {
        //        allDoorsClose = true;
        //    }
        //    else 
        //    {
        //        allDoorsClose = false;
        //        break;
        //    }
        //}

        
        if (allDoorsClose == true)
        {
            if (Keyboard.current.xKey.wasPressedThisFrame) { 
                Debug.Log("todo cerrado");
                Debug.Log("Puerta 0 " + othersDoors[0].transform.eulerAngles);
                Debug.Log("Puerta 1 " + othersDoors[1].transform.eulerAngles);
                Debug.Log("Puerta 2 " + othersDoors[2].transform.eulerAngles);
            }
        }
        else
        {
            if (Keyboard.current.xKey.wasPressedThisFrame) { 
                Debug.Log("alguna abierta");
                Debug.Log("Puerta 0 " + othersDoors[0].transform.eulerAngles);
                Debug.Log("Puerta 1 " + othersDoors[1].transform.eulerAngles);
                Debug.Log("Puerta 2 " + othersDoors[2].transform.eulerAngles);
            }
        }


        //puerta correcta
        if (rotacionPuertaCorrecta == new Vector3(0, 90, 0))
        {
            correctDoorOpen = true;
            if (Keyboard.current.hKey.wasPressedThisFrame) { Debug.Log("puerta correcta abierta"); }
        }
        else
        {
            correctDoorOpen = false;
            if (Keyboard.current.hKey.wasPressedThisFrame) { Debug.Log("puerta correcta cerrada"); }
        }

        //condiciones puzzle
        if (collectComplete == true && allDoorsClose == true && correctDoorOpen == true && allObjectsSetted == true)
        {
            puzzleComplete = true;
            Debug.Log("listo baño");
        }


        if(puzzleComplete == true && llaveColectada == false)
        {
            llaveColectada = true;
            reward.SetActive (true);
            Debug.Log("llave");
        }
    }

    void CheckCorrectDoor()
    {
        Vector3 rotacionPuertaCorrecta = correctDoor.transform.eulerAngles;
        if (rotacionPuertaCorrecta == new Vector3(0, 90, 0))
        {
            correctDoorOpen = true;
            if (Keyboard.current.hKey.wasPressedThisFrame) { Debug.Log("puerta correcta abierta"); }
        }
        else
        {
            correctDoorOpen = false;
            if (Keyboard.current.hKey.wasPressedThisFrame) { Debug.Log("puerta correcta cerrada"); }
        }
    }
}
