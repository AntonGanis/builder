using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reiting : MonoBehaviour
{
    GameObject save;

    [Header("Монеты")]
    public int coins;
    public Text t0;
    public int reward_MAX;
    public int reward;
    public Text t;

    [Header("Звезды")]
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    int star;

    [Header("Монеты")]
    public Text t1;

    [Header("Время")]
    public float sec_pred;
    public float min_pred;
    public int sec;
    public int min;
    public float T_r;

    [Header("Голуби")]
    public int pigeons;
    public int pigeons_pred;

    [Header("блоки")]
    public RandomMovement move;
    public koordinate koord;
    public float block_pred;
    public float B_r;
    public float B_r_pred;
    int i;

    void Start()
    {
        coins = Magazine_data.coins;
        save = GameObject.FindGameObjectWithTag("сохронять");
    }
    void Update()
    {
        if (koord == null) { B_r = block_pred / (float)move.blocks.Count; }
        else { B_r = koord.gotovo; }
        float sec2 = (float)sec;
        float s_r = sec_pred / sec2;
        float min2 = (float)min;
        float m_r = min_pred / min2;
        if (min != 0) { T_r = s_r * m_r; }
        else { T_r = 1; }
        if(T_r >= 1 && B_r >= B_r_pred && pigeons == pigeons_pred)
        {
            star = 3;
            reward = reward_MAX;
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        else if ((T_r >= 1 && B_r >= B_r_pred && pigeons != pigeons_pred) || (T_r >= 1 && B_r < B_r_pred && pigeons == pigeons_pred) || (T_r < 1 && B_r >= B_r_pred && pigeons == pigeons_pred))
        {
            star = 2;
            reward = reward_MAX*2/3;
            star1.SetActive(true);
            star2.SetActive(true);
        }
        else
        {
            star = 1;
            reward = reward_MAX/3;
            star1.SetActive(true);
        }
        i = Convert.ToInt32(B_r*100);
        t1.text = i.ToString("D1") + "%";
        t0.text = coins.ToString("D1");
        t.text = "+" + reward.ToString("D1");

    }
    public void Load_Coins_Reiting()
    {
        coins += reward;
        if (coins > 999)
        {
            coins = 999;
        }
        Magazine_data.coins = coins;
        int lvl = SceneManager.GetActiveScene().buildIndex - 1;
        if (Reiting_Data.star[lvl] < star)
        {
            if (Reiting_Data.star[lvl] != 0)
            {
                save.GetComponent<SaveTransform>().destroy[lvl] = true;
            }
            Reiting_Data.star[lvl] = star;
            Reiting_Data.min[lvl] = min;
            Reiting_Data.sec[lvl] = sec;
            Reiting_Data.accuracy[lvl] = i;
            Reiting_Data.pigeons[lvl] = pigeons;
 
            Transform mat = move.bulletMat;
            mat.parent = save.transform.GetChild(lvl);
            for (int i = 0; i < mat.childCount; i++)
            {
                mat.transform.GetChild(i).gameObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }      
    }
    public void Next()
    {
        int lvl = SceneManager.GetActiveScene().buildIndex+1;
        Application.LoadLevel(lvl);
    }
}
