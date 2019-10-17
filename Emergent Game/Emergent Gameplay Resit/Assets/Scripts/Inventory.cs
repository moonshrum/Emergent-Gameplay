using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public Player Player;
    public int InventoryLimit = 8;
    public GameObject ItemsContainer;
    public GameObject HandEqSlot;
    public GameObject BodyEqSlot;
    [Header("Prefabs")]
    public GameObject InventoryItemPrefab;
    public GameObject ResourceDropPrefab;
    public GameObject ItemDropPrefab;
    public GameObject TrapPreshowPrefab;
    public GameObject TrapPrefab;
    private int _invSlotIndex; // ID to know which item is currently selected
    private List<InvSlot> _allInvSlots = new List<InvSlot>();
    private InvSlot _selectedInvSlot;
    private InvSlot _handEquipment;
    private InvSlot _bodyEquipment;
    private GameObject TrapPreshow;
    [System.NonSerialized]
    public bool IsPreshowingTrap = false;
    //private int _itemIdCount; // ID that indicated each item's place in the Items List
    //private InvSlotContent _selectedInvSlotContent;
    //private int _wearablesIndex;
    //public List<InvSlotContent> InventoryList = new List<InvSlotContent>();
    //private List<GameObject> _allItems = new List<GameObject>();
    //private List<GameObject> _wearables = new List<GameObject>();



    /*// Comment out before pushing !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            Player.Instance.OnCollect();
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
    }*/

    private void Awake()
    {
        for (int i = 0; i < ItemsContainer.transform.childCount; i++)
        {
            ItemsContainer.transform.GetChild(i).gameObject.AddComponent<InvSlot>();
            _allInvSlots.Add(ItemsContainer.transform.GetChild(i).gameObject.GetComponent<InvSlot>());
        }
        _handEquipment = _allInvSlots[_allInvSlots.Count - 2];
        _bodyEquipment = _allInvSlots[_allInvSlots.Count - 1];
        SelectSlot();
    }
    public void AddItem(InvSlotContent inventorySlotContent, List<KeyValuePair<Resource.ResourceType, int>> list)
    {
        foreach (KeyValuePair<Resource.ResourceType, int> pair in list)
        {
            /*int amountToUpdate = 0;
            foreach (Resource resource in Player.AllResources)
            {
                if (resource.Type == pair.Key)
                {
                    amountToUpdate = resource.Amount - pair.Value;
                }
            }*/
            UpdatePlayerResources(-pair.Value, pair.Key);
        }
        foreach (InvSlot invSlot in _allInvSlots)
        {
            if (!invSlot.IsOccupied)
            {
                invSlot.InvSlotContent = inventorySlotContent;
                invSlot.IsOccupied = true;
                GameObject invSlotObject = Instantiate(InventoryItemPrefab, invSlot.gameObject.transform);
                invSlot.Object = invSlotObject;
                invSlotObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Icons/" + inventorySlotContent.IconName);
                invSlotObject.transform.GetChild(1).gameObject.SetActive(false);
                return;
            }
        }
    }
    public bool IsInventoryFull()
    {
        int fullSlotsCount = 0;
        foreach (InvSlot invSlot in _allInvSlots)
        {
            if (invSlot.IsOccupied && invSlot != _handEquipment && invSlot != _bodyEquipment)
            {
                fullSlotsCount++;
            }
        }
        if (fullSlotsCount >= InventoryLimit)
        {
            //TODO: Let player know there is no more space
            Debug.Log("Inventory is full");
            return true;
        } else
        {
            return false;
        }
    }
    public void AddItem(InvSlotContent inventorySlotContent)
    {
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
                            //newAmount = invSlot.InvSlotContent.Amount + inventorySlotContent.Amount;
                            UpdatePlayerResources(inventorySlotContent.Amount, invSlot.InvSlotContent.ResourceDrop.Type);
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
    
    public void DropItem()
    {
        if (_selectedInvSlot != null)
        {
            if (_selectedInvSlot.InvSlotContent.Resource)
            {
                GameObject ResourceDrop = Instantiate(ResourceDropPrefab, Player.transform.position, Quaternion.identity);
                ResourceDrop.GetComponent<ResourceDrop>().Type = _selectedInvSlot.InvSlotContent.ResourceDrop.Type;
                ResourceDrop.GetComponent<ResourceDrop>().Amount = _selectedInvSlot.InvSlotContent.Amount;
                ResourceDrop.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Icons/" + _selectedInvSlot.InvSlotContent.IconName);
            } else if (_selectedInvSlot.InvSlotContent.IsItem)
            {
                GameObject itemDrop = Instantiate(ItemDropPrefab, Player.transform.position, Quaternion.identity);
                itemDrop.GetComponent<ItemDrop>().Type = _selectedInvSlot.InvSlotContent.Item.Type;
                itemDrop.GetComponent<ItemDrop>().Item = _selectedInvSlot.InvSlotContent.Item;
                itemDrop.GetComponent<ItemDrop>().Name = _selectedInvSlot.InvSlotContent.Name;
                itemDrop.GetComponent<ItemDrop>().IconName = _selectedInvSlot.InvSlotContent.IconName;
                itemDrop.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Icons/" + _selectedInvSlot.InvSlotContent.IconName);
            }
            _selectedInvSlot.ResetInvSlot();
        }
    }
    public void ItemAction(Vector2 vector)
    {
        if (vector.x == -1)
        {
            DropItem();
        }
        if (vector.x == 1)
        {
            if (_selectedInvSlot.IsOccupied) 
            {
                if (_selectedInvSlot.InvSlotContent.Item != null)
                {
                    if (_selectedInvSlot.InvSlotContent.Item.Type == Item.ItemType.Weapon || _selectedInvSlot.InvSlotContent.Item.Type == Item.ItemType.Armor)
                    {
                        if (_selectedInvSlot == _handEquipment)
                        {
                            UnEquipHand();
                        }
                        else if (_selectedInvSlot == _bodyEquipment)
                        {
                            UnEquipBody();
                        }
                        else
                        {
                            EquipItem();
                        }
                    } else if (_selectedInvSlot.InvSlotContent.Item.Type == Item.ItemType.Trap)
                    {
                        PreShowTrap();
                    }
                }
            }
        }
    }
    private void PreShowTrap()
    {
        IsPreshowingTrap = true;
        TrapPreshow = Instantiate(TrapPreshowPrefab, Player.HandPosition);
        TrapPreshow.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + _selectedInvSlot.InvSlotContent.SpriteName);
    }
    public void CancelTrapPreshow()
    {
        IsPreshowingTrap = false;
        Destroy(TrapPreshow);
    }
    public void PlaceTrap()
    {
        IsPreshowingTrap = false;
        GameObject Trap = Instantiate(TrapPrefab, TrapPreshow.transform.position, Quaternion.identity);
        Trap.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + _selectedInvSlot.InvSlotContent.SpriteName);
        Destroy(TrapPreshow);
        _selectedInvSlot.ResetInvSlot();
    }
    private void EquipItem()
    {
        if (_selectedInvSlot.InvSlotContent.Item.Type == Item.ItemType.Weapon)
        {
            if (_handEquipment.IsOccupied)
            {
                SwapItems(_handEquipment, "Hand");
            } else
            {
                AssigHandEquipment();
            }
        }
        else if (_selectedInvSlot.InvSlotContent.Item.Type == Item.ItemType.Armor)
        {
            if (_bodyEquipment.IsOccupied)
            {
                SwapItems(_bodyEquipment, "Body");
            } else
            {
                AssignBodyEquipment();
            }
        }
    }

    private void AssigHandEquipment()
    {
        _handEquipment.InvSlotContent = _selectedInvSlot.InvSlotContent;
        _selectedInvSlot.ResetInvSlot();
        _handEquipment.IsOccupied = true;
        GameObject handEquipmentObj = Instantiate(InventoryItemPrefab, HandEqSlot.transform);
        _handEquipment.Object = handEquipmentObj;
        handEquipmentObj.transform.GetChild(1).gameObject.SetActive(false);
        handEquipmentObj.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Icons/" + _handEquipment.InvSlotContent.IconName);
    }
    private void AssignBodyEquipment()
    {
        _bodyEquipment.InvSlotContent = _selectedInvSlot.InvSlotContent;
        _selectedInvSlot.ResetInvSlot();
        _bodyEquipment.IsOccupied = true;
        GameObject bodyEquipmentObj = Instantiate(InventoryItemPrefab, BodyEqSlot.transform);
        _bodyEquipment.Object = bodyEquipmentObj;
        bodyEquipmentObj.transform.GetChild(1).gameObject.SetActive(false);
        bodyEquipmentObj.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Icons/" + _bodyEquipment.InvSlotContent.IconName);
    }
    private void SwapItems(InvSlot invSlot, string bodyPart)
    {
        InvSlotContent tempInvSlotContent = invSlot.InvSlotContent;
        invSlot.ResetInvSlot();
        if (bodyPart == "Body")
        {
            AssignBodyEquipment();
        } else if (bodyPart == "Hand")
        {
            AssigHandEquipment();
        }
        AddItem(tempInvSlotContent);
    }
    private void UnEquipHand()
    {
        if (IsInventoryFull())
        {
            DropItem();
        } else
        {
            AddItem(_handEquipment.InvSlotContent);
            _handEquipment.ResetInvSlot();
        }
    }
    private void UnEquipBody()
    {
        if (IsInventoryFull())
        {
            DropItem();
        } else
        {
            AddItem(_bodyEquipment.InvSlotContent);
            _bodyEquipment.ResetInvSlot();
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
            SelectSlot();
        }
        else if (_direction == "Left")
        {
            if (_invSlotIndex > 0)
            {
                _invSlotIndex--;
                SelectSlot();
            } else
            {
                _invSlotIndex = _allInvSlots.Count - 1;
                SelectSlot();
            }
        }
    }

    private void SelectSlot()
    {
        DeselectAllInvSlots();
        _selectedInvSlot = _allInvSlots[_invSlotIndex];
        _selectedInvSlot.transform.GetChild(1).gameObject.SetActive(true);
    }

    private void DeselectAllInvSlots()
    {
        foreach (InvSlot obj in _allInvSlots)
        {
            obj.transform.GetChild(1).gameObject.SetActive(false);
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
        ChallengesManager.Instance.IncreaseChallengeResource(type, amount, Player);
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
