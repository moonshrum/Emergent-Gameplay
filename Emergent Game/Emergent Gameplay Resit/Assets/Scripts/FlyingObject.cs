using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool _isFlying;
    public void Throw(GameObject obj, Vector3 side)
    {
        _isFlying = true;
        rb = obj.GetComponent<Rigidbody2D>();
        rb.velocity = side * 10f;
        Invoke("StopObject", 2f);
    }
    private void StopObject()
    {
        _isFlying = false;
        rb.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (_isFlying)
        {
            // Damage player
        }
    }
}
