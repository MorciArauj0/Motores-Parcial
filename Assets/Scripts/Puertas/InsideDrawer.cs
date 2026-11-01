using UnityEngine;

public class InsideDrawer : MonoBehaviour
{
    [SerializeField] private Drawer drawer;

    void Start()
    {
        //drawer.GetComponent<Drawer>();
    }

    void Update()
    {
        if (drawer.Opened == false) 
        {
            Debug.Log("Agarra la linterna");
        }
    }

} 
