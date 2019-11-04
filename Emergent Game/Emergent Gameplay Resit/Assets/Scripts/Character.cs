using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Player Player;
    private Animator _anim;

    private void Awake()
    {
        _anim = Player._anim;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!Player.AllColliders.Contains(col.gameObject))
        {
            Player.AllColliders.Add(col.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (Player.AllColliders.Contains(col.gameObject))
        {
            Player.AllColliders.Remove(col.gameObject);
        }
        /*if (col.GetComponent<ResourceMine>() != null)
        {
            if (Player.NearbyResourceMine == col.GetComponent<ResourceMine>())
            {
                Player.NearbyResourceMine = null;
            }
        } else if (col.GetComponent<ResourceDrop>() != null)
        {
            if (Player.NearbyResourceDrop == col.GetComponent<ResourceDrop>())
            {
                Player.NearbyResourceDrop = null;
            }
        } else if (col.GetComponent<ItemDrop>() != null)
        {
            if (Player.NearbyItemDrop == col.GetComponent<ItemDrop>())
            {
                Player.NearbyItemDrop = null;
            }
        }*/
    }

    private void EndAttack()
    {
        //Debug.Log("end");
        Player.isAttacking = false;
    }

    private void EndDodge()
    {
        Player.isDodging = false;
    }
}
