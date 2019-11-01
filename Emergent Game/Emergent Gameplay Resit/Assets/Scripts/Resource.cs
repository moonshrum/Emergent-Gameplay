using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class Resource
{
    public int Amount;
    public enum ResourceType { Wood, BearSkin, Cloth, GoldOre, IronOre, Berry, PoisonBerry, Meat, None};
    public ResourceType Type;

    public void IncreaseResource(int _amount)
    {
        Amount += _amount;
    }

    public void DecreaseResource(int _amount)
    {
        Amount -= _amount;
    }
}
