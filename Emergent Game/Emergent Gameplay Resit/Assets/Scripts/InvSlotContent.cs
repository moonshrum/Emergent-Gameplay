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

    public InvSlotContent(Item item)
    {
        Item = item;
        IsItem = true;
        Name = item.Name;
        IconName = item.IconName;
        SpriteName = item.SpriteName;
    }
    public InvSlotContent(ResourceDrop resourceDrop, int amount)
    {
        ResourceDrop = resourceDrop;
        IconName = resourceDrop.Type.ToString() + " Icon";
        Amount = amount;
        Resource = true;
    }
}
