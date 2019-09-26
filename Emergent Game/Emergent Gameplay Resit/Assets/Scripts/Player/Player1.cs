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

    private Rigidbody2D rb;
    private Vector2 mv;
    private Vector2 _cs; // Variable that stores the value of the left stick during category selection in the shop
    private Vector2 _is; // Variavle that store the value of the left stick during item selection in the shop
    //private Vector2 rv;
    private float _categorySwitchingTimer;
    private float _itemSwitchingTimer;

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        input = new PlayerInputs();
        GenerateInputs();
    }

    private void Start()
    {
        if (GetComponent<Player>()) { }
            _playerInterface = GetComponent<Player>();
        _shop = _playerInterface.Shop.GetComponent<Shop>();
    }
    void Update()
    {
        if (!_playerInterface.IsShopOpen)
        {
            PlayerMovement();
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
            _categorySwitchingTimer += Time.deltaTime;
            if (_categorySwitchingTimer > 1f)
            {
                _categorySwitchingTimer = 0f;
            }
        }
    }

    private void GenerateInputs()
    {
        input.Player.Move.performed += ctx => mv = ctx.ReadValue<Vector2>();
        input.Player.Move.canceled += ctx => mv = Vector2.zero;

        /*input.Player.Rotate.performed += ctx => rv = ctx.ReadValue<Vector2>();
        input.Player.Rotate.canceled += ctx => rv = Vector2.zero;*/

        input.Player.Collect.performed += ctx => _playerInterface.CollectMine();

        input.Player.Shop.performed += ctx => _playerInterface.ToggleShop();

        input.Player.CategorySelection.performed += ctx => _cs = ctx.ReadValue<Vector2>();
        input.Player.CategorySelection.canceled += ctx => _cs = Vector2.zero;
        input.Player.CategorySelection.canceled += ctx => _categorySwitchingTimer = 0f;

        input.Player.ItemSelection.performed += ctx => _is = ctx.ReadValue<Vector2>();
        input.Player.ItemSelection.canceled += ctx => _is = Vector2.zero;
        input.Player.ItemSelection.canceled += ctx => _itemSwitchingTimer = 0f;

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
