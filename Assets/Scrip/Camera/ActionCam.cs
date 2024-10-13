using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Threading;
public class ActionCam : MonoBehaviour
{
    public CinemachineVirtualCamera camboss;
    public CinemachineVirtualCamera camtong;
    public GameObject boss,healthBoss,wall;
    public float timer ;
    public loithoai thoai;

    private void Start()
    {
        boss.SetActive(false);
        timer = 10;
        healthBoss.SetActive(false);
        wall.SetActive(false);
        
    }
    void Update()
    { 
        timer += Time.deltaTime;
        
        if (camboss != null && timer >= 2 &&timer <=4)
        {
            
            CameraCinematic.SwitchCamera(camtong);
            
            this.gameObject.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            thoai.count = 4;
            timer = 0f;
            healthBoss.SetActive(true);
            wall.SetActive(true);
            CameraCinematic.SwitchCamera(camboss);
            boss.SetActive(true);
            
        }
        
    }
   
}
