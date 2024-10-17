using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShadow : MonoBehaviour
{
    GameObject player;
    public GameObject spell;
    Animator animator;
    float timer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        timer = 0;
    }


    void Update()
    {
        float distanceX = Mathf.Abs(transform.position.x - player.transform.position.x);
        float distancey = Mathf.Abs(transform.position.y - player.transform.position.y);
        timer += Time.deltaTime;
        if (timer > 3)
        {
            if (distanceX < 20 && distancey <3)
            {
                animator.SetTrigger("atk");

            }
        }
    }
    public void Atk()
    {
        
        GameObject castskill = Instantiate(spell, player.transform.position, Quaternion.identity);
        Destroy(castskill,1f);
    }

}
