using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : ScriptableObject
{
    public int coin;

    public Action<int> ManipulateCoin;

    public void AddCoins(int Amount)
    {
        coin += Amount;
        ManipulateCoin?.Invoke(coin);
    }

    public void RemoveCoins(int Amount)
    {
        if(coin > 0)
        {
            coin -= Amount;
        }
        else if(Amount > coin)
        {
            return;
        }
        else if(coin <= 0 )
        {
            coin = 0;
        }
        ManipulateCoin?.Invoke(coin);
    }
}
