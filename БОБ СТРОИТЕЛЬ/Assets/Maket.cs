using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maket : Sounds
{
    GameObject save;

    public GameObject[] off;
    public GameObject maket;
    public GameObject end;
    public bool isLocked = false;
    void Start()
    {
        save = GameObject.FindGameObjectWithTag("сохронять");
    }
    void OnOff(bool isLocked)
    {
        maket.SetActive(isLocked);
        save.SetActive(!isLocked);
        end.GetComponent<AudioSource>().enabled = !isLocked;
        for (int i = 0; i < off.Length; i++)
        {
            off[i].SetActive(!isLocked);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            PlaySound(sounds[0], p1: 1.5f, p2: 1.6f);
            OnOff(!isLocked);
            isLocked = !isLocked;
        }
    }
}
