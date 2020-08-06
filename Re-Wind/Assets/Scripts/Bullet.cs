using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.right * 10;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = -transform.right * 10;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Destroy(this.gameObject);

        if (collision.gameObject.tag == "Cloud")
            Destroy(this.gameObject);
    }
}
