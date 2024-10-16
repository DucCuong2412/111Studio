using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class DinhActionCam : MonoBehaviour
{
    
    float time;
    
    public CinemachineVirtualCamera camtong;
    void Start()
    {           
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            CameraCinematic.SwitchCamera(camtong);

        }

    }
}
