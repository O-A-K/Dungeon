using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OK_BillboardingObject : MonoBehaviour
{
    private Transform ObjectTransform;
    private Camera CameraInUse;

    private void Start()
    {
        SetReferences();
    }

    private void LateUpdate()
    {
        ObjectTransform.forward = CameraInUse.transform.forward;
        
    }

    void SetReferences()
    {
        ObjectTransform = transform;
        CameraInUse = Camera.main;
    }
}
