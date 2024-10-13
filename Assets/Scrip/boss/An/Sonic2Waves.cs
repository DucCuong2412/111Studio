using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonic2Waves : MonoBehaviour
{

    Rigidbody2D rb;
    public float timer, speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime;
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (timer > 4)
        {
            Destroy(this);
        }
    }
}
