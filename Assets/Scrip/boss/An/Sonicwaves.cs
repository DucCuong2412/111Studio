using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonicwaves : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed = 10f; 
    float timer = 0;
    void Start()
    {
        
      
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime;
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if(timer >4)
        {
           if(rb != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
