using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Animator Door;

    private bool buttonPressed = false;
    public GameObject Ship;


    private void Update()
    {
        if (buttonPressed == false && Ship.transform.position.x >= 53f)
        {
            Door.SetTrigger("openDoor");
            buttonPressed = true;
        }
            
    }
}
