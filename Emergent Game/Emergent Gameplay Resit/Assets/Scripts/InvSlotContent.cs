using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvSlotContent
{
    public string Name;
    public string IconName;
    public int Amount;
    public bool Resource;
    public Item Item;
    public ResourceDrop ResourceDrop;

    public InvSlotContent(Item item, string name, string iconName)
    {
        Item = item;
        Name = name;
        IconName = iconName;
    }
    /*public InvSlotContent(Resource resource)
    {
        _resource = resource;
        IconName = resource.Type.ToString() + " Icon";
        Stackable = true;
    }*/
    public InvSlotContent(ResourceDrop resourceDrop, int amount)
    {
        ResourceDrop = resourceDrop;
        IconName = resourceDrop.Type.ToString() + " Icon";
        Amount = amount;
        Resource = true;
    }
}
