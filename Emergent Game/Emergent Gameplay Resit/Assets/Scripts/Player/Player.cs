using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Player: MonoBehaviour
{
    public int Health = 100;
    public int AttackeValue = 10;
    public int Defense = 10;
    public float MovementSpeed = 10;
    public bool IsShopOpen = false;
    public bool IsInvToggled = false;
    public bool isAttacking = false;
    public bool isDefending = false;
    public float CurrentStunTime;

    [Header("Adjustable Variables")]
    public float UITogglingSensitivity;
    public float UITogglingDelay;

    [Header("Does not need reference")]
    public ResourceMine NearbyResourceMine;
    public ResourceDrop NearbyResourceDrop;
    public Campfire NearbyCampfire;
    public ItemDrop NearbyItemDrop;
    public int UnlockedBlueprints;

    [Header("Needs reference")]
    //public Transform CharacterTransform;
    //public Transform HandPosition;
    public GameObject Shop;
    public GameObject Inventory;
    public GameObject ResourceDropPrefab;
    //public Animator Anim;
    public Slider HealthBar;
    public List<Image> Blueprints = new List<Image>();
    public Animator AtkRef;
    public Animator DefRef;
    [Header("Reference to characters prefabs")]
    public GameObject Character1;
    public GameObject Character2;

    public static Player Instance;
    PlayerInputs input;
    private Shop _shop;
    private Inventory _inventory;
    private Transform _characterTransform; //The transform of the character object to which movement should be applied
    [System.NonSerialized]
    public Transform HandPosition; //The transorm of the hand position of the character
    [System.NonSerialized]
    public GameObject ChallengesAnnouncement;
    [System.NonSerialized]
    public GameObject ChallengesInTheShop;
    [System.NonSerialized]
    public GameObject RoundAnnouncement;
    [System.NonSerialized]
    public GameObject BlueprintsContainer;
    [System.NonSerialized]
    public Transform BlueprintsToActivateContainer;
    [System.NonSerialized]
    public List<Resource> AllResources = new List<Resource>();
    [System.NonSerialized]
    public List<Item> AllItems = new List<Item>();
    [System.NonSerialized]
    public List<Challenge> PlayerChallenges = new List<Challenge>();
    private Animator _anim; 
    private Rigidbody2D rb;
    [System.NonSerialized]
    public List<Collider2D> AllColliders = new List<Collider2D>();
    private Vector2 mv;
    private Vector2 _cs; // Variable that stores the value of the left stick during category selection in the shop
    private Vector2 _is; // Variable that store the value of the left stick during item selection in the shop
    //private Vector2 rv;
    private Vector2 _iss; // Variable that store the value of the right stick during inventory slot selection in the inventory
    //private Vector2 rv;
    private Vector2 _ia; // Variable that stores the value of the left dpad; used for determining which action should be applied to the item
    private float _categorySwitchingTimer;
    private float _itemSwitchingTimer;
    private float _invSlotSwitchingTimer;
    private bool _facingRight = true;
    private Vector2 s;
    public int PlayerNumber = 0;
    public bool InBase;
    private bool _nearWaterSource; // TODO: add a check if the player is near water and change this variable accordingly
    float dashTime = 0.3f;
    bool isDodging = false;

    private void Awake()
    {
        Instance = this;
        //GeneratePlayerResources();
        rb = GetComponent<Rigidbody2D>();
        input = new PlayerInputs();
    }

    private void Start()
    {
        _shop = Shop.GetComponent<Shop>();
        _inventory = Inventory.GetComponent<Inventory>();
        AssignPlayerVariables();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.H)) {
            PickUp();
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            BuyItem();
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            ToggleShop();
        }



        HealthBar.value = Health; // Can this be moved from update?

        if (!IsShopOpen)
        {
            PlayerMovement();
            InvSlotSelectionControls();
        }
        else
        {
            CategorySelectionControls();
            ItemSelectionControls();
        }

        if (isDodging)
        {
            dashTime -= Time.deltaTime;            

            if (dashTime <= 0)
            {
                dashTime = 0.3f;
                //MovementSpeed /= 5f;
                isDodging = false;
            }
        }        
        //Debug.Log(_categorySwitchingTimer);
    }
    private void AssignPlayerVariables()
    {
        if (transform == PlayerInput.GetPlayerByIndex(0).transform)
        {
            Character1.SetActive(true);
            _characterTransform = Character1.transform;
            PlayerNumber = 1;
            //_anim = Character1.GetComponent<Animator>();
        }
        else if (PlayerInput.GetPlayerByIndex(1).transform == transform)
        {
            Character1.SetActive(false);
            Character2.SetActive(true);
            _characterTransform = Character2.transform;
            PlayerNumber = 2;
            //_anim = Character2.GetComponent<Animator>();
        }
        _anim = _characterTransform.GetComponent<Animator>();
        GameManager.Instance.AllPlayers.Add(this);
        HandPosition = _characterTransform.Find("Hand Position");
        Transform canvas = transform.Find("Canvas");
        ChallengesAnnouncement = canvas.Find("Challenges Announcement").gameObject;
        ChallengesInTheShop = Shop.transform.Find("Challenges").gameObject;
        RoundAnnouncement = canvas.Find("Round Announcement").gameObject;
        BlueprintsContainer = canvas.Find("Boat Blueprints").gameObject;
        BlueprintsToActivateContainer = BlueprintsContainer.transform.Find("Boat Pieces");
    }
    private void OnLeftStick(InputValue value)
    {
        if (!IsShopOpen)
        {
            mv = value.Get<Vector2>();
        }
        else
        {
            _cs = value.Get<Vector2>();
            _is = value.Get<Vector2>();
        }
        if (_is == Vector2.zero)
        {
            _itemSwitchingTimer = 0f;
        }
        if (_cs == Vector2.zero)
        {
            _categorySwitchingTimer = 0f;
            //_itemSwitchingTimer = 0f;
        }
    }
    public void OnA()
    {
        if (IsShopOpen)
        {
            BuyItem();
        }
        else
        {
            PickUp();
        }
    }
    public void OnB()
    {
        Attack();
    }
    // TODO: Show player what button can be pressed
    public void OnX()
    {
        if (CanSetOnFire())
        {
            SetOnFire();
            return;
        }
        else if (CanInteractWithMine())
        {
            InteractWithMine(NearbyResourceMine);
            return;
        }
        else if (CanFillUpBucket())
        {
            FillUpBucket();
            return;
        }
        else if (CanExtinguish())
        {
            Extinguish();
            return;
        }
        else if (CanPlaceItemOnMap())
        {
            PlaceItemOnMap();
            return;
        }
    }
    public void OnLT()
    {
        Dodge();
    }
    public void OnRB()
    {
        ToggleShop();
    }
    public void OnRT()
    {
        Guard();
    }
    public void OnInvItemInteraction(InputValue value)
    {
        _ia = value.Get<Vector2>().normalized;
        _inventory.ItemAction(_ia);
    }
    private void OnInventorySlotSelection(InputValue value)
    {
        _iss = value.Get<Vector2>();
        if (_iss == Vector2.zero)
        {
            _invSlotSwitchingTimer = 0f;
        }
    }
    public void PickUp()
    {
        //SFX: loot sound
        foreach (Collider2D col in AllColliders)
        {
            if (col.transform.tag == "Resource Drop")
            {
                NearbyResourceDrop = col.GetComponent<ResourceDrop>();
                break;
            }
            else if (col.transform.tag == "Item Drop")
            {
                NearbyItemDrop = col.GetComponent<ItemDrop>();
                break;
            }
        }
        //add check whether mine or resources are present
        if (NearbyResourceDrop != null)
        {
            if (!_inventory.IsInventoryFull())
            {
                InvSlotContent inventorySlotContent = new InvSlotContent(NearbyResourceDrop, NearbyResourceDrop.Amount);
                Inventory.GetComponent<Inventory>().AddItem(inventorySlotContent);
                Destroy(NearbyResourceDrop.gameObject);
            }
        }
        else if (NearbyItemDrop != null)
        {
            InvSlotContent inventorySlotContent = new InvSlotContent(NearbyItemDrop.Item);
            if (!_inventory.IsInventoryFull())
            {
                Inventory.GetComponent<Inventory>().AddItem(inventorySlotContent);
                Destroy(NearbyItemDrop.gameObject);
            }
        }
    }
    private bool CanSetOnFire()
    {
        // Checking if the player has a fire source equiped. If not then exits the function
        if (_inventory.HandEquipment.IsOccupied && _inventory.HandEquipment.InvSlotContent.Item.Type == Item.ItemType.Torch)
            return true;

        return false;
    }
    // Check whether the nearby object can be set on fire
    private void SetOnFire()
    {
        // TODO: Select the closest object to the player
        foreach (Collider2D col in AllColliders)
        {
            if (col.transform.tag == "Resource Mine")
            {
                NearbyResourceMine = col.GetComponent<ResourceMine>();
                break;
            }
            else if (col.transform.tag == "Resource Drop")
            {
                NearbyResourceDrop = col.GetComponent<ResourceDrop>();
                break;
            } else if (col.transform.tag == "Campfire")
            {
                NearbyCampfire = col.GetComponent<Campfire>();
                break;
            }
        }
        if (NearbyResourceMine != null && NearbyResourceMine.CanBeSetOnFire)
        {
            //SFX: fire
            ActivateFirePrefab(NearbyResourceMine.gameObject);
            NearbyResourceMine.IsOnFire = true;
        }
        else if (NearbyResourceDrop != null && NearbyResourceDrop.CanBeSetOnFire)
        {
            //SFX: fire
            ActivateFirePrefab(NearbyResourceDrop.gameObject);
            NearbyResourceDrop.IsOnFire = true;
        }
        else if (NearbyCampfire != null && NearbyCampfire)
        {
            //SFX: fire
            ActivateFirePrefab(NearbyCampfire.gameObject);
            NearbyCampfire.IsOnFire = true;
        }
    }
    private void ActivateFirePrefab(GameObject obj)
    {
        GameObject objToSetOnFire = obj.transform.Find("Fire Prefab").gameObject;
        if (objToSetOnFire != null)
        {
            objToSetOnFire.SetActive(true);
            objToSetOnFire.transform.parent.gameObject.AddComponent<ObjectOnFire>();
        }
    }
    private bool CanInteractWithMine()
    {
        // TODO: Select the closest object to the player
        foreach (Collider2D col in AllColliders)
        {
            if (col.transform.tag == "Resource Mine")
            {
                NearbyResourceMine = col.GetComponent<ResourceMine>();
                break;
            }
        }
        if (NearbyResourceMine != null && NearbyResourceMine.CanBeCollected && _inventory.HandEquipment.InvSlotContent.Item.Type == NearbyResourceMine.NeededItem)
        {
            return true;
        }
        return false;
    }
    private void InteractWithMine(ResourceMine mine)
    {
        //SFX: pickaxe swing
        int randomAmountOfDrop = Random.Range(1, 4);
        for (int i = 0; i < randomAmountOfDrop; i++)
        {
            int randomNumber = Random.Range(-1, 2);
            Vector3 positionToSpawn = new Vector3(mine.transform.position.x + randomNumber, mine.transform.position.y + randomNumber, mine.transform.position.z);
            ResourceDrop ResourceDrop = Instantiate(ResourceDropPrefab, positionToSpawn, Quaternion.identity).GetComponent<ResourceDrop>();

            ResourceDrop.Type = mine.Type;
            ResourceDrop.Amount = ResourceDrop.DefaultAmount;
            if (ResourceDrop.Type == Resource.ResourceType.Wood)
            {
                ResourceDrop.CanBeSetOnFire = true;
            }
            ResourceDrop.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + mine.Type.ToString());
        }
        if (mine.WillBeDestroyed)
        {
            Destroy(mine.gameObject);
        }
        else if (mine.WillChangeSprite)
        {
            mine.GetComponent<SpriteRenderer>().sprite = mine.SpriteToChangeTo;
            mine.CanBeCollected = false;
        }

    }
    private bool CanFillUpBucket()
    {
        // Checking if the player is near water source and if player has Empty Bucket equiped
        if (_inventory.HandEquipment.IsOccupied && _inventory.HandEquipment.InvSlotContent.Item.Type == Item.ItemType.EmptyBucket && _nearWaterSource)
            return true;
        return false;
    }
    private void FillUpBucket()
    {
        //SFX: water fill sound
        _inventory.FillUpBucket();
    }
    private bool CanExtinguish()
    {
        // Checking if the player has Full Bucket Equiped
        if (_inventory.HandEquipment.IsOccupied && _inventory.HandEquipment.InvSlotContent.Item.Type == Item.ItemType.FullBucket)
        {
            // TODO: Select the closest object to the player
            foreach (Collider2D col in AllColliders)
            {
                if (col.transform.tag == "Resource Mine")
                {
                    NearbyResourceMine = col.GetComponent<ResourceMine>();
                    if (NearbyResourceMine.IsOnFire)
                    {
                        return true;
                    }
                }
                else if (col.transform.tag == "Resource Drop")
                {
                    NearbyResourceDrop = col.GetComponent<ResourceDrop>();
                    if (NearbyResourceDrop.IsOnFire)
                    {
                        return true;
                    }
                }
                else if (col.transform.tag == "Campfire")
                {
                    NearbyCampfire = col.GetComponent<Campfire>();
                    if (NearbyCampfire.IsOnFire)
                    {
                        return true;
                    }
                }
            }
            /*if (NearbyResourceMine != null && NearbyResourceMine.IsOnFire)
            {
                return true;
            }
            else if (NearbyResourceDrop != null && NearbyResourceDrop.IsOnFire)
            {
                return true;
            }
            else if (NearbyCampfire != null && NearbyResourceDrop.IsOnFire)
            {
                return true;
            }*/
        }
        return false;
    }
    private void Extinguish()
    {
        //SFX: extinguish sound
        if (NearbyResourceMine != null && NearbyResourceMine.IsOnFire)
        {
            DisableFirePrefab(NearbyResourceMine.gameObject);
            NearbyResourceMine.IsOnFire = false;
        }
        else if (NearbyResourceDrop != null && NearbyResourceDrop.IsOnFire)
        {
            DisableFirePrefab(NearbyResourceDrop.gameObject);
            NearbyResourceDrop.IsOnFire = false;
        }
        else if (NearbyCampfire != null && NearbyCampfire.IsOnFire)
        {
            DisableFirePrefab(NearbyCampfire.gameObject);
            NearbyCampfire.IsOnFire = false;
        }
    }
    private void DisableFirePrefab(GameObject obj)
    {
        GameObject objToExtinguish = obj.transform.Find("Fire Prefab").gameObject;
        if (objToExtinguish != null && objToExtinguish.activeSelf)
        {
            objToExtinguish.SetActive(false);
            /*if (
            objToExtinguish.transform.parent.gameObject.GetComponent<ObjectOnFire>() != null)
            {
                objToExtinguish.transform.parent.gameObject.GetComponent<ObjectOnFire>().enabled = false;
            }*/
        }
    }
    private bool CanPlaceItemOnMap()
    {
        if (_inventory.IsPreshowingItemOnMap)
        {
            return true;
        }
        return false;
    }
    private void PlaceItemOnMap()
    {
        //SFX: Place Trap/Place Item
        _inventory.PlaceItemOnMap();
    }
    public void TakeDamage(int damage)
    {
        if (isDodging) return;
        Health -= damage;

        if (Health <= 0)
        {
            //SFX: Death Sound
            // TODO: Play death animation
            // TODO: Open game over screen
            Destroy(gameObject);
        }
        else
        {
            //SFX: Hurt Sound
        }
    }
    public void Stun(float stunValue)
    {
        CurrentStunTime = stunValue;
        _anim.SetBool("isStunned", true);
    }
    private void PlayerMovement()
    {
        Vector2 m = new Vector2(mv.x, mv.y) * MovementSpeed * Time.deltaTime;
        if (!isDodging)
        {
            transform.Translate(m, Space.World);
            _anim.SetBool("isMoving", m != Vector2.zero);
        }           
        else
        {
            transform.Translate(s * Time.deltaTime, Space.World);
            _anim.SetBool("isMoving", false);
        }
            

        /*Vector2 r = new Vector2(-rv.x, -rv.y) * 100f * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, r.x), Space.World);*/

        if (m.x < 0 && _facingRight)
        {
            FlipCharacter("Left");
        } else if (m.x > 0 && !_facingRight)
        {
            FlipCharacter("Right");
        }
        

        if (m != Vector2.zero)
        {
            //SFX: Footsteps
        }
    }
    private void FlipCharacter(string side)
    {
        if (side == "Left")
        {
            _facingRight = false;
            _characterTransform.localScale = new Vector3(-_characterTransform.localScale.x, _characterTransform.localScale.y, _characterTransform.localScale.z);
        } else if (side == "Right")
        {
            _facingRight = true;
            _characterTransform.localScale = new Vector3(Mathf.Abs(_characterTransform.localScale.x), _characterTransform.localScale.y, _characterTransform.localScale.z);
        }
    }
    private void CategorySelectionControls()
    {
        string _direction = string.Empty;
        if (_cs != Vector2.zero)
        {
            if (_cs.y > UITogglingSensitivity)
            {
                _direction = "Up";
            }
            else if (_cs.y < -UITogglingSensitivity)
            {
                _direction = "Down";
            }
        }
        if (_direction != string.Empty)
        {
            if (_categorySwitchingTimer == 0f)
            {
                Shop.GetComponent<Shop>().SelectingShopCategory(_direction);
            }
            _categorySwitchingTimer += Time.deltaTime;
            if (_categorySwitchingTimer > UITogglingDelay)
            {
                _categorySwitchingTimer = 0f;
            }
        }
    }
    private void ItemSelectionControls()
    {
        string _direction = string.Empty;
        if (_is != Vector2.zero)
        {
            if (_is.x > UITogglingSensitivity)
            {
                _direction = "Right";
            }
            else if (_is.x < -UITogglingSensitivity)
            {
                _direction = "Left";
            }
        }
        if (_direction != string.Empty)
        {
            if (_itemSwitchingTimer == 0f)
            {
                _shop.SelectingShopItem(_direction);
            }
            _itemSwitchingTimer += Time.deltaTime;
            if (_itemSwitchingTimer > UITogglingDelay)
            {
                _itemSwitchingTimer = 0f;
            }
        }
    }
    private void InvSlotSelectionControls()
    {
        string _direction = string.Empty;
        if (_iss != Vector2.zero)
        {
            if (_iss.x > 0)
            {
                _direction = "Right";
            }
            else if (_iss.x < 0)
            {
                _direction = "Left";
            }
        }
        if (_direction != string.Empty)
        {
            if (_invSlotSwitchingTimer == 0f)
            {
                _inventory.SelectingInvSlot(_direction);
            }
            _invSlotSwitchingTimer += Time.deltaTime;
            if (_invSlotSwitchingTimer > UITogglingDelay)
            {
                _invSlotSwitchingTimer = 0f;
            }
        }
    }
    /*private void OnItemSelection(InputValue value)
    {
        _is = value.Get<Vector2>();
        if (_is == Vector2.zero)
        {
            _itemSwitchingTimer = 0f;
        }
    }*/
    // Function responsible for item actions in the inventory
    private void ToggleShop()
    {
        if (!InBase) return;
        //SFX: open menu
        Shop.SetActive(!Shop.activeSelf);
        IsShopOpen = !IsShopOpen;
    }
    private void Attack()
    {
        if (!isDefending)
        {
            //SFX: attack sound
            AtkRef.SetTrigger("Attack");
            isAttacking = true;
        }        
    }
    private void Guard()
    {
        if (!isAttacking)
        {
            //SFX: block sound
            DefRef.SetTrigger("Defend");
            isDefending = true;
        }          
    }
    private void Dodge()
    {
        if (!isAttacking && !isDefending && !isDodging)
        {
            //SFX: dodge sound
            s = new Vector2(mv.x, mv.y) * MovementSpeed * 3f;
            isDodging = true;
            _anim.SetTrigger("isDodge");
            //need to add dodge animation           
        }
    }
    private void BuyItem()
    {
        //SFX: cha-ching
        if (IsShopOpen)
            _shop.CraftItem(_shop.SelectedItem, Instance);
    }
    /*private void OnPlaceTrap()
    {
        if (_inventory.IsPreshowingItemOnMap)
        {
            _inventory.PlaceTrap();
        }
    }*/
    /*private void OnCancelTrapPlacing()
    {
        if (_inventory.IsPreshowingItemOnMap)
        {
            _inventory.CancelItemOnMapPreshow();
        }
    }*/
    private void OnEnable()
    {
        input.Player.Enable();
    }
    private void OnDisable()
    {
        input.Player.Disable();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!AllColliders.Contains(col))
        {
            AllColliders.Add(col);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (AllColliders.Contains(col))
        {
            AllColliders.Remove(col);
        }
        if (col.GetComponent<ResourceMine>() != null)
        {
            if (NearbyResourceMine == col.GetComponent<ResourceMine>())
            {
                NearbyResourceMine = null;
            }
        }
        else if (col.GetComponent<ResourceDrop>() != null)
        {
            if (NearbyResourceDrop == col.GetComponent<ResourceDrop>())
            {
                NearbyResourceDrop = null;
            }
        }
        else if (col.GetComponent<ItemDrop>() != null)
        {
            if (NearbyItemDrop == col.GetComponent<ItemDrop>())
            {
                NearbyItemDrop = null;
            }
        }
        else if (col.GetComponent<Campfire>() != null)
        {
            if (NearbyCampfire == col.GetComponent<Campfire>())
            {
                NearbyCampfire = null;
            }
        }
    }
}
