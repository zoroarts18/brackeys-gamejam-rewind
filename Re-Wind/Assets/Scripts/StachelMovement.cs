using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StachelMovement : MonoBehaviour
{
    public GameObject GoalOben;
    public GameObject GoalUnten;

    public int reachedCheckPoint;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        if(reachedCheckPoint == 1)
            transform.position = Vector2.MoveTowards(transform.position, GoalUnten.transform.position, 4 * Time.deltaTime);

        if(reachedCheckPoint == 2)
            transform.position = Vector2.MoveTowards(transform.position, GoalOben.transform.position, 4 * Time.deltaTime);



        if (transform.position.y == GoalUnten.transform.position.y && transform.position.x == GoalUnten.transform.position.x)
            reachedCheckPoint = 2;

        if(transform.position.y == GoalOben.transform.position.y && transform.position.x == GoalOben.transform.position.x)
            reachedCheckPoint = 1;
    }
}
