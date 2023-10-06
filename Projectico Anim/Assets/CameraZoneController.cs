using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoneController : MonoBehaviour
{
    public string triggerTag;

    public CinemachineVirtualCamera primeraCamera;

    public CinemachineVirtualCamera[] virtualCameras;

    private void Start()
    {
        SwitchToCamera(primeraCamera);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag) ) 
        {
            CinemachineVirtualCamera targetCamera = other.GetComponentInChildren<CinemachineVirtualCamera>();
            SwitchToCamera(targetCamera);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            SwitchToCamera(primeraCamera);
        } 
    }

    private void SwitchToCamera(CinemachineVirtualCamera targetCamera)
    {
        foreach (CinemachineVirtualCamera camera in virtualCameras)
        {
            camera.enabled = camera == targetCamera;
        }
    }


}
