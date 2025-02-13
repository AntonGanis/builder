using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOOK : MonoBehaviour
{
    public Transform target;
   
    void LateUpdate()
    {
        transform.LookAt(target.position);
    }
}

