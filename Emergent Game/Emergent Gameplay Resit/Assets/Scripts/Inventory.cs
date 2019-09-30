using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public Player Player;
    public int InventoryLimit = 10;
    public GameObject InventoryItemPrefab;
    public GameObject ItemsContainer;
    public List<KeyValuePair<int, InventorySlot>> InventoryList = new List<KeyValuePair<int, InventorySlot>>();
    private int _itemIdCount; // ID that indicated each item's place in the Items List


    private void Start()
    {
        
    }

    public void AddItem(InventorySlot inventorySlot)
    {
        if (InventoryList.Count >= InventoryLimit)
        {
            //TODO: Let player know there is no more space
            Debug.Log("Inventory is full");
            return;
        }
        if (inventorySlot.Resource)
        {
            bool resourceDuplicate = false;
            foreach (KeyValuePair<int, InventorySlot> pair in InventoryList)
            {
                if (pair.Value.ResourceDrop.Type == inventorySlot.ResourceDrop.Type)
                {
                    resourceDuplicate = true;
                }
            }
            if (!resourceDuplicate)
            {
                _itemIdCount++;
                InventoryList.Add(new KeyValuePair<int, InventorySlot>(_itemIdCount, inventorySlot));
                UpdateInventoryUI();
                UpdatePlayerResources(inventorySlot.Amount, inventorySlot.ResourceDrop.Type);
            }
            else
            {
                foreach (KeyValuePair<int, InventorySlot> pair in InventoryList)
                {
                    if (pair.Value.ResourceDrop.Type == inventorySlot.ResourceDrop.Type)
                    {
                        pair.Value.Amount += inventorySlot.Amount;
                    }
                }
                UpdateInventoryUI();
                UpdatePlayerResources(inventorySlot.Amount, inventorySlot.ResourceDrop.Type);
                foreach (Resource resource in Player.AllResources)
                {
                    Debug.Log(resource.Amount);
                }
            }
        } else
        {
            _itemIdCount++;
            InventoryList.Add(new KeyValuePair<int, InventorySlot>(_itemIdCount, inventorySlot));
            UpdateInventoryUI();
        }
    }

    public void RemoveItem(Item item)
    {
        KeyValuePair<int, InventorySlot> itemToRemove = new KeyValuePair<int, InventorySlot>();
        foreach (KeyValuePair<int, InventorySlot> pair in InventoryList)
        {
            if (pair.Value.Name == item.Name)
            {
                itemToRemove = pair;
            }
        }
        InventoryList.Remove(itemToRemove);
        _itemIdCount--;
    }

    private void UpdateInventoryUI()
    {
        ClearInventoryContainer();
        foreach (KeyValuePair<int, InventorySlot> pair in InventoryList)
        {
            GameObject InventoryItem = Instantiate(InventoryItemPrefab, ItemsContainer.transform);
            InventoryItem.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Icons/" + pair.Value.IconName);
            if (pair.Value.Resource)
            {
                InventoryItem.transform.GetChild(1).gameObject.SetActive(true);
                InventoryItem.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = pair.Value.Amount.ToString();
            }
        }
    }

    private void ClearInventoryContainer()
    {
        for (int i = 0; i < ItemsContainer.transform.childCount; i++)
        {
            Destroy(ItemsContainer.transform.GetChild(i).gameObject);
        }
    }

    private void UpdatePlayerResources(int amount, Resource.ResourceType type)
    {
        foreach (Resource resource in Player.AllResources)
        {
            if (resource.Type == type)
            {
                resource.Amount += amount;
            }
        }
    }
}
