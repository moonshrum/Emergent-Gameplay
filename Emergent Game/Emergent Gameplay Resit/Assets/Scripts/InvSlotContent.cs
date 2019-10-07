using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class InvSlotContent
{
    public string Name;
    public string IconName;
    public string SpriteName;
    public int Amount;
    public bool Resource;
    public bool IsItem;
    public Item Item;
    public ResourceDrop ResourceDrop;

    public InvSlotContent(Item item, string name, string iconName, string spriteName)
    {
        Item = item;
        IsItem = true;
        Name = name;
        IconName = iconName;
        SpriteName = spriteName;
    }
    public InvSlotContent(ResourceDrop resourceDrop, int amount)
    {
        ResourceDrop = resourceDrop;
        IconName = resourceDrop.Type.ToString() + " Icon";
        Amount = amount;
        Resource = true;
    }
}
