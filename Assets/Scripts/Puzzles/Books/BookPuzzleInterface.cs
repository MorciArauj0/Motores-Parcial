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
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject tutorial;

    [Header("Selectores")]
    [SerializeField] private GameObject selectedZone;
    [SerializeField] private GameObject selectedSlot;

    [Header("Posiciones")]
    [SerializeField] private Transform[] zonePosition;
    [SerializeField] private Transform[] inventoryPosition;

    [Header("Audios")]
    [SerializeField] private AudioSource archiverSound;
    [SerializeField] private AudioSource mirrorSound;
    [SerializeField] private AudioSource computerSound;
    [SerializeField] private AudioSource radioSound;
    [SerializeField] private AudioSource paintSound;


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

    //tutorial una sola vez
    bool tutorialVisto = false;

    void Update()
    {
        if(!puzzleCamera.activeSelf)
        {
            return;
        }

         if (currentState == SelectionState.SelectingZone)
         {
            SelectingZone();
            Silence();
         }
         else if (currentState == SelectionState.SelectingSlot)
         {
            SelectingSlot();
         }

        if (Keyboard.current.eKey.wasPressedThisFrame && tutorial.activeSelf == true || Mouse.current.leftButton.wasPressedThisFrame && tutorial.activeSelf == true)
        {
            tutorial.SetActive(false);
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

        if (Keyboard.current.escapeKey.wasPressedThisFrame && tutorial.activeSelf == false)
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

                ItemID slotId = inventory.GetItemID(i);
                Debug.Log("escuchando " + slotId);
                if (slotId == 0)
                {
                    Debug.Log("Fuera de rango");
                    Silence();
                }
                else if (slotId == ItemID.archiversBook)
                {
                    archiverSound.Play();
                    computerSound.Stop();
                    mirrorSound.Stop();
                    radioSound.Stop();
                    paintSound.Stop();
                }
                else if (slotId == ItemID.computersBook)
                {
                    archiverSound.Stop();
                    computerSound.Play();
                    mirrorSound.Stop();
                    radioSound.Stop();
                    paintSound.Stop();
                }
                else if (slotId == ItemID.bathroomBook)
                {
                    archiverSound.Stop();
                    computerSound.Stop();
                    mirrorSound.Play();
                    radioSound.Stop();
                    paintSound.Stop();
                }
                else if (slotId == ItemID.meetingsBook)
                {
                    archiverSound.Stop();
                    computerSound.Stop();
                    mirrorSound.Stop();
                    radioSound.Play();
                    paintSound.Stop();
                }
                else if (slotId == ItemID.breakroomBook)
                {
                    archiverSound.Stop();
                    computerSound.Stop();
                    mirrorSound.Stop();
                    radioSound.Stop();
                    paintSound.Play();
                }

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
            Silence();

            if (placed == true)
            {
                Silence();
                currentState = SelectionState.SelectingZone;
                selectedSlot.SetActive(false);
                Debug.Log("seleccionado");
            }

        }

        if(Keyboard.current.escapeKey.wasPressedThisFrame && tutorial.activeSelf == false)
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
        
        currentState = SelectionState.SelectingZone;

        selectedZone.SetActive(false);
        selectedSlot.SetActive(false);

        if(tutorialVisto == false)
        {
            tutorial.SetActive(true);
            tutorialVisto = true;
        }
    }

    public void PuzzleModeOff()
    {
        puzzleCamera.SetActive(false);
        player.SetActive(true);

        selectedZone.SetActive(false);
        selectedSlot.SetActive(false);

        state.CancelSelection();

    }

    public void Silence()
    {
        archiverSound.Stop();
        computerSound.Stop();
        mirrorSound.Stop();
        radioSound.Stop();
        paintSound.Stop();
    }
}
