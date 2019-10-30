using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1_Camp : MonoBehaviour
{
    private Player _player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        _player = other.GetComponent<Player>();
        if ( _player == null) return;
        if (_player.PlayerNumber == 1)
            _player.InBase = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _player = other.GetComponent<Player>();
        if (_player == null) return;
        if (_player.PlayerNumber == 1)
            _player.InBase = false;
    }
}
