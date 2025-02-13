using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer : MonoBehaviour
{
    public Transform spawn;
    public Transform line;
    public Transform point;

    void Update()
    {
            Ray ray = new Ray(spawn.position, transform.up * -1);
            Debug.DrawRay(spawn.position, transform.up * -1 * 60, Color.red);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                point.position = hit.point;
                float Y = point.localPosition.y / 2;
                line.transform.localPosition = new Vector3(0, Y, 0);
                line.transform.localScale = new Vector3(0.2f, Y, 0.2f);
            }
    }
}
