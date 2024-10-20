using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    GameObject Player;
    public GameObject Enemy;
    public float speed = 1f;
    public Animator animator;


    public bool isRuning = false;
    public bool isAttacking = false;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float DistanceX = Mathf.Abs(Enemy.transform.position.x - Player.transform.position.x);
        float DistanceY = Mathf.Abs(Enemy.transform.position.y - Player.transform.position.y);

        Vector3 targetPos = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        
        if (Player != null)
        {
            LookatPlayer();
            if (DistanceX  >4&& DistanceX <=10 && DistanceY<5 && !isAttacking ) 
            {
                isRuning = true;
                transform.position = targetPos;
                animator.SetTrigger("run");
                
            }
            else
            {
                isRuning=false;
            }
            if (DistanceY >1 && DistanceY <=2 && DistanceX < 5 && !isRuning)
            {
                animator.SetTrigger("atk");
                isAttacking = true;
            }
            
           
        }
    }
    
    public void LookatPlayer()
    {
        Vector3 direction = Player.transform.position - Enemy.transform.position;

        if (direction.x > 0)
        {
           
            Enemy.transform.rotation = Quaternion.Euler(0, 0, 0); 
        }
        else if (direction.x < 0)
        {

            Enemy.transform.rotation = Quaternion.Euler(0, 180, 0); 
        }
    }
}
