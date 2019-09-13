using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource
{
    public int Amount;
    public enum ResourceType { Wood, Rock, Water};

    public ResourceType Type;

    public Resource(int _amount, ResourceType _type)
    {
        Amount = _amount;
        Type = _type;
    }

    public void IncreaseResource(int _amount)
    {
        Amount += _amount;
    }

    public void DecreaseResource(int _amount)
    {
        Amount -= _amount;
    }
}
