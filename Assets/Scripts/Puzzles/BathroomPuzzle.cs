using System.Collections.Generic;
using UnityEngine;
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
        Vector3 rotacionPuerta = correctDoor.transform.eulerAngles;
        if (bathroomCollect == null)
        {
            collectComplete = true;
        }

        //colocar objetos
        if(inventory.HasItem(vase) || inventory.HasItem(broom) || inventory.HasItem(paper))
        {
            allObjectsSetted = false;
        }
        else
        {
            allObjectsSetted = true;
        }

        //puertas
        for(int i = 0; i <= 2; i++)
        {
            int doorsClosed = 0;
            Vector3 rotacion = bathroomCollect[i].transform.eulerAngles;
            if(rotacion != new Vector3 (0, 0, 0))
            {
                doorsClosed++;
                break;
            }
            else
            {
                doorsClosed = 0;
                allDoorsClose = false;
                break;
            }

            if(doorsClosed == 3)
            {
                allDoorsClose = true;
            }
        }

        if(rotacionPuerta != new Vector3 (0, 90, 0))
        {
            correctDoorOpen = false;
        }
        else
        {
            correctDoorOpen = true;
        }

        //condiciones puzzle

        if (collectComplete == true && allDoorsClose == true && correctDoorOpen == true && allObjectsSetted == true)
        {
            puzzleComplete = true;
        }


        if(puzzleComplete == true)
        {
            reward.SetActive (true);
        }
    }
}
