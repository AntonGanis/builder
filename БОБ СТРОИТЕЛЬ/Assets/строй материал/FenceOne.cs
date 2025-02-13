using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceOne : MonoBehaviour
{
    public int I;
    int J;
    void Update()
    {
        if (J < I)
        {
            J++;
        }
        else
        {
            gameObject.GetComponent<Animator>().SetTrigger("нач");
        }
    }
}
