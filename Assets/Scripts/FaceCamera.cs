using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FaceCamera : MonoBehaviour
{

    Transform cam;
    Vector3 TargetAngle = Vector3.zero;
    void Start()
    {
        cam = Camera.main.transform;
    }

    void Update()
    {
        transform.LookAt(cam);
        TargetAngle = transform.localEulerAngles;
        TargetAngle.x = 0;
        TargetAngle.z = 0;
        transform.localEulerAngles = TargetAngle;
    }
}
