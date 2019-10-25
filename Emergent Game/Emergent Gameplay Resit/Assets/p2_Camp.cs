using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2_Camp : MonoBehaviour
{
    private Player _player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        _player = other.GetComponent<Player>();
        if (_player == null) return;
        if (_player.PlayerNumber == 2)
            _player.inBase = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _player = other.GetComponent<Player>();
        if (_player == null) return;
        if (_player.PlayerNumber == 2)
            _player.inBase = false;
    }
}
