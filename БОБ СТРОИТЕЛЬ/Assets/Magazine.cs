using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magazine : MonoBehaviour
{
    public int coins;
    public Text tTt;

    public Text tT1;
    public int k1;
    public Text tT2;
    public int k2;
    public Text tT3;
    public int k3;

    void Start()
    {
        coins = Magazine_data.coins;
        k1 = Magazine_data.gluy;
        k2 = Magazine_data.lazer;
        k3 = Magazine_data.TNT;
    }
    void Update()
    {
        tTt.text = coins.ToString("D1");
        tT1.text = "X" + k1.ToString("D1");
        tT2.text = "X" + k2.ToString("D1");
        tT3.text = "X" + k3.ToString("D1");
    }
    public void Load_Coins_Magazine()
    {
        Magazine_data.coins = coins;
        Magazine_data.gluy = k1;
        Magazine_data.lazer = k2;
        Magazine_data.TNT = k3;
    }
}
