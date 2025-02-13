using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        Vector3 currentLocalPosition = transform.localPosition;
        currentLocalPosition.x = 0;
        transform.localPosition = currentLocalPosition;

        if (Input.GetKey(KeyCode.Q) && gameObject.transform.localPosition.z >= -16)
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E) && gameObject.transform.localPosition.z <= -5)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}
