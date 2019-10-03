using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public Player Player;
    //public int InventoryLimit = 8;
    public GameObject InventoryItemPrefab;
    public GameObject ItemsContainer;
    public GameObject WearablesContainer;
    private int _invSlotIndex; // ID to know which item is currently selected
    private List<InvSlot> _allInvSlots = new List<InvSlot>();
    //private int _itemIdCount; // ID that indicated each item's place in the Items List
    //private InvSlotContent _selectedInvSlotContent;
    //private int _wearablesIndex;
    //public List<InvSlotContent> InventoryList = new List<InvSlotContent>();
    //private List<GameObject> _allItems = new List<GameObject>();
    //private List<GameObject> _wearables = new List<GameObject>();



    // Comment out before pushing !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            Player.PickUpDrop();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            SelectingInvSlot("Left");
        } else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            SelectingInvSlot("Right");
        }
    }

    private void Awake()
    {
        for (int i = 0; i < ItemsContainer.transform.childCount; i++)
        {
            ItemsContainer.transform.GetChild(i).gameObject.AddComponent<InvSlot>();
            _allInvSlots.Add(ItemsContainer.transform.GetChild(i).gameObject.GetComponent<InvSlot>());
        }
        SelectSlot(_invSlotIndex);
    }

    public void AddItem(InvSlotContent inventorySlotContent)
    {
        /*if (_allInvSlots.Count >= InventoryLimit)
        {
            //TODO: Let player know there is no more space
            Debug.Log("Inventory is full");
            return;
        }*/
        bool isDuplicate = false;
        if (inventorySlotContent.Resource)
        {
            foreach (InvSlot invSlot in _allInvSlots)
            {
                if (invSlot.IsOccupied)
                {
                    if (invSlot.InvSlotContent.ResourceDrop.Type == inventorySlotContent.ResourceDrop.Type)
                    {
                        isDuplicate = true;
                    }
                }
            }
            if (isDuplicate)
            {
                int newAmount = 0;
                foreach (InvSlot invSlot in _allInvSlots)
                {
                    if (invSlot.IsOccupied)
                    {
                        if (invSlot.InvSlotContent.ResourceDrop.Type == inventorySlotContent.ResourceDrop.Type)
                        {
                            newAmount = invSlot.InvSlotContent.Amount + inventorySlotContent.Amount;
                            invSlot.Object.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = newAmount.ToString();
                        }
                    }
                }
            }
            else
            {
                foreach (InvSlot invSlot in _allInvSlots)
                {
                    if (!invSlot.IsOccupied)
                    {
                        invSlot.InvSlotContent = inventorySlotContent;
                        invSlot.Index = _allInvSlots.IndexOf(invSlot);
                        invSlot.IsOccupied = true;
                        GameObject invSlotObject = Instantiate(InventoryItemPrefab, invSlot.gameObject.transform);
                        invSlot.Object = invSlotObject;
                        invSlotObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Icons/" + inventorySlotContent.IconName);
                            invSlotObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = inventorySlotContent.Amount.ToString();
                        return;
                    }
                }
            }
        } else
        {
            foreach (InvSlot invSlot in _allInvSlots)
            {
                if (!invSlot.IsOccupied)
                {
                    invSlot.InvSlotContent = inventorySlotContent;
                    invSlot.Index = _allInvSlots.IndexOf(invSlot);
                    invSlot.IsOccupied = true;
                    GameObject invSlotObject = Instantiate(InventoryItemPrefab, invSlot.gameObject.transform);
                    invSlot.Object = invSlotObject;
                    invSlotObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Icons/" + inventorySlotContent.IconName);
                    invSlotObject.transform.GetChild(1).gameObject.SetActive(false);
                    return;
                }
            }
        }
        
        /*if (inventorySlotContent.Resource)
        {
            bool resourceDuplicate = false;
            //int index = 0; // stores an index of the position of the duplicate in the inventory
            foreach (InvSlotContent invSlotContent in _allInvSlots)
            {
                if (invSlotContent.ResourceDrop != null)
                {
                    if (invSlotContent.ResourceDrop.Type == inventorySlotContent.ResourceDrop.Type)
                    {
                        resourceDuplicate = true;
                        //index = pair.Key;
                    }
                }
            }
            if (!resourceDuplicate)
            {
                _itemIdCount++;
                InventoryList.Add(inventorySlotContent);
                //UpdateInventoryUI();
                //UpdatePlayerResources(inventorySlotContent.Amount, inventorySlotContent.ResourceDrop.Type);
            }
            else
            {
                foreach (InvSlotContent invSlotContent in InventoryList)
                {
                    if (invSlotContent.ResourceDrop != null)
                    {
                        if (invSlotContent.ResourceDrop.Type == inventorySlotContent.ResourceDrop.Type)
                        {
                            invSlotContent.Amount += inventorySlotContent.Amount;
                        }
                    }
                }
                //UpdateInventoryUI();
                //UpdatePlayerResources(inventorySlotContent.Amount, inventorySlotContent.ResourceDrop.Type);
            }
        } else
        {
            _itemIdCount++;
            InventoryList.Add(inventorySlotContent);
            //UpdateInventoryUI();
        }*/
    }

    /*public void RemoveItem(Item item)
    {
        InvSlotContent itemToRemove = null;
        foreach (InvSlotContent invSlotContent in InventoryList)
        {
            if (invSlotContent.Name == item.Name)
            {
                itemToRemove = invSlotContent;
            }
        }
        InventoryList.Remove(itemToRemove);
        _itemIdCount--;
    }*/
    /*private void UpdateInventoryUI()
    {
        foreach (InvSlot obj in _allInvSlots)
        {
            if (!obj.IsOccupied)
            {
                GameObject InventoryItem = Instantiate(InventoryItemPrefab, obj.transform);
                obj.IsOccupied = true;
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
    }*/
    public void DropItem()
    {
       // _allItems.Remove(_selectedInvSlot)
    }
    private void UpdateInventoryUI(int index)
    {
        /*if (InventoryList[index - 1].Value.Resource)
        {
            _allItems[index - 1].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = InventoryList[index - 1].Value.Amount.ToString();
        }*/
    }

    public void SelectingInvSlot(string _direction)
    {
        if (_direction == "Right")
        {
            if (_invSlotIndex >= _allInvSlots.Count - 1)
            {
                _invSlotIndex = -1;
            }
            _invSlotIndex++;
            SelectSlot(_invSlotIndex);
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
        /*if (_allInvSlots.Count > _index)
        {
            if (_allInvSlots[_index] != null)
            {
                _selectedInvSlotContent = InventoryList[_index].Value;
                Debug.Log(_selectedInvSlotContent.IconName);
            }
        }*/
        DeselectAllInvSlots();
        _allInvSlots[_index].transform.GetChild(1).gameObject.SetActive(true);
    }

    private void DeselectAllInvSlots()
    {
        foreach (InvSlot obj in _allInvSlots)
        {
            obj.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    /*private void SelectWearablesSlot(int index)
    {
        DeselectAllInvSlots();
        _wearables[index].transform.GetChild(2).gameObject.SetActive(true);
    }*/

    /*private void UpdatePlayerResources(int amount, Resource.ResourceType type)
    {
        foreach (Resource resource in Player.AllResources)
        {
            if (resource.Type == type)
            {
                resource.Amount += amount;
            }
        }
    }*/
}
