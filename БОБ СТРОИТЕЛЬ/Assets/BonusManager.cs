using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusManager : Sounds
{
    public Text t1;
    public Text t2;
    public Text t3;
    public int bon1;
    public int bon2;
    public int bon3;

    public RandomMovement move;
    public SkipElement SkipElement;

    public GameObject laz1;
    public GameObject laz2;
    public GameObject laz3;
    public GameObject laz4;

    public Transform boom;

    bool e;
    bool laz;

    void Start()
    {
        bon1 = Magazine_data.gluy;
        bon2 = Magazine_data.lazer;
        bon3 = Magazine_data.TNT;
        t1 = t1.gameObject.GetComponent<Text>();
        t2 = t2.gameObject.GetComponent<Text>();
        t3 = t3.gameObject.GetComponent<Text>();
        t1.text = "X" + bon1.ToString("D1");
        t2.text = "X" + bon2.ToString("D1");
        t3.text = "X" + bon3.ToString("D1");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && bon1 != 0 && move.glue==false)
        {
            PlaySound(sounds[0], 1);
            move.glue = true;
            bon1--;
            t1.text = "X" + bon1.ToString("D1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && bon2 != 0 && e == false)
        {
            laz1.SetActive(true);
            laz2.SetActive(true);
            laz3.SetActive(true);
            laz4.SetActive(true);
            e = true;
            bon2--;
            t2.text = "X" + bon2.ToString("D1");
            laz = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && bon3 != 0 && move.blocks.Count != 0)
        {
            PlaySound(sounds[2], 1);
            GameObject bloc = move.blocks[move.blocks.Count - 1];
            Instantiate(boom, bloc.transform.position, bloc.transform.rotation);
            move.blocks.RemoveAt(move.blocks.Count - 1);
            move.N[move.Last]++;
            SkipElement.text[move.Last].text = move.N[move.Last].ToString("D1");
            bloc.SetActive(false);
            bloc.transform.parent = null;
            bon3--;
            t3.text = "X" + bon3.ToString("D1");
        }
        if (laz) { PlaySound(sounds[1], 0.1f, true, false, p1: 1, p2: 1); }
    }
    public void Load_Bonus_Magazine()
    {
        Magazine_data.gluy = bon1;
        Magazine_data.lazer = bon2;
        Magazine_data.TNT = bon3;
    }
}
