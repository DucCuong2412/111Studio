using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThayAnMove : StateMachineBehaviour
{
    public float speed = 2.5f;


    Transform player;
    Rigidbody2D rb;
    flipboss flipboss;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo animatorState, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        flipboss = animator.GetComponent<flipboss>();

    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo animatorState, int layerIndex)
    {
        flipboss.LookatPlayer();
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo animatorState, int layerIndex)
    {

    }
}
