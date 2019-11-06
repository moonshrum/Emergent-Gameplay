using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    public static readonly int MaxHealth = 100;
    public int Health = 100;
    public static readonly int BasicDamageValue = 1;
    public int DamageValue = 1;
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
    public int PoisonousFoodDamage;
    public int HealthyFoodHealAmount;

    [Header("Does not need reference")]
    public GameObject ClosestObject;
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
    public TextMeshProUGUI ShopBlueprintsText;
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
    [System.NonSerialized]
    public Transform _characterTransform; //The transform of the character object to which movement should be applied
    [System.NonSerialized]
    public Transform HandPosition; //The transorm of the hand position of the character
    [System.NonSerialized]
    public Transform WeaponToolPosition; //The transorm of the moving hand position of the character
    [System.NonSerialized]
    public Transform ShieldInHandPosition; //The transorm of the moving hand position of the character
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
    [Space(25f)]
    public List<Resource> AllResources = new List<Resource>();
    [System.NonSerialized]
    public List<Item> AllItems = new List<Item>();
    [System.NonSerialized]
    public List<Challenge> PlayerChallenges = new List<Challenge>();
    [System.NonSerialized]
    public Animator _anim;
    private Rigidbody2D rb;
    [System.NonSerialized]
    public List<GameObject> AllInstructionsObjectsColliders = new List<GameObject>();
    private Vector2 mv;
    private Vector2 _cs; // Variable that stores the value of the left stick during category selection in the shop
    private Vector2 _is; // Variable that store the value of the left stick during item selection in the shop
    //private Vector2 rv;
    private Vector2 _iss; // Variable that store the value of the right stick during inventory slot selection in the inventory
    private Vector2 _ia; // Variable that stores the value of the left dpad; used for determining which action should be applied to the item
    private Vector2 s; // Varible that stores the value for dodging
    private float _categorySwitchingTimer;
    private float _itemSwitchingTimer;
    private float _invSlotSwitchingTimer;
    private float _invTogglingTimer; // Keep tracks of how the hasn't been using inventory
    [SerializeField]
    private List<GameObject> _instructionsToggled = new List<GameObject>();
    private bool _facingRight = true;
    public int PlayerNumber = 0;
    public bool InBase;
    private bool _canDodge = true;
    private bool _nearWaterSource; // TODO: add a check if the player is near water and change this variable accordingly
    private bool _firstInstruction = true; // Bolean that help to keep track of objects that to have the intsruction image toggled. It is used to know whether the _instructionsShown is not null, which cannot be done with != null in this specific case
    private GameObject _instructionsShown;
    public float _timeSinceDodge;
    float dashTime = 0.3f;
    bool canTakeDamage = true;

    [System.NonSerialized]
    public bool isDodging = false;

    [SerializeField]
    private Transform _startPos1;
    [SerializeField]
    private Transform _startPos2;

    public Text P1ReadyText;
    public Text P2ReadyText;
    public Text P1NotReadyText;
    public Text P2NotReadyText;
    public GameObject MenuCharacter1;
    public GameObject MenuCharacter2;

    [System.NonSerialized] public bool ControlsDisabled = true;

    public readonly static HashSet<Player> PlayerPool = new HashSet<Player>();

    private void Awake()
    {
        Instance = this;
        //GeneratePlayerResources();
        rb = GetComponent<Rigidbody2D>();
        input = new PlayerInputs();
        P1NotReadyText.enabled = true;
        P2NotReadyText.enabled = true;
        P1ReadyText.enabled = false;
        P2ReadyText.enabled = false;
    }

    private void Start()
    {
        _shop = Shop.GetComponent<Shop>();
        _inventory = Inventory.GetComponent<Inventory>();
        AssignPlayerVariables();
    }
    void Update()
    {
        ShowInstructions();
        if (Input.GetKeyUp(KeyCode.H))
        {
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



        // Can this be moved from update?

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
                _timeSinceDodge = 0;
            }
        }
        if (!isDodging)
        {
            _timeSinceDodge += Time.deltaTime;
            if (_timeSinceDodge >= 5)
            {

            }
        }
        //Debug.Log(_categorySwitchingTimer);
        ShowInstructions();
    }
    private void AssignPlayerVariables()
    {
        if (transform == PlayerInput.GetPlayerByIndex(0).transform)
        {
            Character1.SetActive(false);
            MenuCharacter1.SetActive(true);
            MenuCharacter2.SetActive(false);
            _characterTransform = Character1.transform;
            P1NotReadyText.enabled = false;
            P1ReadyText.enabled = true;
            GameManager.Instance.playersReady++;
            PlayerNumber = 1;
            _anim = Character1.GetComponent<Animator>();
        }
        else if (PlayerInput.GetPlayerByIndex(1).transform == transform)
        {
            Character2.SetActive(false);
            MenuCharacter1.SetActive(false);
            MenuCharacter2.SetActive(true);
            _characterTransform = Character2.transform;
            P2NotReadyText.enabled = false;
            P2ReadyText.enabled = true;
            GameManager.Instance.playersReady++;
            PlayerNumber = 2;
            _anim = Character2.GetComponent<Animator>();
        }
        _anim = _characterTransform.GetComponent<Animator>();
        GameManager.Instance.AllPlayers.Add(this);
        /*Debug.Log(_characterTransform.Find("Bones"));
        Debug.Log(_characterTransform.Find("Bones").Find("HipBone"));
        Debug.Log(_characterTransform.Find("Bones").Find("HipBone").Find("Torso"));
        Debug.Log(_characterTransform.Find("Bones").Find("HipBone").Find("Torso").Find("ArmR"));
        Debug.Log(_characterTransform.Find("Bones").Find("HipBone").Find("Torso").Find("ArmR").Find("Hand Position"))*/
        ;
        WeaponToolPosition = _characterTransform.Find("Bones").Find("HipBone").Find("Torso").Find("ArmR").Find("Weapon Tool Position");
        HandPosition = _characterTransform.Find("Right Arm").Find("Hand Position");
        ShieldInHandPosition = _characterTransform.Find("Bones").Find("HipBone").Find("Torso").Find("ArmL");
        Transform canvas = transform.Find("Canvas");
        ChallengesAnnouncement = canvas.Find("Challenges Announcement").gameObject;
        ChallengesInTheShop = Shop.transform.Find("Challenges").gameObject;
        RoundAnnouncement = canvas.Find("Round Announcement").gameObject;
        BlueprintsContainer = canvas.Find("Boat Blueprints").gameObject;
        BlueprintsToActivateContainer = BlueprintsContainer.transform.Find("Boat Pieces");
        ControlsDisabled = true;
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
    private void OnRightStick(InputValue value)
    {
        if (!IsShopOpen)
        {
            _iss = value.Get<Vector2>();
        }
        if (_iss == Vector2.zero)
        {
            _invSlotSwitchingTimer = 0f;
        }
    }
    public void OnDPad(InputValue value)
    {
        _inventory.ItemAction(value.Get<Vector2>());
    }
    public void OnButtonSouth()
    {
        if (IsShopOpen)
        {
            BuyItem();
        }
        else
        {
            if (CanPickUp())
                PickUp();
        }
    }
    public void OnButtonEast()
    {
        Attack();
    }
    // TODO: Show player what button can be pressed
    public void OnButtonWest()
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
        else if (CanPlaceObjectOnMap())
        {
            PlaceObjectOnMap();
            return;
        }
    }
    public void OnLeftTrigger()
    {
        Dodge();
    }
    public void OnRightShoulder()
    {
        ToggleShop();
    }
    public void OnRightTrigger()
    {
        Guard();
    }
    /*public void OnInvItemInteraction(InputValue value)
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
    }*/
    private bool CanPickUp()
    {
        //GetClosestObjectTemp();
        if (ClosestObject)
        {
            if (ClosestObject.GetComponent<ResourceDrop>() != null)
            {
                NearbyResourceDrop = ClosestObject.GetComponent<ResourceDrop>();
                return true;
                //haveInstructionsImage = true;
            }
            else if (ClosestObject.GetComponent<ItemDrop>() != null)
            {
                NearbyItemDrop = ClosestObject.GetComponent<ItemDrop>();
                return true;
                //haveInstructionsImage = true;
            }
        }
        return false;
    }
    public void PickUp()
    {
        //SFX: loot sound
        /*foreach (GameObject col in AllColliders)
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
        }*/
        //GetClosestObject("Enter");
        //add check whether mine or resources are present
        if (NearbyResourceDrop != null)
        {
            if (!_inventory.IsInventoryFull())
            {
                InvSlotContent inventorySlotContent = new InvSlotContent(NearbyResourceDrop, NearbyResourceDrop.Amount);
                Inventory.GetComponent<Inventory>().AddItem(inventorySlotContent); _instructionsToggled.Remove(NearbyResourceDrop.transform.Find("Instructions Image").gameObject);
                _instructionsToggled.Remove(NearbyResourceDrop.transform.Find("Instructions Image").gameObject);
                _firstInstruction = true;
                Destroy(NearbyResourceDrop.gameObject);
                //GetClosestObject("Enter");
            }
        }
        else if (NearbyItemDrop != null)
        {
            if (!_inventory.IsInventoryFull())
            {
                InvSlotContent inventorySlotContent = new InvSlotContent(NearbyItemDrop.Item);
                Inventory.GetComponent<Inventory>().AddItem(inventorySlotContent); _instructionsToggled.Remove(NearbyItemDrop.transform.Find("Instructions Image").gameObject);
                _instructionsToggled.Remove(NearbyItemDrop.transform.Find("Instructions Image").gameObject);
                _firstInstruction = true;
                Destroy(NearbyItemDrop.gameObject);
                //GetClosestObject("Enter");
            }
        }
    }
    private bool CanSetOnFire()
    {
        // Checking if the player has a fire source equiped. If not then exits the function
        if (_inventory.HandEquipment.IsOccupied)
        {
            if (_inventory.HandEquipment.InvSlotContent.Resource)
            {
                return false;
            }
            else if (_inventory.HandEquipment.InvSlotContent.Item.Type == Item.ItemType.Torch)
            {
                if (ClosestObject.GetComponent<Campfire>() != null && !ClosestObject.GetComponent<Campfire>().IsOnFire)
                {
                    return true;
                } else if (ClosestObject.GetComponent<ResourceMine>() != null && ClosestObject.GetComponent<ResourceMine>().CanBeSetOnFire)
                {
                    return true;
                }
            }
        }
        return false;
    }
    // Check whether the nearby object can be set on fire
    private void SetOnFire()
    {
        if (ClosestObject == null)
            return;
        if (ClosestObject.GetComponent<ResourceMine>() != null)
            NearbyResourceMine = ClosestObject.GetComponent<ResourceMine>();
        else if (ClosestObject.GetComponent<ResourceDrop>() != null)
            NearbyResourceDrop = ClosestObject.GetComponent<ResourceDrop>();
        else if (ClosestObject.GetComponent<Campfire>() != null)
            NearbyCampfire = ClosestObject.GetComponent<Campfire>();

        if (NearbyResourceMine != null && NearbyResourceMine.CanBeSetOnFire)
        {
            //SFX: fire
            ActivateFirePrefab(NearbyResourceMine.gameObject, false);
            NearbyResourceMine.IsOnFire = true;
        }
        else if (NearbyResourceDrop != null && NearbyResourceDrop.CanBeSetOnFire)
        {
            //SFX: fire
            ActivateFirePrefab(NearbyResourceDrop.gameObject, false);
            NearbyResourceDrop.IsOnFire = true;
        }
        else if (NearbyCampfire != null && NearbyCampfire)
        {
            //SFX: fire
            ActivateFirePrefab(NearbyCampfire.gameObject, true);
            NearbyCampfire.IsOnFire = true;
            HideInstructionsSprite();
        }
    }
    private void ActivateFirePrefab(GameObject obj, bool campfire)
    {
        GameObject objToSetOnFire = obj.transform.Find("Fire Prefab").gameObject;
        if (objToSetOnFire != null)
        {
            objToSetOnFire.SetActive(true);
            if (!campfire)
                objToSetOnFire.transform.parent.gameObject.AddComponent<ObjectOnFire>();
        }
    }
    private bool CanInteractWithMine()
    {
        if (ClosestObject != null && ClosestObject.GetComponent<ResourceMine>() != null)
            NearbyResourceMine = ClosestObject.GetComponent<ResourceMine>();
        if (NearbyResourceMine == null)
            return false;
        if (!NearbyResourceMine.CanBeCollected)
            return false;
        if (NearbyResourceMine.NeedsItemToInteract)
        {
            if (NearbyResourceMine.CanBeCollected && _inventory.HandEquipment.IsOccupied && _inventory.HandEquipment.InvSlotContent.Item &&_inventory.HandEquipment.InvSlotContent.Item.Type == NearbyResourceMine.NeededItem)
            {
                return true;
            }
        }
        else
        {
            return true;
        }
        return false;
    }
    private void InteractWithMine(ResourceMine mine)
    {
        HideInstructionsSprite();
        //SFX: pickaxe swing
        int amountmountOfDrop = mine.Amount;
        if (mine.BigMine)
            amountmountOfDrop *= 2;
        for (int i = 0; i < amountmountOfDrop; i++)
        {
            int randomNumber = Random.Range(-3, 4);
            Vector3 positionToSpawn = new Vector3(mine.transform.position.x + randomNumber, mine.transform.position.y + randomNumber, mine.transform.position.z);
            ResourceDrop ResourceDrop = Instantiate(ResourceDropPrefab, positionToSpawn, Quaternion.identity).GetComponent<ResourceDrop>();

            ResourceDrop.Type = mine.Type;
            if (ResourceDrop.Type == Resource.ResourceType.Wood || ResourceDrop.Type == Resource.ResourceType.Leaf)
            {
                ResourceDrop.CanBeSetOnFire = true;
            }
            ResourceDrop.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + mine.Type.ToString());
            ResourceDrop.Consubamle = mine.ConsumableDrop;
            if (ResourceDrop.Consubamle)
            {
                ResourceDrop.EffectOnPlayer = mine.EffectOnPlayer;
            }
        }
        _firstInstruction = true;
        NearbyResourceMine = null;
        if (mine.WillBeDestroyed)
        {
            Destroy(mine.gameObject);
        }
        else if (mine.WillChangeSprite)
        {
            mine.GetComponent<SpriteRenderer>().sprite = mine.SpriteToChangeTo;
            mine.CanBeCollected = false;
        }
        if (mine.Type2 != Resource.ResourceType.None)
        {
            for (int i = 0; i < amountmountOfDrop; i++)
            {
                int randomNumber = Random.Range(-1, 2);
                Vector3 positionToSpawn = new Vector3(mine.transform.position.x + randomNumber, mine.transform.position.y + randomNumber, mine.transform.position.z);
                ResourceDrop ResourceDrop = Instantiate(ResourceDropPrefab, positionToSpawn, Quaternion.identity).GetComponent<ResourceDrop>();

                ResourceDrop.Type = mine.Type2;
                if (ResourceDrop.Type == Resource.ResourceType.Wood || ResourceDrop.Type == Resource.ResourceType.Leaf)
                {
                    ResourceDrop.CanBeSetOnFire = true;
                }
                ResourceDrop.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + mine.Type.ToString());
                ResourceDrop.Consubamle = mine.ConsumableDrop;
                if (ResourceDrop.Consubamle)
                {
                    ResourceDrop.EffectOnPlayer = mine.EffectOnPlayer;
                }
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
            foreach (GameObject col in AllInstructionsObjectsColliders)
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
    private bool CanPlaceObjectOnMap()
    {
        if (_inventory.IsPreshowingItemOnMap)
        {
            return true;
        }
        return false;
    }
    private void PlaceObjectOnMap()
    {
        //SFX: Place Trap/Place Item
        _inventory.PlaceObjectOnMap();
    }
    public void TakeDamage(int damage)
    {
        if (isDodging) return;
        if (!canTakeDamage) return;
        Health -= damage;
        HealthBar.value = Health;
        if (Health <= 0)
        {
            //SFX: Death Sound
            // TODO: Play death animation
            // TODO: Open game over screen
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(IFrames());
            //SFX: Hurt Sound
        }
    }
    public void Heal(int healAmount)
    {
        print("Healing function works");
        if (Health >= MaxHealth)
            return;
        if (Health + healAmount >= MaxHealth)
        {
            Health = MaxHealth;
        }
        else
        {
            Health += healAmount;
            print("Healing");
        }
    }
    public void Stun(float stunValue)
    {
        CurrentStunTime = stunValue;
        _anim.SetBool("isStunned", true);
    }
    private void PlayerMovement()
    {
        if (!isDodging && !ControlsDisabled)
        {
            GetComponent<Rigidbody2D>().MovePosition(new Vector2(transform.position.x + mv.x * MovementSpeed * Time.deltaTime, transform.position.y + mv.y * MovementSpeed * Time.deltaTime));
            _anim.SetBool("isMoving", mv != Vector2.zero);
        } else
        {
            transform.Translate(s * Time.deltaTime, Space.World);
            _anim.SetBool("isMoving", false);
        }
        /*Vector2 m = new Vector2(mv.x, mv.y) * MovementSpeed * Time.deltaTime;
        if (!isDodging)
        {
            transform.Translate(m, Space.World);
            _anim.SetBool("isMoving", m != Vector2.zero);
        }
        else
        {
            transform.Translate(s * Time.deltaTime, Space.World);
            _anim.SetBool("isMoving", false);
        }*/


        /*Vector2 r = new Vector2(-rv.x, -rv.y) * 100f * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, r.x), Space.World);*/

        if (mv.x < 0 && _facingRight)
        {
            FlipCharacter("Left");
        }
        else if (mv.x > 0 && !_facingRight)
        {
            FlipCharacter("Right");
        }


        if (mv != Vector2.zero)
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
        }
        else if (side == "Right")
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
            else if (_cs.y < -UITogglingSensitivity && _cs.x < .3f && _cs.x > -.3f)
            {
                _direction = "Down";
            }
        }
        if (_direction != string.Empty)
        {
            if (_categorySwitchingTimer == 0f)
            {
                _shop.SelectingShopCategory(_direction);
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
            if (_is.x > UITogglingSensitivity && _cs.y < .3f && _cs.y > -.3f)
            {
                _direction = "Right";
            }
            else if (_is.x < -UITogglingSensitivity && _cs.y < .3f && _cs.y > -.3f)
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
        _invTogglingTimer += Time.deltaTime;
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
                if (!_inventory.enabled)
                {
                    _inventory.enabled = true;
                }
                else
                {
                    _inventory.SelectingInvSlot(_direction);
                }
                _invTogglingTimer = 0;
            }
            _invSlotSwitchingTimer += Time.deltaTime;
            if (_invSlotSwitchingTimer > UITogglingDelay)
            {
                _invSlotSwitchingTimer = 0f;
            }
        }
        if (_invTogglingTimer > _inventory.TogglingTimer)
        {
            _inventory.enabled = false;
        }
    }
    private void ToggleShop()
    {
        //if (!InBase) return;
        //SFX: open menu
        _shop.ToggleShop();
        IsShopOpen = !IsShopOpen;
    }
    private void Attack()
    {
        ///Debug.Log("hit hit hit");
        if (!isDefending && !isAttacking && !isDodging)
        {
            //SFX: attack sound
            AtkRef.SetTrigger("Attack");
            _anim.SetTrigger("isAttacking");
            isAttacking = true;
        }
    }
    private void Guard()
    {
        if (!isAttacking && !isDefending && !isDodging)
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
            isDodging = true;
            _anim.SetTrigger("isDodge");
            //SFX: dodge sound
            if (mv != Vector2.zero)
            {
                s = new Vector2(mv.x, mv.y) * MovementSpeed * 3f;
            }
            else
            {
                if (_facingRight)
                {
                    s = new Vector2(1, 0) * MovementSpeed * 3f;
                }
                else
                {
                    s = new Vector2(-1, 0) * MovementSpeed * 3f;
                }
            }

            //need to add dodge animation           
        }
    }
    private void BuyItem()
    {
        if (_shop.CanCraftItem())
            _shop.CraftItem();
    }
    private void OnEnable()
    {
        PlayerPool.Add(this);
        input.Player.Enable();
    }
    private void OnDisable()
    {
        PlayerPool.Remove(this);
        input.Player.Disable();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!AllInstructionsObjectsColliders.Contains(col.gameObject))
        {
            if (col.GetComponent<ResourceMine>() != null || col.GetComponent<ResourceDrop>() != null || col.GetComponent<ItemDrop>() != null || col.GetComponent<Campfire>() != null)
            {
                AllInstructionsObjectsColliders.Add(col.gameObject);
            }
        }
    }
    private void ShowInstructionsSprite()
    {
        if (ClosestObject == null)
            _firstInstruction = true;
        if (ClosestObject != null)
        {
            if (_firstInstruction)
            {
                if (ClosestObject != null)
                {
                    if (ClosestObject.GetComponent<ResourceMine>() != null)
                    {
                        if (CanInteractWithMine() || CanSetOnFire())
                        {
                            if (ClosestObject.transform.Find("Instructions Image") != null)
                            {
                                print("can interact");
                                ClosestObject.transform.Find("Instructions Image").gameObject.SetActive(true);
                                _instructionsShown = ClosestObject.transform.Find("Instructions Image").gameObject;
                                _firstInstruction = false;
                            }
                        }
                    }
                    else
                    {
                        print("cant interact");
                        if (ClosestObject.transform.Find("Instructions Image") != null)
                        {
                            ClosestObject.transform.Find("Instructions Image").gameObject.SetActive(true);
                            _instructionsShown = ClosestObject.transform.Find("Instructions Image").gameObject;
                            _firstInstruction = false;
                        }
                    }
                }
            }
            else
            {
                if (!_instructionsShown.activeSelf)
                {
                    if (ClosestObject != null)
                    {
                        if (ClosestObject.GetComponent<ResourceMine>() != null)
                        {
                            if (CanInteractWithMine() || CanSetOnFire())
                            {
                                if (ClosestObject.transform.Find("Instructions Image") != null)
                                {
                                    ClosestObject.transform.Find("Instructions Image").gameObject.SetActive(true);
                                    _instructionsShown = ClosestObject.transform.Find("Instructions Image").gameObject;
                                }
                            }
                        }
                        else
                        {
                            print("cant interact");
                            if (ClosestObject.transform.Find("Instructions Image") != null)
                            {
                                ClosestObject.transform.Find("Instructions Image").gameObject.SetActive(true);
                                _instructionsShown = ClosestObject.transform.Find("Instructions Image").gameObject;
                            }
                        }
                    }
                }
            }
        }
    }
    private void HideInstructionsSprite()
    {
        if (_instructionsShown != null)
            _instructionsShown.SetActive(false);

        /*if (ClosestObject != null)
        {
            if (ClosestObject.transform.Find("Instructions Image") != null)
            {
                _instructionsToggled.Remove(ClosestObject.transform.Find("Instructions Image").gameObject);
                ClosestObject.transform.Find("Instructions Image").gameObject.SetActive(false);
            }
        }*/
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (AllInstructionsObjectsColliders.Contains(col.gameObject))
        {
            //GetClosestObject("Exit");
            AllInstructionsObjectsColliders.Remove(col.gameObject);
            if (ClosestObject != null && ClosestObject == col.gameObject)
            {
                HideInstructionsSprite();
                if (ClosestObject.GetComponent<ResourceMine>() != null)
                {
                    NearbyResourceMine = null;
                }
                else if(ClosestObject.GetComponent<ResourceDrop>() != null)
                {
                    NearbyResourceDrop = null;
                }
                else if (ClosestObject.GetComponent<ItemDrop>() != null)
                {
                    NearbyItemDrop = null;
                }
                else if (ClosestObject.GetComponent<Campfire>() != null)
                {
                    NearbyCampfire = null;
                }
                ClosestObject = null;
            }
            /*if (col.transform.Find("Instructions Image") != null)
            {
                if (_instructionsToggled.Contains(col.transform.Find("Instructions Image").gameObject))
                    _instructionsToggled.Remove(ClosestObject.transform.Find("Instructions Image").gameObject);
                col.gameObject.transform.Find("Instructions Image").gameObject.SetActive(false);
            }*/
            //HideInstructionsSprite();
        }
        /*if (col.GetComponent<ResourceMine>() != null)
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
        }*/
    }
    private void ShowInstructions()
    {
        float smallestDistance = 100f;
        foreach (GameObject obj in AllInstructionsObjectsColliders)
        {
            float distance = Vector3.Distance(transform.position, obj.transform.position);
            if (distance < smallestDistance)
            {
                smallestDistance = distance;
                if (ClosestObject != obj)
                {
                    HideInstructionsSprite();
                }
                ClosestObject = obj;
            }
        }
        ShowInstructionsSprite();
    }
    IEnumerator IFrames()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(1f);
        canTakeDamage = true;
    }
}
