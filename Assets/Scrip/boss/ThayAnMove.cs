using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;


public class ThayAnMove : StateMachineBehaviour
{
    public float speed = 2.5f;

    public float atkRange = 20f;
    int RandomAtk,RandomAtk2;
    Transform player;
    Rigidbody2D rb;
    flipboss flipboss;
    shootAn shoot;
    float timer;

  
    override public void OnStateEnter(Animator animator, AnimatorStateInfo animatorState, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        flipboss = animator.GetComponent<flipboss>();
        shoot = animator.GetComponent <shootAn>();
       

    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo animatorState, int layerIndex)
    {
        
        flipboss.LookatPlayer();

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);
        rb.position = newPos;
        Debug.Log("New Position: " + newPos);
        float distance = Vector2.Distance(player.position, rb.position);

        Debug.Log("khonag cach"+distance);
        if (distance <= atkRange && atkRange != 0)
        {

            timer += Time.deltaTime;
            if (timer > 3)
            {
                if (distance <= 20)
                {
                    RandomAtk = UnityEngine.Random.Range(0, 2);

                }
                if (RandomAtk == 0)
                {
                    animator.SetTrigger("atk2");
                }
                else
                {
                    animator.SetTrigger("atk1");
                }
                timer = 0f;
            }if(timer>= 2 && distance <=4)
            {
                if (distance < 4 )
                {
                    animator.SetTrigger("atk3");
                    shoot.tuluc();
                    
                }if (distance < 2  ) 
                {
                    animator.SetTrigger("atk4");
                }
                timer = 0f;
            }

        }

    }
    public void performaAtk()
    {
        if(atkRange == 0)
        {
            shoot.atk1();
        }
        else
        {
            shoot.atk2();
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo animatorState, int layerIndex)
    {
        animator.ResetTrigger("atk1");
        animator.ResetTrigger("atk2");
        animator.ResetTrigger("atk3");
    }
}
