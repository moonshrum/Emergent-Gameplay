using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_shield : MonoBehaviour
{
    public Player PlayerInterface;
    public float StunDuration;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.GetComponent<Player>() != null /*&& player is attacking*/)
        {
            coll.GetComponent<Player>().Stun(StunDuration);
        }

        if (coll.GetComponent<Animal>() != null /*&& animal is attacking*/)
        {
            coll.GetComponent<Animal>().Stun(StunDuration);
        }
    }
}
