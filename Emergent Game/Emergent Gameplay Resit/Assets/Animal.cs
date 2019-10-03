using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    public Transform Target = null;

    [Header("Base Stats")]
    public int Health = 20;
    public int Damage = 10;
    public int AtkRange;
    public int ChaseRange;
    public float SearchSpeed = 2;
    public float ChaseSpeed = 5;
    public float AttackSpeed = 10;

    [Header("Do not change")]
    public float Speed;
    public Slider HealthBar;
    public Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist;
        HealthBar.value = Health;
        if (Target == null)
        {
            Anim.SetBool("isIdling", true);
            Anim.SetBool("isSearching", false);
            return;
        }
        else
        {
            Anim.SetBool("isIdling", false);
            dist = Vector2.Distance(transform.position, Target.position);
        }
       
        if (dist > ChaseRange) 
        {
            Anim.SetBool("isSearching", true);
        }
        else
        {
            Anim.SetBool("isSearching", false);
        }

        if (dist < ChaseRange && dist > AtkRange)
        {
            Anim.SetBool("isChasing", true);
        }
        else
        {
            Anim.SetBool("isChasing", false);
        }

        if (dist < AtkRange)
        {
            Anim.SetBool("isAttacking", true);
        }
        else
        {
            Anim.SetBool("isAttacking", false);
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            //play death animation
            //drop loot
            Destroy(gameObject);
        }
    }

    public void Stun(float stunValue)
    {

    } }
