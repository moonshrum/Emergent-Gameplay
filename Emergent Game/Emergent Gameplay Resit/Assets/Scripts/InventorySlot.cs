
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot
{
    public string Name;
    public string IconName;
    public int Amount;
    public bool Resource;
    public Item Item;
    public ResourceDrop ResourceDrop;

    public InventorySlot(Item item, string name, string iconName)
    {
        Item = item;
        Name = name;
        IconName = iconName;
    }
    /*public InventorySlot(Resource resource)
    {
        _resource = resource;
        IconName = resource.Type.ToString() + " Icon";
        Stackable = true;
    }*/
    public InventorySlot(ResourceDrop resourceDrop, int amount)
    {
        ResourceDrop = resourceDrop;
        IconName = resourceDrop.Type.ToString() + " Icon";
        Amount = amount;
        Resource = true;
    }

}
