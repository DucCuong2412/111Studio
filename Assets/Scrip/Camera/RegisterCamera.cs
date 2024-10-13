using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class RegisterCamera : MonoBehaviour
{
    private void OnnEable()
    {
        CameraCinematic.Register(GetComponent<CinemachineVirtualCamera>());
    }
    private void OnDisable()
    {

        CameraCinematic.UnRegister(GetComponent<CinemachineVirtualCamera>());
    }
}
