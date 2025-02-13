using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end : Sounds
{
    public bool Tab;
    public Complided[] Comp;
    public int t;
    int Length;
    int sohr;//перепроверка размера массива

    float time;
    public GameObject VSO;
    public GameObject defeat;
    public GameObject Menu;
    public GameObject[] off;
    public MouseLook cam;
    public CameraMove cam2;
    public RandomMovement move;
    public BonusManager BonusManager;
    public Maket Maket;
    public GameObject pigeons;
    bool isLocked;
    bool sound = true;

    void Start() { Length = Comp.Length; }
    public void One()
    {
        OnOff(!isLocked);
        isLocked = !isLocked;
    }
    void OnOff(bool isLocked)
    {
        Tab = isLocked;
        gameObject.GetComponent<AudioSource>().enabled = !isLocked;
        pigeons.GetComponent<star>().enabled = !isLocked;
        pigeons.GetComponent<AudioSource>().enabled = !isLocked;
        cam2.enabled = !isLocked;
        cam.enabled = !isLocked;
        move.enabled = !isLocked;
        BonusManager.enabled = !isLocked;
        for (int i = 0; i < off.Length; i++)
        {
            off[i].SetActive(!isLocked);
        }
        Screen.lockCursor = !isLocked;
        Cursor.visible = isLocked;
        Menu.SetActive(isLocked);
    }
    void Update()
    {
        if (Comp.Length == 0 || Length != Comp.Length)
        {
            if (sound)
            {
                PlaySound(sounds[1], 1, false, false, p1: 1, p2: 1);
                sound = false;
            }
            Tab = true;
            pigeons.GetComponent<star>().enabled = false;
            pigeons.GetComponent<AudioSource>().enabled = false;
            Menu.SetActive(false);
            cam2.enabled = false;
            cam.enabled = false;
            move.enabled = false;
            BonusManager.enabled = false;
            for (int i = 0; i < off.Length; i++)
            {
                off[i].SetActive(false);
            }
            Screen.lockCursor = false;
            Cursor.visible = true;
            defeat.SetActive(true);
        }
        else
        {
            if (sohr != Comp.Length)
            {
                t = 0;
            }
            for (int i = 0; i < Comp.Length; i++)
            {
                if (Comp[i].end == true && Comp[i].of == false)
                {
                    t++;
                    Comp[i].of = true;
                }
            }
            if (t == Comp.Length)
            {
                time += Time.deltaTime;
                if (time >= 1.5f)
                {
                    if (sound)
                    {
                        PlaySound(sounds[0], 1, false, false, p1: 1, p2: 1);
                        sound = false;
                    }
                    Tab = true;
                    pigeons.GetComponent<star>().enabled = false;
                    pigeons.GetComponent<AudioSource>().enabled = false;
                    Menu.SetActive(false);
                    cam2.enabled = false;
                    cam.enabled = false;
                    move.enabled = false;
                    BonusManager.enabled = false;
                    for (int i = 0; i < off.Length; i++)
                    {
                        off[i].SetActive(false);
                    }
                    Screen.lockCursor = false;
                    Cursor.visible = true;
                    VSO.SetActive(true);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space) && Maket.isLocked == false)
                {
                    OnOff(!isLocked);
                    isLocked = !isLocked;
                }
            }
        }
        sohr = Comp.Length;
    }
}
