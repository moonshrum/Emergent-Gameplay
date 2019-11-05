using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public Item.ItemType Type;
    public Item Item;
    public string Name;
    public string IconName;
    public int DamageValue;
    public string SpriteName;
    [System.NonSerialized]
    public Sprite InstructionSprite;

    private void Awake()
    {
        InstructionSprite = Resources.Load<Sprite>("Sprites/Pick Up Icon");
        transform.Find("Instructions Image").GetComponent<SpriteRenderer>().sprite = InstructionSprite;
    }
}
