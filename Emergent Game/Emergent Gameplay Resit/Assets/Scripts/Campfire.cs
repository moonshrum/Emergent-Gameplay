using System.Collections;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    public bool IsOnFire;
    private Player _player;
    [System.NonSerialized]
    public Sprite InstructionSprite;

    private void Awake()
    {
        InstructionSprite = Resources.Load<Sprite>("Sprites/Interact Icon");
        transform.Find("Instructions Image").GetComponent<SpriteRenderer>().sprite = InstructionSprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _player = other.GetComponent<Player>();
        if (_player == null) return;
        if (_player.PlayerNumber == 1)
            StartCoroutine(Heal());
        //_player.InBase = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _player = other.GetComponent<Player>();
        if (_player.GetComponent<Player>() != null) return;
        if (_player.PlayerNumber == 1)
            StopCoroutine(Heal());
        //_player.InBase = false;
    }

    private IEnumerator Heal()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            if (IsOnFire) _player.Health += 5;
        }
    }
}
