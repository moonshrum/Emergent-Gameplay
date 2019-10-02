﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class Resource
{
    public int Amount;
    public enum ResourceType { Wood, AnimalSkin, Stone, Cloth, GoldOre, IronOre, PoisonBerry, Meat};
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
