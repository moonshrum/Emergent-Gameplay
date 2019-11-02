using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string Name;
    public string Description;
    //public List<Resource> Recipe = new List<Resource>();
    public string IconName;
    public string SpriteName;
    public enum ItemType { Sword, Axe, Pickaxe, Shovel, Shield, Torch, EmptyBucket, FullBucket, Campfire, BearTrap, Cloth, None};
    public enum Equipable { None, Hand, Body};
    public ItemType Type;
    public Equipable EquipablePart;
}
