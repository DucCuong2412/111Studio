using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MoveShadow : MonoBehaviour
{
    
    public GameObject spell ;
    Animator animator;
    float timer;
    public Transform player;
    public float Distance = 0;  
    public bool isFliped = false;

    void Start()
    {
        
        animator = GetComponent<Animator>();
        timer = 0;
    }


    void Update()
    {
        
        float distanceX = Mathf.Abs(transform.position.x - player.transform.position.x);
        float distancey = Mathf.Abs(transform.position.y - player.transform.position.y);

            if (distanceX < Distance && distancey <3)
            {
                timer += Time.deltaTime;
                if (timer > 2) 
                {
                    animator.SetTrigger("atk");
                    LookatPlayer();
                    timer = 0;
                }
                
            }
        

        
    }
    public void Atk()
    {
        
        GameObject castskill = Instantiate(spell, player.transform.position, Quaternion.identity);
        Destroy(castskill,1f);
    }

    public void LookatPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x < player.position.x && isFliped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFliped = false;
        }
        else if (transform.position.x > player.position.x && !isFliped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFliped = true;
        }
    }

}
