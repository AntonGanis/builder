using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delate : MonoBehaviour
{
    public float time;
    public float lemit;
    void FixedUpdate()
    {
        time += Time.deltaTime * 5;
        if (time > lemit)
        {
            Destroy(gameObject);
        }
    }
}