using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class InvSlotContent
{
    public string Name;
    public string IconName;
    public int Amount;
    public bool Resource;
    public bool IsItem;
    public Item Item;
    public ResourceDrop ResourceDrop;

    public InvSlotContent(Item item, string name, string iconName)
    {
        Item = item;
        IsItem = true;
        Name = name;
        IconName = iconName;
    }
    public InvSlotContent(ResourceDrop resourceDrop, int amount)
    {
        ResourceDrop = resourceDrop;
        IconName = resourceDrop.Type.ToString() + " Icon";
        Amount = amount;
        Resource = true;
    }
}
