using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1 : MonoBehaviour
{
    private Player _playerInterface;
    public static Player1 Instance;
    PlayerInputs input;

    private Rigidbody2D rb;
    private Vector2 mv;
    private Vector2 rv;

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
    }
    void Update()
    {
        Vector2 m = new Vector2(mv.x, mv.y) * _playerInterface.MovementSpeed * Time.deltaTime;
        transform.Translate(m, Space.World);

        Vector2 r = new Vector2(-rv.x, -rv.y) * 100f * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, r.x), Space.World);

        // TODO: create a player input for shop toggling
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            _playerInterface.ToggleShop();
        }
    }

    

    private void GenerateInputs()
    {
        input.Player.Move.performed += ctx => mv = ctx.ReadValue<Vector2>();
        input.Player.Move.canceled += ctx => mv = Vector2.zero;

        input.Player.Rotate.performed += ctx => rv = ctx.ReadValue<Vector2>();
        input.Player.Rotate.canceled += ctx => rv = Vector2.zero;

        input.Player.Collect.performed += ctx => _playerInterface.CollectMine();
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
