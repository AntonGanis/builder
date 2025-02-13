using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slehka : MonoBehaviour
{
    public Transform target;
    public float speed = 5;

    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * speed);
    }
}
