using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Animator Door;
    public BoxCollider2D Knopf;

    private bool buttonPressed = false;
    public GameObject Ship;
    internal object onClick;

    private void Start()
    {
        Knopf.enabled = false;
    }
    private void Update()
    {
        if (Ship.transform.position.x >= 50)
            Knopf.enabled = true;

        if (buttonPressed == false && Ship.transform.position.x >= 53f)
        {
            Door.SetTrigger("openDoor");
            buttonPressed = true;

        }
            
    }
}
