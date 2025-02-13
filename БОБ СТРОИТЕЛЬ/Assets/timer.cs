using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timer : MonoBehaviour
{
    int sec;
    int min;
    public Text tTt;
    public Text tTtMenu;
    float time;
    public Reiting menu;
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 1)
        {
            sec++;
            time = 0;
        }
        if(sec == 59)
        {
            min++;
            sec = 0;
        }
        tTt.text = min.ToString("D2") + ":" + sec.ToString("D2");
        tTtMenu.text = min.ToString("D2") + ":" + sec.ToString("D2");
        menu.sec = sec;
        menu.min = min;
    }
}
