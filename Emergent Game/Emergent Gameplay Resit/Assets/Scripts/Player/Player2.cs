using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    private Player _playerInterface;
    public static Player2 Instance;
    PlayerInputs input;

    private Rigidbody2D rb;
    private Vector2 mv;
    private Vector2 rv;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        input = new PlayerInputs();

        input.Player2.Move.performed += ctx => mv = ctx.ReadValue<Vector2>();
        input.Player2.Move.canceled += ctx => mv = Vector2.zero;

        input.Player2.Rotate.performed += ctx => rv = ctx.ReadValue<Vector2>();
        input.Player2.Rotate.canceled += ctx => rv = Vector2.zero;
    }

    private void Start()
    {
        if (GetComponent<Player>()) { }
        _playerInterface = GetComponent<Player>();
    }
    void Update()
    {
        Vector2 m = new Vector2(-mv.x, mv.y) * Time.deltaTime;
        transform.Translate(m, Space.World);

        Vector2 r = new Vector2(-rv.x, -rv.y) * 100f * Time.deltaTime;
        transform.Rotate(r, Space.World);

        // TODO: create a player input for shop toggling
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            _playerInterface.ToggleShop();
        }

        // The input here is just for testing
        // Jeff please create an input for this with your input system
        /*if (Input.GetKeyUp(KeyCode.A))
        {
            if (_playerInterface.NearbyResourceMine != null)
            {
                _playerInterface.CollectResource(_playerInterface.NearbyResourceMine);
            } else
            {
                Debug.LogError("No Mine Nearby");
            }
        }*/
    }
}
