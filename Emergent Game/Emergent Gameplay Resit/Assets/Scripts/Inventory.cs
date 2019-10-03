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
    public GameObject ResourceDropPrefab;
    public GameObject ItemDropPrefab;
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
        if (Input.GetKeyUp(KeyCode.O))
        {
            DropItem();
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
    public void AddItem(InvSlotContent inventorySlotContent, List<KeyValuePair<Resource.ResourceType, int>> list)
    {
        int fullSlotsCount = 0;
        foreach (InvSlot invSlot in _allInvSlots)
        {
            if (invSlot.IsOccupied)
            {
                fullSlotsCount++;
            }
        }
        if (fullSlotsCount >= InventoryLimit)
        {
            //TODO: Let player know there is no more space
            Debug.Log("Inventory is full");
            return;
        }
        foreach (KeyValuePair<Resource.ResourceType, int> pair in list)
        {
            int amountToUpdate = 0;
            foreach (Resource resource in Player.AllResources)
            {
                if (resource.Type == pair.Key)
                {
                    amountToUpdate = resource.Amount - pair.Value;
                }
            }
            UpdatePlayerResources(amountToUpdate, pair.Key);
        }
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
    public void AddItem(InvSlotContent inventorySlotContent)
    {
        int fullSlotsCount = 0;
        foreach (InvSlot invSlot in _allInvSlots)
        {
            if (invSlot.IsOccupied)
            {
                fullSlotsCount++;
            }
        }
        if (fullSlotsCount >= InventoryLimit)
        {
            //TODO: Let player know there is no more space
            Debug.Log("Inventory is full");
            return;
        }
        bool isDuplicate = false;
        if (inventorySlotContent.Resource)
        {
            foreach (InvSlot invSlot in _allInvSlots)
            {
                if (invSlot.IsOccupied && invSlot.InvSlotContent.Resource)
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
                    if (invSlot.IsOccupied && invSlot.InvSlotContent.Resource)
                    {
                        if (invSlot.InvSlotContent.ResourceDrop.Type == inventorySlotContent.ResourceDrop.Type)
                        {
                            newAmount = invSlot.InvSlotContent.Amount + inventorySlotContent.Amount;
                            UpdatePlayerResources(newAmount, invSlot.InvSlotContent.ResourceDrop.Type);
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
                        UpdatePlayerResources(inventorySlotContent.Amount, inventorySlotContent.ResourceDrop.Type);
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
    
    public void DropItem()
    {
        if (_allInvSlots[_invSlotIndex] != null)
        {
            if (_allInvSlots[_invSlotIndex].InvSlotContent.Resource)
            {

                GameObject ResourceDrop = Instantiate(ResourceDropPrefab, Player.transform.position, Quaternion.identity);
                ResourceDrop.GetComponent<ResourceDrop>().Type = _allInvSlots[_invSlotIndex].InvSlotContent.ResourceDrop.Type;
                ResourceDrop.GetComponent<ResourceDrop>().Amount = _allInvSlots[_invSlotIndex].InvSlotContent.Amount;
                ResourceDrop.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Icons/" + _allInvSlots[_invSlotIndex].InvSlotContent.IconName);
            }
            _allInvSlots[_invSlotIndex].ResetInvSlot();
        }
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

    private void UpdatePlayerResources(int amount, Resource.ResourceType type)
    {
        foreach (Resource resource in Player.AllResources)
        {
            if (resource.Type == type)
            {
                resource.Amount = amount;
            }
        }
        UpdatePlayerResourcesUI();
    }

    private void UpdatePlayerResourcesUI()
    {
        foreach (Resource resource in Player.AllResources)
        {
            foreach (InvSlot invSlot in _allInvSlots)
            {
                if (invSlot.IsOccupied && invSlot.InvSlotContent.Resource)
                {
                    if (invSlot.InvSlotContent.ResourceDrop.Type == resource.Type)
                    {
                        invSlot.InvSlotContent.Amount = resource.Amount;
                        invSlot.Object.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = resource.Amount.ToString();
                    }
                }
            }
        }
    }
}
