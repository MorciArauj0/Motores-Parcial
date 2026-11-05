using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BooksPuzzleManager : MonoBehaviour
{

    [Header("Resuelto")]
    [SerializeField] private GameObject reward;
    [SerializeField] private GameObject puzzleCamera;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject raycast;
    [SerializeField] private GameObject chest;
    public bookZone[] slots;

    [SerializeField] private int[] answer = {0, 1, 2, 3, 4};
    private bool puzzleSolved = false;



    public void CheckAnswer()
    {
        if(puzzleSolved)
        {
            return;
        }

        //si no esta todo ocuado sigue el puzzle
        foreach(bookZone slot in slots)
        {
            if(!slot.Occupied())
            {
                return;
            }
        }

        for(int i = 0; i  < slots.Length; i++)
        {
            if (slots[i].bookToSet.bookID != answer[i])
            {
                Debug.Log("esta mal");
                return;
            }
            else if (slots[i].bookToSet.bookID == answer[i])
            {
                puzzleSolved = false;
                Debug.Log("EUREKA");
                Solved();
                return;
            }
        }
        
    }

    void Solved()
    {
        reward.SetActive(true);
        Animator animChest = chest.GetComponent<Animator>();
        animChest.SetTrigger("PuzzleSolved");
        puzzleCamera.SetActive(false);
        player.SetActive(true);
        raycast.SetActive(true);

        BoxCollider myCollider = gameObject.GetComponent<BoxCollider>();
        myCollider.enabled = false;
    }

}

