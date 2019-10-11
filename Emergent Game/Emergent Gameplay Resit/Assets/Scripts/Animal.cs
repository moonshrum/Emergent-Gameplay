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
    float stunTime = 0;
    private bool _facingRight;

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

        if (isStunned)
        {
            stunTime -= Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, transform.position, 0 * Time.deltaTime);
            if (stunTime <= 0)
            {
                isStunned = false;
                Anim.SetBool("isIdling", false);
            }
        }
        else
        {
            if (Target != null && Target.position.x < transform.position.x && _facingRight)
            {
                FlipCharacter("Left");
            }
            else if (Target != null && Target.position.x > transform.position.x && !_facingRight)
            {
                FlipCharacter("Right");
            }

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

            if (dist > ChaseRange)
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

            if (dist < ChaseRange && dist > AtkRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, ChaseSpeed * Time.deltaTime);
            }


            if (dist < AtkRange && !isAttacking)
            {
                Anim.SetBool("isMoving", false);
                Anim.SetBool("isAttacking", true);
                isAttacking = true;
            }
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
        Anim.SetBool("isIdling", true);

        stunTime = stunValue;
        isStunned = true;
        //Anim.SetBool("isStunned", true);
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
        isAttacking = false;
        Speed = 0;
        Stun(1.5f);       
    }

    private void FlipCharacter(string side)
    {
        if (side == "Left")
        {
            _facingRight = false;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (side == "Right")
        {
            _facingRight = true;
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
}
