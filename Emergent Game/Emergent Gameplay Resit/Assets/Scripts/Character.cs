using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Player Player;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.transform.name);
        if (col.transform.tag == "ResourceMine")
        {
            Player.NearbyResourceMine = col.GetComponent<ResourceMine>();
        }
        if (col.transform.tag == "Resource Drop")
        {
            Player.NearbyResourceDrop = col.GetComponent<ResourceDrop>();
        }
        if (col.transform.tag == "Item Drop")
        {
            Player.NearbyItemDrop = col.GetComponent<ItemDrop>();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.tag == "ResourceMine")
        {
            Player.NearbyResourceMine = null;
        }
        if (col.transform.tag == "Resource Drop")
        {
            Player.NearbyResourceDrop = null;
        }
        if (col.transform.tag == "Item Drop")
        {
            Player.NearbyItemDrop = null;
        }
    }
}
