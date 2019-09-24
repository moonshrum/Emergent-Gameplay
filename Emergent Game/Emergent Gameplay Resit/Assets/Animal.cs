using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{ 
    public CircleCollider2D SearchRadius;
    public CircleCollider2D AttackRadius;
    private Transform _target = null;
    public int AtkRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null) return;
        transform.LookAt(_target);
        transform.position = Vector2.MoveTowards(transform.position, _target.position, 1);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") _target = other.transform;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") _target = null;
    }
}
