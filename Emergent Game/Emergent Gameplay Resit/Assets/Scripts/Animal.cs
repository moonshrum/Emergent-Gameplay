using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    public enum AnimalType { Bear, Spider};
    public AnimalType Type;
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

    public float CurrentStunTime;
    public bool isAttacking = false;
    public bool isStunned = false;

    private BoxCollider2D _hurtBox;
    Vector2 heading;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        _hurtBox = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist;
        HealthBar.value = Health;
        if (Target == null)
        {
            Anim.SetBool("isIdling", true);
            transform.position = Vector2.MoveTowards(transform.position, heading, 0 * Time.deltaTime);
            Anim.SetBool("isMoving", false);
            return;
        }
        else
        {
            Anim.SetBool("isIdling", false);
            dist = Vector2.Distance(transform.position, Target.position);
        }
       
        if (dist > ChaseRange && !isStunned) 
        {
            Anim.SetBool("isMoving", true);
            time += Time.deltaTime;

            if (time > 2.0f)
            {
                CalculateHeading();
                time = 0f;
            }
            Debug.Log(heading);
            transform.position = Vector2.MoveTowards(transform.position, heading, SearchSpeed * Time.deltaTime);
        }

        if (dist < ChaseRange && dist > AtkRange && !isStunned)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, ChaseSpeed * Time.deltaTime);
        }


        if (dist < AtkRange && !isAttacking && !isStunned)
        {
            Anim.SetBool("isMoving", false);
            Anim.SetBool("isAttacking", true);
            isAttacking = true;
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Anim.SetBool("isAttacking", false);
            Anim.SetBool("isMoving", false);
            Anim.SetBool("isIdling", false);
            Anim.SetTrigger("isDead");
            //drop loot
            Destroy(gameObject);
        }
    }

    public void Stun(float stunValue)
    {
        Anim.SetBool("isAttacking", false);
        Anim.SetBool("isMoving", false);
        Anim.SetBool("isIdling", false);
        isStunned = true;
        CurrentStunTime = stunValue;
        Anim.SetBool("isStunned", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isAttacking)
            Target.GetComponent<Player>().TakeDamage(Damage);
    }

    public void CalculateHeading()
    {
        heading = new Vector2(Target.position.x, Target.position.y);
        heading += Random.insideUnitCircle * 6;
    }

    public void AttackEnd()
    {
        Anim.SetBool("isAttacking", false);
        isAttacking = false;
        Speed = 0;
        Stun(3f);
        
    }
}
