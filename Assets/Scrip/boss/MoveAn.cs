using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAn : MonoBehaviour
{
    public float speed = 2.5f;

    
    int RandomAtk;
    Transform player;
    Rigidbody2D rb;
    flipboss flipboss;
    shootAn shoot;
    float timer;
    Animator animator;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
       rb= GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {

        
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

       
    }

}
