using System;
using UnityEngine;

public class InsideDrawer : MonoBehaviour
{
    [SerializeField] private Drawer drawer;
    [SerializeField] private CollectObjects lantern;

    public bool collected = false;

    void Start()
    {
        //drawer.GetComponent<Drawer>();
        lantern = GetComponent<CollectObjects>();
    }

    void Update()
    {
        if (drawer.Opened == true) 
        {
            lantern.enabled = true;
            collected = true;
        }
    }

} 
