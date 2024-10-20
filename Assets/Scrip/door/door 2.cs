﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class door2 : MonoBehaviour
{

    public GameObject door;
    public CinemachineConfiner2D confiner;
    public Collider2D c1;
    public Collider2D c2;
     Collider2D c3;
    float time;
    public Animator animator;

    private void Update()
    {
        time += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(time > 3)
        {
            if (collision.gameObject.CompareTag("Player") )
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    animator.SetTrigger("startroom");
                    StartCoroutine(TeleportAfterDelay(collision));
                    if (confiner.m_BoundingShape2D == c1)
                    {

                        confiner.m_BoundingShape2D = c2;
                        

                    }
                    else confiner.m_BoundingShape2D = c1;
                    time = 0;


                }
            }
        }
    }

    IEnumerator TeleportAfterDelay(Collider2D collision)
    {
        
        yield return new WaitForSeconds(1f);
        collision.transform.position = door.transform.position;
        animator.SetTrigger("endroom");
    }



}
