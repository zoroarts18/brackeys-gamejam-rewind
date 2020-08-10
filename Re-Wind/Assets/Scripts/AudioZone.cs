using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioZone : MonoBehaviour
{
    public AudioSource Audio;
    
    void Start()
    {
        Audio = GetComponent<AudioSource>();
        
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "Player")
        {
            Audio.Play();
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            Audio.Stop();
        }
    }

}
