using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Player: MonoBehaviour
{
    public int Health = 100;
    public int Attack = 10;
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

    [Space(25f)]
    [SerializeField]
    public List<Resource> AllResources = new List<Resource>();

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
                MovementSpeed /= 5f;
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
            //_anim = Character1.GetComponent<Animator>();
        }
        else if (PlayerInput.GetPlayerByIndex(1).transform == transform)
        {
            Character1.SetActive(false);
            Character2.SetActive(true);
            _characterTransform = Character2.transform;
            //_anim = Character2.GetComponent<Animator>();
        }
        _anim = _characterTransform.GetComponent<Animator>();
        GameManager.Instance.AllPlayers.Add(this);
        HandPosition = _characterTransform.Find("Hand Position");
        Transform canvas = transform.Find("Canvas");
        ChallengesAnnouncement = canvas.Find("Challenges Announcement").gameObject;
        ChallengesInTheShop = Shop.transform.Find("Challenges").gameObject;
        RoundAnnouncement = canvas.Find("Round Announcement").gameObject;
    }
    public void OnCollect()
    {
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
            }
            else if (col.transform.tag == "Item Drop")
            {
                NearbyItemDrop = col.GetComponent<ItemDrop>();
                break;
            }
        }
        //add check whether mine or resources are present
        if (NearbyResourceMine != null)
        {
            CollectMine(NearbyResourceMine);
        }
        else if (NearbyResourceDrop != null)
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
            InvSlotContent inventorySlotContent = new InvSlotContent(NearbyItemDrop.Item, NearbyItemDrop.Name, NearbyItemDrop.IconName, NearbyItemDrop.SpriteName);
            if (!_inventory.IsInventoryFull())
            {
                Inventory.GetComponent<Inventory>().AddItem(inventorySlotContent);
                Destroy(NearbyItemDrop.gameObject);
            }
        }
    }
    public void TakeDamage(int damage)
    {
        if (isDodging) return;
        Health -= damage;

        if (Health <= 0)
        {
            //play death animation
            //open game over screen
            Destroy(gameObject);
        }
    }

    public void Stun(float stunValue)
    {
        CurrentStunTime = stunValue;
        _anim.SetBool("isStunned", true);
    }

    public void CollectMine(ResourceMine mine)
    {
        if (mine.CanBeCollected)
        {
            int randomAmountOfDrop = Random.Range(1, 4);
            for (int i = 0; i < randomAmountOfDrop; i++)
            {
                int randomNumber = Random.Range(-1, 2);
                Vector3 positionToSpawn = new Vector3(mine.transform.position.x + randomNumber, mine.transform.position.y + randomNumber, mine.transform.position.z);
                GameObject ResourceDrop = Instantiate(ResourceDropPrefab, positionToSpawn, Quaternion.identity);
                ResourceDrop.GetComponent<ResourceDrop>().Type = mine.Type;
                ResourceDrop.GetComponent<ResourceDrop>().Amount = ResourceDrop.GetComponent<ResourceDrop>().DefaultAmount;
                ResourceDrop.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + mine.Type.ToString());
            }
            if (mine.WillBeDestroyed)
            {
                Destroy(mine.gameObject);
            }
            else if (mine.WillChangeSprite)
            {
                mine.GetComponent<SpriteRenderer>().sprite = mine.SpriteToChangeTo;
            }
            mine.CanBeCollected = false;
        }
    }

    private void PlayerMovement()
    {
        Vector2 m = new Vector2(mv.x, mv.y) * MovementSpeed * Time.deltaTime;
        transform.Translate(m, Space.World);

        /*Vector2 r = new Vector2(-rv.x, -rv.y) * 100f * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, r.x), Space.World);*/

        if (m.x < 0 && _facingRight)
        {
            FlipCharacter("Left");
        } else if (m.x > 0 && !_facingRight)
        {
            FlipCharacter("Right");
        }
        _anim.SetBool("isMoving", m != Vector2.zero);
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

    private void OnMove(InputValue value)
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

        if (_cs == Vector2.zero)
        {
            _categorySwitchingTimer = 0f;
            _itemSwitchingTimer = 0f;
        }
    }

    private void OnShop()
    {
        Shop.SetActive(!Shop.activeSelf);
        IsShopOpen = !IsShopOpen;
    }

    private void OnAttack()
    {
        if (!isDefending)
        {
            AtkRef.SetTrigger("Attack");
            isAttacking = true;
        }        
    }

    private void OnGuard()
    {
        if (!isAttacking)
        {
            DefRef.SetTrigger("Defend");
            isDefending = true;
        }          
    }

    private void OnDodge()
    {
        if (!isAttacking && !isDefending && !isDodging)
        {
            MovementSpeed *= 5f;
            isDodging = true;
            //need to add dodge animation           
        }
    }

    private void OnBuyItem()
    {
        if (IsShopOpen)
            _shop.CraftItem(_shop.SelectedItem, Instance);
    }

    private void OnPlaceTrap()
    {
        if (_inventory.IsPreshowingTrap)
        {
            _inventory.PlaceTrap();
        }
    }
    private void OnCancelTrapPlacing()
    {
        if (_inventory.IsPreshowingTrap)
        {
            _inventory.CancelTrapPreshow();
        }
    }

    public void OnInvItemInteraction(InputValue value)
    {
        _ia = value.Get<Vector2>().normalized;
        _inventory.ItemAction(_ia);
    }

    private void OnItemSelection(InputValue value)
    {
        _is = value.Get<Vector2>();
        if (_is == Vector2.zero)
        {
            _itemSwitchingTimer = 0f;
        }
    }
    private void OnInventoryItemSelection(InputValue value)
    {
        _iss = value.Get<Vector2>();
        if (_iss == Vector2.zero)
        {
            _invSlotSwitchingTimer = 0f;
        }
    }

    private void OnEnable()
    {
        input.Player.Enable();
    }
    private void OnDisable()
    {
        input.Player.Disable();
    }
}
