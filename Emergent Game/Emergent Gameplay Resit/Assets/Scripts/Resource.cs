using System;

[Serializable]
public class Resource
{
    public int Amount;
    public enum ResourceType { Wood, BearSkin, GoldOre, IronOre, Berry, PoisonBerry, Meat, None};
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
