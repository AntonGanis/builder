using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualBlock : MonoBehaviour
{
    public SkipElement skip;
    public int i;
    public GameObject qq;
    public RandomMovement move;
    public GameObject qqq;

    void Update()
    {
        if (i == skip.selectedWeapon)
        {
            qq.SetActive(true);
            if (move.glue)
            {
                qqq.SetActive(true);
            }
            else { qqq.SetActive(false); }
        }
        else { qq.SetActive(false); }
    }
}
