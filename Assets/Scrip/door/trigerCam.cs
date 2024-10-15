using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigerCam : MonoBehaviour
{

    public CinemachineConfiner2D confiner;
    public Collider2D c1;
    public Collider2D c2;
    Collider2D c3;
    public  int count = 1;
    bool isC1runing = true;
    bool isC2runing = false;
    float time;
    private void Start()
    {
        count = 1;
        
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            if (confiner.m_BoundingShape2D == c1)
            {
                confiner.m_BoundingShape2D = c2;
               isC1runing = false;
                isC2runing = true;
            }
            else if(confiner.m_BoundingShape2D == c2 && isC2runing)
            {
                confiner.m_BoundingShape2D = c1;
                isC1runing = true;
                isC2runing = false;
            }
        }
        
    }
   
}
   
   
