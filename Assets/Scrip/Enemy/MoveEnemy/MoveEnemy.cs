using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    GameObject Player;
    public GameObject Enemy;
    public float speed = 1f;
    public Animator animator;

    float timeSkill;
    public bool isRuning = false;
    public bool isAttacking = false;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponentInChildren<Animator>();
        timeSkill = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        float DistanceX = Mathf.Abs(Enemy.transform.position.x - Player.transform.position.x);
        float DistanceY = Mathf.Abs(Enemy.transform.position.y - Player.transform.position.y);
        
        Debug.Log(timeSkill);


        if (Player != null)
        {
            LookatPlayer();
            if (!isAttacking)
            {
                Vector3 targetPos = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
                

                if (DistanceX > 3 && DistanceX <= 10 && DistanceY < 5)
                {
                   
                    isRuning = true;
                    transform.position = targetPos;
                    animator.SetTrigger("run");
                }
                else
                {
                    isRuning = false;
                }
            }
            if ( DistanceY <= 2 && DistanceX <= 4 && !isRuning)
            {
                timeSkill -= Time.deltaTime;
                timeSkill = Mathf.Abs(timeSkill);
                if (timeSkill <  1)
                {
                    
                    animator.SetTrigger("atk");
                    isAttacking = true;
                    timeSkill = 2;
                }
                else
                {
                    isAttacking = false;
                }
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

    public void atk()
    {
        animator.SetTrigger("atk");
        isAttacking = true;
        
    }
}
