using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_shield : MonoBehaviour
{
    public Player PlayerInterface;
    public float StunDuration;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.GetComponent<Player>() != null && coll.GetComponent<Player>().isAttacking == true)
        {
            coll.GetComponent<Player>().Stun(StunDuration);
        }

        if (coll.GetComponent<Animal>() != null && coll.GetComponent<Animal>().isAttacking == true)
        {
            coll.GetComponent<Animal>().Stun(StunDuration);
        }
    }

    void EndDefend()
    {
        Debug.Log("shit");
        PlayerInterface.isDefending = false;
    }
}
