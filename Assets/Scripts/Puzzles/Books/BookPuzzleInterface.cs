using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class BookPuzzleInterface : MonoBehaviour, IInteractable
{
    [Header("Referencias")]
    public BookPuzzleLogic state;
    [SerializeField] private GameObject puzzleCamera;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject raycast;

    [Header("Selectores")]
    [SerializeField] private GameObject selectedZone;
    [SerializeField] private GameObject selectedSlot;

    [Header("Posiciones")]
    [SerializeField] private Transform[] zonePosition;
    [SerializeField] private Transform[] inventoryPosition;


    [Header("Privados")]

    //no se eligio posicion
    private int selectedZoneIndex;
    private int selectedSlotIndex;
    private Transform zoneToSet;
    private Transform slotZone;

    //libro o slot?
    private enum SelectionState
    {
        SelectingSlot, SelectingZone
    }
    private SelectionState currentState = SelectionState.SelectingZone;
    //libro o slot?

    void Update()
    {
        if(!puzzleCamera.activeSelf)
        {
            return;
        }

         if (currentState == SelectionState.SelectingZone)
         {
            SelectingZone();
         }
         else if (currentState == SelectionState.SelectingSlot)
         {
            SelectingSlot();
         }

    }

    void SelectingZone()
    {
        selectedZone.SetActive(true);
        
        for (int i = 0; i < zonePosition.Length; i++)
        {
            Key key = (Key)((int)Key.Digit1 + i);
            if(Keyboard.current[key].wasPressedThisFrame)
            {
                selectedZoneIndex = i;

                selectedZone.transform.position = zonePosition[i].position;
                Debug.Log("posicion de zona " + i);
            }
        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if(selectedZoneIndex == -1)
            {
                return;
            }

            if(!state.TrySelectZone(selectedZoneIndex))
            {
                return;
            }

            currentState = SelectionState.SelectingSlot;
            selectedZone.SetActive(false);
            Debug.Log("selecciona del inventario");
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            PuzzleModeOff();
        }
    }

    void SelectingSlot()
    {
        selectedSlot.SetActive(true);

        for (int i = 0; i < inventoryPosition.Length; i++)
        {
            Key key = (Key)((int)Key.Digit1 + i);
            if (Keyboard.current[key].wasPressedThisFrame)
            {
                selectedSlotIndex = i;

                selectedSlot.transform.position = inventoryPosition[i].position;
                Debug.Log("posicion de slot " + i);
            }
        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if(selectedSlotIndex == -1)
            {
                return;
            }

            bool placed = state.SetInventoryBook(selectedSlotIndex);

            if(placed == true)
            {
                currentState = SelectionState.SelectingZone;
                selectedSlot.SetActive(false);
                Debug.Log("seleccionado");

            }


            
        }

        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            selectedSlot.SetActive(false);

            state.CancelSelection();

            currentState = SelectionState.SelectingZone;
        }
    }


    public void Interact()
    {
        PuzzleMode();
    }

    void PuzzleMode()
    {
        puzzleCamera.SetActive(true);
        player.SetActive(false);
        raycast.SetActive(false);

        currentState = SelectionState.SelectingZone;

        selectedZone.SetActive(false);
        selectedSlot.SetActive(false);

    }

    public void PuzzleModeOff()
    {
        puzzleCamera.SetActive(false);
        player.SetActive(true);
        raycast.SetActive(true);

        selectedZone.SetActive(false);
        selectedSlot.SetActive(false);

        state.CancelSelection();

    }
}
