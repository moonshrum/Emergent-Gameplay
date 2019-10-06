using System.Collections;
using System.Collections.Generic;
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

    [Header("Does not need reference")]
    public ResourceMine NearbyResourceMine;
    public ResourceDrop NearbyResourceDrop;
    public ItemDrop NearbyItemDrop;

    [Header("Needs reference")]
    public GameObject Shop;
    public GameObject Inventory;
    public Animator Anim;
    public Slider HealthBar;

    [SerializeField]
    public List<Resource> AllResources = new List<Resource>();

    public Animator AtkRef;



    public static Player Instance;
    PlayerInputs input;
    private Shop _shop;
    private Inventory _inventory;

    private Rigidbody2D rb;
    Vector2 mv;
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
    }
    void Update()
    {
        HealthBar.value = Health;

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
        //Debug.Log(_categorySwitchingTimer);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "ResourceMine")
        {
            NearbyResourceMine = col.GetComponent<ResourceMine>();
        }
        if (col.transform.tag == "Resource Drop")
        {
            NearbyResourceDrop = col.GetComponent<ResourceDrop>();
        }
        if (col.transform.tag == "Item Drop")
        {
            NearbyItemDrop = col.GetComponent<ItemDrop>();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.tag == "ResourceMine")
        {
            NearbyResourceMine = null;
        }
        if (col.transform.tag == "Resource Drop")
        {
            NearbyResourceDrop = null;
        }
        if (col.transform.tag == "Item Drop")
        {
            NearbyItemDrop = null;
        }
    }

    public void TakeDamage(int damage)
    {
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
        Anim.SetTrigger("isStunned");
    }
    public void CollectResource(ResourceMine mine)
    {
        foreach (Resource resource in AllResources)
        {
            if (mine.Type == resource.Type)
            {
                resource.IncreaseResource(mine.ResourceAmount);
            }
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
        Anim.SetBool("isMoving", m != Vector2.zero);
    }

    private void FlipCharacter(string side)
    {
        if (side == "Left")
        {
            _facingRight = false;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        } else if (side == "Right")
        {
            Debug.Log("aaaaaaa");
            _facingRight = true;
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    private void CategorySelectionControls()
    {
        string _direction = string.Empty;
        if (_cs != Vector2.zero)
        {
            if (_cs.y > 0)
            {
                _direction = "Up";
            }
            else if (_cs.y < 0)
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
            if (_categorySwitchingTimer > 1f)
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
            if (_is.x > 0)
            {
                _direction = "Right";
            }
            else if (_is.x < 0)
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
            if (_itemSwitchingTimer > 1f)
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
            if (_invSlotSwitchingTimer > 1f)
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
        }

        if (_cs == Vector2.zero)
        {
            _categorySwitchingTimer = 0f;
        }
    }

    private void OnShop()
    {
        Shop.SetActive(!Shop.activeSelf);
        IsShopOpen = !IsShopOpen;
    }

    private void OnAttack()
    {
        AtkRef.SetTrigger("Attack");
    }

    public void OnCollect()
    {
        //add check whether mine or resources are present
        if (NearbyResourceMine != null)
        {
            CollectResource(NearbyResourceMine);
        }
        else
        {
            Debug.LogWarning("No Mine Nearby");
        }
        if (NearbyResourceDrop != null)
        {
            InvSlotContent inventorySlotContent = new InvSlotContent(NearbyResourceDrop, NearbyResourceDrop.Amount);
            if (!_inventory.IsInventoryFull())
            {
                Inventory.GetComponent<Inventory>().AddItem(inventorySlotContent);
                Destroy(NearbyResourceDrop.gameObject);
            }
        }
        else
        {
            Debug.LogWarning("No ResourceDrop Nearby");
        }
        if (NearbyItemDrop != null)
        {
            InvSlotContent inventorySlotContent = new InvSlotContent(NearbyItemDrop.Item, NearbyItemDrop.Name, NearbyItemDrop.IconName);
            if (!_inventory.IsInventoryFull())
            {
                Inventory.GetComponent<Inventory>().AddItem(inventorySlotContent);
                Destroy(NearbyItemDrop.gameObject);
            }
        }
        else
        {
            Debug.LogWarning("No ItemDrop Nearby");
        }
    }

    private void OnBuyItem()
    {
        if (IsShopOpen)
            _shop.CraftItem(_shop.SelectedItem, Instance);
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
