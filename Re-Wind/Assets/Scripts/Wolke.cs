using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolke : MonoBehaviour
{
    private Animator cloudAnim;
    private void Start()
    {
        cloudAnim = GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            cloudAnim.SetTrigger("Hit");
    }
}
