using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Player Player;
    private Animator _anim;

    private void Awake()
    {
        _anim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!Player.AllColliders.Contains(col))
        {
            Player.AllColliders.Add(col);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (Player.AllColliders.Contains(col))
        {
            Player.AllColliders.Remove(col);
        }
        if (col.GetComponent<ResourceMine>() != null)
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
        }
    }

    private void EndAttack()
    {
        _anim.SetBool("isAttacking", false);
    }

    private void EndDodge()
    {
        Player.isDodging = false;
    }
}
