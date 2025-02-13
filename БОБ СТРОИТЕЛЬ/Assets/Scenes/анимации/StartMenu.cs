using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject look;
    float dist;
    public GameObject[] off;
    public GameObject on;
    public GameObject dopmenu;
    public Transform[] point;
    public float speed;
    public int i;

    void Update()
    {
        QualitySettings.shadowDistance = 30;
        Application.targetFrameRate = 40;
        QualitySettings.SetQualityLevel(9);

        dist = Vector3.Distance(point[i].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, point[i].position, speed * Time.deltaTime);

        if(i == 0 || i == 1)
        {
            gameObject.GetComponent<SlowLook>().target = look.transform;
        }
        else
        {
            gameObject.GetComponent<SlowLook>().target = point[i].GetChild(0);
        }
        if (dist < 5)
        {
            if (i == 1)
            {
                on.SetActive(true);
            }
            else if (i == 0)
            {
                for (int i = 0; i < off.Length; i++)
                {
                    off[i].SetActive(true);
                }
            }
            else
            {
                dopmenu.SetActive(true);
            }
        }
    }
    public void startGame()
    {
        i = 1;
        speed = 70;
        for (int i = 0; i < off.Length; i++)
        {
            off[i].SetActive(false);
        }
    }
    public void Back()
    {
        on.SetActive(false);
        i = 0;
        speed = 90;
        
    }
    public void Pokaz()
    {
        on.SetActive(false);
        speed = 50;
    }

}
