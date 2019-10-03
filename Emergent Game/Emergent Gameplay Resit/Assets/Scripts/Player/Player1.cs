using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1 : MonoBehaviour
{
    private Player _playerInterface;
    public static Player1 Instance;
    PlayerInputs input;
    private Shop _shop;
    private Inventory _inventory;

    private Rigidbody2D rb;
    Vector2 mv;
    private Vector2 _cs; // Variable that stores the value of the left stick during category selection in the shop
    private Vector2 _is; // Variavle that store the value of the left stick during item selection in the shop
    //private Vector2 rv;
    private Vector2 _iss; // Variavle that store the value of the right stick during inventory slot selection in the inventory
    //private Vector2 rv;
    private float _categorySwitchingTimer;
    private float _itemSwitchingTimer;
    private float _invSlotSwitchingTimer;

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        input = new PlayerInputs();
        GenerateInputs();
    }

    private void Start()
    {
        _playerInterface = GetComponent<Player>();
        _shop = _playerInterface.Shop.GetComponent<Shop>();
        _inventory = _playerInterface.Inventory.GetComponent<Inventory>();
    }
    void Update()
    {
        _playerInterface.HealthBar.value = _playerInterface.Health;

        if (!_playerInterface.IsShopOpen)
        {
            PlayerMovement();
            InvSlotSelectionControls();
        } else
        {
            CategorySelectionControls();
            ItemSelectionControls();
        }
        //Debug.Log(_categorySwitchingTimer);
    }
    
    private void PlayerMovement()
    {
        Vector2 m = new Vector2(mv.x, mv.y) * _playerInterface.MovementSpeed * Time.deltaTime;
        transform.Translate(m, Space.World);

        /*Vector2 r = new Vector2(-rv.x, -rv.y) * 100f * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, r.x), Space.World);*/

        _playerInterface.Anim.SetBool("isMoving", m != Vector2.zero);
    }

    private void CategorySelectionControls()
    {
        string _direction = string.Empty;
        if (_cs != Vector2.zero)
        {
            if (_cs.y > 0)
            {
                _direction = "Up";
            } else if (_cs.y < 0)
            {
                _direction = "Down";
            }
        }
        if (_direction != string.Empty)
        {
            if (_categorySwitchingTimer == 0f)
            {
                _playerInterface.Shop.GetComponent<Shop>().SelectingShopCategory(_direction);
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
        if (!_playerInterface.IsShopOpen)
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
        _playerInterface.ToggleShop();
    }

    private void OnPickUp()
    {
        _playerInterface.PickUpDrop();
    }

    private void OnAttack()
    {
        _playerInterface.AttackTarget();
    }

    private void OnCollect()
    {
        //add check whether mine or resources are present
        _playerInterface.CollectMine();
        _playerInterface.PickUpDrop();
    }

    private void OnBuyItem()
    {
        _shop.CraftItem(_shop.SelectedItem, _playerInterface);
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

    private void GenerateInputs()
    {
        //input.Player.Move.performed += ctx => mv = ctx.ReadValue<Vector2>();
        //input.Player.Move.canceled += ctx => mv = Vector2.zero;

        /*input.Player.Rotate.performed += ctx => rv = ctx.ReadValue<Vector2>();
        input.Player.Rotate.canceled += ctx => rv = Vector2.zero;*/

        //input.Player.Attack.performed += ctx => _playerInterface.AttackTarget();

        //input.Player.Collect.performed += ctx => _playerInterface.CollectMine();

        //input.Player.PickUp.performed += ctx => _playerInterface.PickUpDrop();

        //input.Player.Shop.performed += ctx => _playerInterface.ToggleShop();

        //input.Player.BuyItem.performed += ctx => _shop.CraftItem(_shop.SelectedItem, _playerInterface);

        /*input.Player.CategorySelection.performed += ctx => _cs = ctx.ReadValue<Vector2>();
        input.Player.CategorySelection.canceled += ctx => _cs = Vector2.zero;
        input.Player.CategorySelection.canceled += ctx => _categorySwitchingTimer = 0f;

        input.Player.ItemSelection.performed += ctx => _is = ctx.ReadValue<Vector2>();
        input.Player.ItemSelection.canceled += ctx => _is = Vector2.zero;
        input.Player.ItemSelection.canceled += ctx => _itemSwitchingTimer = 0f;

        input.Player.InventoryItemSelection.performed += ctx => _iss = ctx.ReadValue<Vector2>();
        input.Player.InventoryItemSelection.canceled += ctx => _iss = Vector2.zero;
        input.Player.InventoryItemSelection.canceled += ctx => _invSlotSwitchingTimer = 0f;*/

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
