using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public Player Player;
    public int InventoryLimit = 8;
    public GameObject InventoryItemPrefab;
    public GameObject ItemsContainer;
    public GameObject WearablesContainer;
    public List<KeyValuePair<int, InventorySlot>> InventoryList = new List<KeyValuePair<int, InventorySlot>>();
    private int _itemIdCount; // ID that indicated each item's place in the Items List
    private InventorySlot _selectedInvSlot;
    private int _itemIndex; // ID to know which item is currently selected
    private int _wearablesIndex;
    private List<GameObject> _allItems = new List<GameObject>(); // List of all the gameobjects in the inventory
    private List<GameObject> _wearables = new List<GameObject>();


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
            _allItems.Add(InventoryItem);
            if (pair.Value.Resource)
            {
                InventoryItem.transform.GetChild(1).gameObject.SetActive(true);
                InventoryItem.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = pair.Value.Amount.ToString();
            }
        }
        _allItems[_itemIndex].transform.GetChild(2).gameObject.SetActive(true);
    }

    public void SelectingInvSlot(string _direction)
    {
        Debug.Log(_allItems.Count);
        if (_direction == "Right")
        {
            if (_selectedInvSlot == null)
            {
                SelectSlot(0);
            }
            else
            {
                if (_itemIndex < _allItems.Count - 1)
                {
                    _itemIndex++;
                    SelectSlot(_itemIndex);
                } else if (_itemIndex == _allItems.Count -1 && _wearables.Count > 0)
                {
                    SelectWearablesSlot(_wearablesIndex);
                }
            }
        }
        else if (_direction == "Left")
        {
            if (_itemIndex > 0)
            {
                _itemIndex--;
                SelectSlot(_itemIndex);
            }
        }
    }

    private void SelectSlot(int _index)
    {
        if (_allItems.Count == 0)
            return;
        _selectedInvSlot = InventoryList[_index].Value;
        DeselectAllItems();
        _allItems[_index].transform.GetChild(2).gameObject.SetActive(true);
    }

    private void DeselectAllItems()
    {
        foreach (GameObject obj in _allItems)
        {
            obj.transform.GetChild(2).gameObject.SetActive(false);
        }
    }
    private void SelectWearablesSlot(int index)
    {
        DeselectAllItems();
        _wearables[index].transform.GetChild(2).gameObject.SetActive(true);
    }
    private void ClearInventoryContainer()
    {
        for (int i = 0; i < ItemsContainer.transform.childCount; i++)
        {
            Destroy(ItemsContainer.transform.GetChild(i).gameObject);
            _allItems.Clear();
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
