using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<KeyValuePair<int, Item>> InventoryList = new List<KeyValuePair<int, Item>>();
    private int _itemIdCount; // ID that indicated each item's place in the Items List

    private void Start()
    {
        
    }

    public void AddItem(Item item)
    {
        _itemIdCount++;
        InventoryList.Add(new KeyValuePair<int, Item>(_itemIdCount, item));
    }

    public void RemoveItem(Item item)
    {
        KeyValuePair<int, Item> itemToRemove = new KeyValuePair<int, Item>();
        foreach (KeyValuePair<int, Item> pair in InventoryList)
        {
            if (pair.Value.Name == item.Name)
            {
                itemToRemove = pair;
            }
        }
        InventoryList.Remove(itemToRemove);
        _itemIdCount--;
    }
}
