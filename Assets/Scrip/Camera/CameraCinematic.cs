using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;
public class CameraCinematic : MonoBehaviour
{
    static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();
    
    public static CinemachineVirtualCamera ActiveCamera = null;


    public static bool IsActiveCamera(CinemachineVirtualCamera cam)
    { 
        return cam == ActiveCamera;
    }

    public static void SwitchCamera(CinemachineVirtualCamera newCam)
    {
        newCam.Priority = 10;
        ActiveCamera = newCam;
        foreach(CinemachineVirtualCamera cam in cameras)
        {
            if(cam != newCam)
            {
                cam.Priority = 0;
            }
        }
    }


     public static void Register(CinemachineVirtualCamera cam)
    {
        cameras.Add(cam);
    }
    public static void UnRegister(CinemachineVirtualCamera cam)
    {
        cameras.Remove(cam);
    }



}
