using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenWolke : MonoBehaviour
{
    public Animator Fire;
    private bool OnFire = false;
    
    void Update()
    {
        if(transform.position.x  >= 193.5f && OnFire == false)
        {
            OnFire = true;
            Fire.SetTrigger("Löschen");
        }

    }
}
