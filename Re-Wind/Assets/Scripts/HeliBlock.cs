using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliBlock : MonoBehaviour
{
    public Transform Player;
    public Transform shootPoint;

    public GameObject Bullet;

    public bool inRange;

    private float ReloadTime = 2;
    private float TimeBetweenShots;

    private int life;

    public bool moving;
    void Start()
    {
        
    }

    public void Shoot()
    {
        GameObject currentBullet = Instantiate(Bullet, new Vector2(shootPoint.position.x, shootPoint.position.y), Quaternion.identity);
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(moving)
        {
            if (other.gameObject.tag == "Player")
                inRange = true;
        }
        

       
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(moving)
        {
            if (other.gameObject.tag == "Player")
                inRange = false;
        }
        

    }

    

    void Update()
    {
        if(moving)
        {
            transform.position = new Vector2(transform.position.x, Player.position.y);
        }
        

        if (inRange && TimeBetweenShots <= 0)
        {
            Shoot();
            TimeBetweenShots = ReloadTime;
        }

        else if (inRange && TimeBetweenShots > 0)
            TimeBetweenShots -= Time.deltaTime;
           

        if(!moving && TimeBetweenShots <= 0)
        {
            Shoot();
            TimeBetweenShots = ReloadTime;
        }

        else if (!moving && TimeBetweenShots > 0)
            TimeBetweenShots -= Time.deltaTime;
    }
}
