using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyBonus : MonoBehaviour
{
    public Magazine magazine;
    public int price;
    public void Buy_one()
    {
        if((magazine.coins - price) >= 0 && magazine.k1 != 10)
        {
            magazine.coins -= price;
            magazine.k1 += 1;
        }
    }
    public void Buy_two()
    {
        if ((magazine.coins - price) >= 0 && magazine.k2 != 5)
        {
            magazine.coins -= price;
            magazine.k2 += 1;
        }
    }
    public void Buy_tri()
    {
        if ((magazine.coins - price) >= 0 && magazine.k3 != 15)
        {
            magazine.coins -= price;
            magazine.k3 += 1;
        }
    }

}
