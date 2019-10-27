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
    public int Price;
    public enum ItemType { Weapon, Armor, Trap, Torch};
    public ItemType Type;
}
