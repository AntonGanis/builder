using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class The_Best : MonoBehaviour
{
    public GameObject cam;
    public GameObject start;
    public GameObject go;
    public GameObject back;

    int iii;
    public GameObject[] star;
    public Text Time;
    public Text Accuracy;
    public Text Pigeons;

    int min;
    int sec;
    int accuracy;
    int pigeons;

    int levl;
    void Update()
    {
        GameObject saves = GameObject.FindGameObjectWithTag("сохронять");
        if (saves.GetComponent<SaveTransform>().complit[levl] == true)
        {
            go.GetComponent<Button>().enabled = true;
            go.SetActive(true);
        }
        else
        {
            if (levl != 9)
            {
                go.GetComponent<Button>().enabled = false;
                go.SetActive(false);
            }
        }
    }
    void Loot_Reiting(int i)
    {
        levl = i;
        if (i == 1){back.SetActive(false);}
        else if(i == 9){go.SetActive(false);}
        else
        {
            back.SetActive(true);
            go.SetActive(true);
        }
        int k = i - 1;
        int staro = Reiting_Data.star[k];
        min = Reiting_Data.min[k];
        sec = Reiting_Data.sec[k];
        accuracy = Reiting_Data.accuracy[k];
        pigeons = Reiting_Data.pigeons[k];
        start.GetComponent<Button>().onClick.AddListener(delegate { start.GetComponent<menu>().startGame(i); });

        for (int j = 0; j < staro; j++)
        {
            star[j].SetActive(true);
        }
        Time.text = min.ToString("D2") + ":" + sec.ToString("D2");
        Accuracy.text = accuracy.ToString("D1") +"%";
        Pigeons.text = pigeons.ToString("D1");
    }
    public void pokaz(int i)
    {
        cam.GetComponent<StartMenu>().i = i + 1;
        iii = i;
        Loot_Reiting(i);
    }
    public void Go()
    {
        iii += 1;
        for (int j = 0; j < 3; j++)
        {
            star[j].SetActive(false);
        }
        cam.GetComponent<StartMenu>().i = iii+1;
        Loot_Reiting(iii);
    }
    public void Back()
    {
        iii -= 1;
        for (int j = 0; j < 3; j++)
        {
            star[j].SetActive(false);
        }
        cam.GetComponent<StartMenu>().i = iii + 1;
        Loot_Reiting(iii);
    }
    public void Nazad()
    {
        cam.GetComponent<StartMenu>().i = 1;
        cam.GetComponent<StartMenu>().speed = 100;
    }
}
