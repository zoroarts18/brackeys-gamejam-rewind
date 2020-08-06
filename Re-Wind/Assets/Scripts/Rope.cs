using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public LineRenderer lr;

    public GameObject ropeStart;
    public GameObject ropeEnd;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    
    void Update()
    {
        lr.positionCount = 2;

        lr.SetPosition(0, ropeStart.transform.position);
        lr.SetPosition(1, ropeEnd.transform.position);
    }
}
