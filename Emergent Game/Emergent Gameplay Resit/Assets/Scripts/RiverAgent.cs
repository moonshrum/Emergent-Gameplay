using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverAgent : MonoBehaviour
{
    public GameObject CollidingWith;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "River Piece")
        {
            CollidingWith = col.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        
    }
}
