using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float relativeMove = .3f;
    public bool lockY = false;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        if(lockY)
        {
            transform.position = new Vector2(Camera.main.transform.position.x * relativeMove, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(Camera.main.transform.position.x * relativeMove, Camera.main.transform.position.y * relativeMove);
        }
    }
}
