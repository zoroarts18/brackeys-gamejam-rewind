using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schild : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnMouseEnter2D()
    {
        anim.SetTrigger("Groß");
    }

    private void OnMouseExit2D()
    {
        anim.SetTrigger("Klein");
    }
    void Update()
    {
      
    }
}
