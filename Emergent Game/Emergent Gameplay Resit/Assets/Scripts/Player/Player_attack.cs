using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_attack : MonoBehaviour
{
    public Player PlayerInterface;
    public int DamageValue = 0;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.GetComponent<Player>() != null)
        {
            coll.GetComponent<Player>().TakeDamage(DamageValue);
        }

        if (coll.GetComponent<Animal>() != null)
        {
            coll.GetComponent<Animal>().PlayerHit = PlayerInterface;
            coll.GetComponent<Animal>().TakeDamage(DamageValue);
        }
    }

    void EndAttack()
    {
        PlayerInterface.isAttacking = false;
    }
}
