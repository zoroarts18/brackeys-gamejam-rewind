using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour
{
    public List<Transform> targets;

    
    private Animator anim;

    public float smoothTime = .5f;

    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimit = 50f;

    private Vector3 velocity;
    private Camera cam;

    
    private Vector3 offSet = new Vector3(0,0,-10);

    public float yMin;
    public float yMax;

    public float xMin;
    public float xMax;

    public int Level;

    public bool PlayerCanControl = false;

    private void Start()
    {
        anim = GetComponent<Animator>();

        cam = GetComponent<Camera>();

      
    }


    private void Update()
    {

        
        
        if (transform.position.x > xMax)
            transform.position =new Vector3(xMax, transform.position.y, transform.position.z);

        if (transform.position.x < xMin)
            transform.position = new Vector3(xMin, transform.position.y, transform.position.z);

        if (transform.position.y > yMax)
            transform.position = new Vector3(transform.position.x, yMax, transform.position.z);

        if (transform.position.y < yMin)
            transform.position = new Vector3(transform.position.x, yMin, transform.position.z);
    }

    private void LateUpdate()
    {
        if (targets.Count == null)
            return;

        
            Move();
            Zoom();
        
       
    }
    
    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimit);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);

    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.x;
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
            return targets[0].position;

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }

    

    private void Move()
    {
        Vector3 CenterPoint = GetCenterPoint();
        Vector3 newPos = CenterPoint + offSet;

        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smoothTime);
    }


   
}
