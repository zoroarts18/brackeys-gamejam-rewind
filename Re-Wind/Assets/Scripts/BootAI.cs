using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootAI : MonoBehaviour
{
    public GameObject PunktBisBoost;
    public GameObject Ziel;
    public GameObject Sprechblase;
    public GameObject Player;

    private bool PunktBisBoostReached;
    private bool faster;

    void Start()
    {
        Sprechblase.SetActive(false);
        PunktBisBoostReached = false;

        faster = false;
    }

    
    void Update()
    {
        if(faster == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(Player.transform.position.x, transform.position.y), 5 * Time.deltaTime);
        }
        

        if(transform.position.x == Player.transform.position.x && PunktBisBoostReached == false)
        {
            Sprechblase.SetActive(true);
            PunktBisBoostReached = true;

            Invoke("GoFaster", 3);
        }

        if(faster  == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, Ziel.transform.position, 9 * Time.deltaTime);
        }

        if (transform.position.x == Ziel.transform.position.x)
            Destroy(this.gameObject);
    }

    public void GoFaster()
    {
        faster = true;
        Sprechblase.SetActive(false);
    }

    
}
