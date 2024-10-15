using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class DinhActionCam : MonoBehaviour
{
    public GameObject BossDinh;
    float time;
    public GameObject wall;
    public CinemachineVirtualCamera camtong;
    void Start()
    {
        BossDinh.SetActive(false);
        wall.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        wall.SetActive(true);
        CameraCinematic.SwitchCamera(camtong);
        BossDinh.SetActive(true );
    }
}
