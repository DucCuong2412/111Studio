using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulet_left : MonoBehaviour
{
   Rigidbody2D rb;
    public float speed = 15;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
       
    }
    private void Update()
    {
        rb.velocity = new Vector2(-speed, 0);
        Destroy(gameObject,2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }


}
