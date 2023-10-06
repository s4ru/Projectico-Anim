using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public Camera Cam;
    Vector3 pos;
    public float offset = 2f;

    
    void Update()
    {
        pos = Input.mousePosition;
        pos.z = offset;
        transform.position = Cam.ScreenToWorldPoint(pos);
    }
}
