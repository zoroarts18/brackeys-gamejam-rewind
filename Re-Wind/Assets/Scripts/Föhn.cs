using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Föhn : MonoBehaviour
{
    public GameObject Ballon;

    public Vector3 mousePos;
    private Vector3 offSet = new Vector3(0, 0, 10);

    public float mouseWheel;

    private Rigidbody2D rb;
    private float x;
    private float y;

    public float xMax;
    public float xMin;

    public float yMax;
    public float yMin;

    
    private AreaEffector2D areaEffector2D;

    void Start()
    {
        areaEffector2D = GetComponent<AreaEffector2D>();
        areaEffector2D.enabled = false;

        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {

        if (transform.position.x > xMax)
            transform.position = new Vector3(xMax, transform.position.y, transform.position.z);

        if (transform.position.x < xMin)
            transform.position = new Vector3(xMin, transform.position.y, transform.position.z);

        if (transform.position.y > yMax)
            transform.position = new Vector3(transform.position.x, yMax, transform.position.z);

        if (transform.position.y < yMin)
            transform.position = new Vector3(transform.position.x, yMin, transform.position.z);



        

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        //rb.velocity = new Vector2(x * 10, y* 10);

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, rotZ);


        mouseWheel += Input.GetAxis("Mouse ScrollWheel") * 100;


        transform.position = mousePos + offSet;
        transform.rotation = Quaternion.Euler(0,0,mouseWheel);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            areaEffector2D.enabled = true;
            areaEffector2D.forceAngle = 0;
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            areaEffector2D.enabled = false;
        }


        

    }
}
