using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPoint : MonoBehaviour
{
    public Transform cam;
    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = cam.position.x;
        newPosition.z = cam.position.z+40;
        newPosition.y = 0f;
        transform.position = newPosition;
    }
}
