using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_attack : MonoBehaviour
{
    public Player PlayerInterface;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.GetComponent<Player>() != null)
        {
            coll.GetComponent<Player>().TakeDamage(PlayerInterface.AttackeValue);
        }

        if (coll.GetComponent<Animal>() != null)
        {
            coll.GetComponent<Animal>().PlayerHit = PlayerInterface;
            coll.GetComponent<Animal>().TakeDamage(PlayerInterface.AttackeValue);
        }
    }

    void EndAttack()
    {
        PlayerInterface.isAttacking = false;
    }
}
