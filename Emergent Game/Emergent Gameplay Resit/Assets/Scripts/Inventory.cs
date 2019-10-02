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
    private GameObject _selectedInvSlot;
    private int _invSlotIndex; // ID to know which item is currently selected
    private int _wearablesIndex;
    private List<GameObject> _allInvSlots = new List<GameObject>();
    private List<GameObject> _allItems = new List<GameObject>();
    //private List<GameObject> _wearables = new List<GameObject>();


    private void Awake()
    {
        for (int i = 0; i < ItemsContainer.transform.childCount; i++)
        {
            _allInvSlots.Add(ItemsContainer.transform.GetChild(i).gameObject);
        }
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
            int index = 0; // stores an index of the position of the duplicate in the inventory
            foreach (KeyValuePair<int, InventorySlot> pair in InventoryList)
            {
                if (pair.Value.ResourceDrop != null)
                {
                    if (pair.Value.ResourceDrop.Type == inventorySlot.ResourceDrop.Type)
                    {
                        resourceDuplicate = true;
                        index = pair.Key;
                    }
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
                    if (pair.Value.ResourceDrop != null)
                    {
                        if (pair.Value.ResourceDrop.Type == inventorySlot.ResourceDrop.Type)
                        {
                            pair.Value.Amount += inventorySlot.Amount;
                        }
                    }
                }
                UpdateInventoryUI(index);
                UpdatePlayerResources(inventorySlot.Amount, inventorySlot.ResourceDrop.Type);
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
        foreach (GameObject obj in _allInvSlots)
        {
            if (!obj.GetComponent<InvSlotOccupation>().IsOccupied)
            {
                GameObject InventoryItem = Instantiate(InventoryItemPrefab, obj.transform);
                obj.GetComponent<InvSlotOccupation>().IsOccupied = true;
                InventoryItem.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Icons/" + InventoryList[_itemIdCount - 1].Value.IconName);
                InventoryItem.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Icons/" + InventoryList[_itemIdCount - 1].Value.IconName);
                _allItems.Add(InventoryItem);
                if (InventoryList[_itemIdCount - 1].Value.Resource)
                {
                    InventoryItem.transform.GetChild(1).gameObject.SetActive(true);
                    InventoryItem.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = InventoryList[_itemIdCount - 1].Value.Amount.ToString();
                }
                return;
            }
        }
    }
    private void UpdateInventoryUI(int index)
    {
        if (InventoryList[index - 1].Value.Resource)
        {
            _allItems[index - 1].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = InventoryList[index - 1].Value.Amount.ToString();
        }
    }

    public void SelectingInvSlot(string _direction)
    {
        if (_direction == "Right")
        {
            if (_selectedInvSlot == null)
            {
                SelectSlot(0);
            }
            else
            {
                if (_invSlotIndex < _allInvSlots.Count - 1)
                {
                    _invSlotIndex++;
                    SelectSlot(_invSlotIndex);
                } else
                {
                    _invSlotIndex = 0;
                    SelectSlot(_invSlotIndex);
                }
            }
        }
        else if (_direction == "Left")
        {
            if (_invSlotIndex > 0)
            {
                _invSlotIndex--;
                SelectSlot(_invSlotIndex);
            } else
            {
                _invSlotIndex = _allInvSlots.Count - 1;
                SelectSlot(_invSlotIndex);
            }
        }
    }

    private void SelectSlot(int _index)
    {
        //_selectedInvSlot = InventoryList[_index].Value;
        //_allItems[_index].transform.GetChild(2).gameObject.SetActive(true);
        _selectedInvSlot = _allInvSlots[_index];
        DeselectAllInvSlots();
        _allInvSlots[_index].transform.GetChild(1).gameObject.SetActive(true);
    }

    private void DeselectAllInvSlots()
    {
        foreach (GameObject obj in _allInvSlots)
        {
            obj.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    /*private void SelectWearablesSlot(int index)
    {
        DeselectAllInvSlots();
        _wearables[index].transform.GetChild(2).gameObject.SetActive(true);
    }*/

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
