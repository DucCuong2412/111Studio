using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{


    public GameObject Fireball;
    public Transform FireballPos;

    private float timer;
     public float timershoot = 3f;
    private bool isAttacking = false;
    private GameObject player;
    Animator animator;
    void Start()    
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }
    void Update()
    {
       
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < 7)
        {
            timer += Time.deltaTime;
            
                
                if (timer > timershoot)
                {
                    StartAttack();
                    Invoke("shoot", 0.5f);
                    timer = 0;
                    Invoke("StopAttack", 0.8f);
            }
           
        }
        
    }
    public void StartAttack()
    {
        animator.SetBool("atk", true);
        timer = 0;
        isAttacking = true;
       
    }
    void StopAttack()
    {
        animator.SetBool("atk", false); 
        isAttacking=false;
    }
    public void shoot()
    {
        Instantiate(Fireball,FireballPos.position, Quaternion.identity);
    }

  
}
