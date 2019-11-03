using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using UnityEngine;
using UnityEngine.XR.WSA.Input;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    public enum AnimalType { Bear, Crab , Any, None, Type };
    public AnimalType Type;
    public Transform Target = null;

    [Header("Base Stats")]
    public int HealthMax = 200;
    public int Health;
    public int Damage = 50;
    public int AtkRange;
    public int ChaseRange;
    public float SearchSpeed = 2;
    public float ChaseSpeed = 5;
    public float AttackSpeed = 10;

    [Header("Do not change")]
    public float Speed;
    public Image HealthBarRender1;
    public Image HealthBarRender2;
    public Slider HealthBar;
    public Animator Anim;

    public float CurrentStunTime;
    public bool isAttacking = false;
    public bool isStunned = false;

    public GameObject skinDrop;
    public GameObject meatDrop;

    private BoxCollider2D _hurtBox;
    Vector2 heading;
    float time;
    float stunTime = 0;
    private bool _facingRight;
    private bool _isDead = false;
    public Player PlayerHit;

    public bool inHerd = false;
    private bool _isRetreat = false;

    // Start is called before the first frame update
    void Start()
    {
        _hurtBox = gameObject.GetComponent<BoxCollider2D>();
        HealthBarRender1.enabled = false;
        HealthBarRender2.enabled = false;
        Health = HealthMax;
    }

    // Update is called once per frame
    void Update()
    {
        float dist;
        HealthBar.value = Health;

        if (Health <= HealthMax / 2 && !_isRetreat)
        {
            StartCoroutine(Retreat());
        }

        if (isStunned)
        {
            stunTime -= Time.deltaTime;
            Anim.SetBool("isIdling", true);
            transform.position = Vector2.MoveTowards(transform.position, transform.position, 0 * Time.deltaTime);
            if (stunTime <= 0)
            {
                isStunned = false;
                Anim.SetBool("isIdling", false);
            }
        }        
        else if (!_isDead && !_isRetreat)
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
                StartCoroutine(IdleRoutine(Random.Range(1, 4), SearchSpeed));
                transform.position = Vector2.MoveTowards(transform.position, heading, 0 * Time.deltaTime);               
                return;
            }
            else
            {
                StopCoroutine(IdleRoutine(Random.Range(1, 4), SearchSpeed));
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
            }
        }
        else if (!_isDead && Health <= 49)
        {
            transform.position = -Vector2.MoveTowards(transform.position, Target.transform.position, ChaseSpeed * Time.deltaTime);
        }

        else if (!_isDead && _isRetreat)
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
                Anim.SetBool("isMoving", false);
                Anim.SetBool("isIdling", true);
                transform.position = Vector2.MoveTowards(transform.position, heading, 0 * Time.deltaTime);                
                return;
            }
            else
            {
                Anim.SetBool("isIdling", false);
                dist = Vector2.Distance(transform.position, Target.position);
                Anim.SetBool("isMoving", true);
                transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, ChaseSpeed * Time.deltaTime);
            }

            if (dist < AtkRange && !isAttacking)
            {
                Anim.SetBool("isMoving", false);
                Anim.SetBool("isAttacking", true);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (_isDead) return;
        if (Health < HealthMax)
        {
            HealthBarRender1.enabled = true;
            HealthBarRender2.enabled = true;
        }
        Health -= damage;

        if (Health <= 0)
        {
            Anim.SetBool("isAttacking", false);
            Anim.SetBool("isMoving", false);
            Anim.SetBool("isIdling", false);
            Anim.SetTrigger("isDead");

            ChallengesManager.Instance.CheckForChallenge(Type, PlayerHit);
            _isDead = true;
            transform.position = Vector2.MoveTowards(transform.position, transform.position, 0 * Time.deltaTime);
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

    public void Idle()
    {
        heading = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
        heading += Random.insideUnitCircle * Random.Range(1, 5);
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

    private void SetAttack()
    {
        isAttacking = true;
    }

    private void CleanUp()
    {
        var dropCheck = Random.Range(0, 1);

        if (dropCheck <= 49)
        {
            GameObject newMeat = Instantiate(meatDrop, transform.position, Quaternion.identity) as GameObject;
        }
        if (dropCheck <= 74)
        {
            GameObject newSkin = Instantiate(skinDrop, transform.position, Quaternion.identity) as GameObject;
        }

        Destroy(gameObject);
    }

    public IEnumerator Retreat()
    {
        _isRetreat = true;
        if (Type == AnimalType.Bear)
        {
            while (Target != null)
            {
                transform.position = -Vector2.MoveTowards(transform.position, Target.transform.position, ChaseSpeed * Time.deltaTime);
            }
        }
        else
        {
            StartCoroutine(IdleRoutine(0, ChaseSpeed * 2));
            while (Target != null)
            {
                
            }
            StopCoroutine(IdleRoutine(0, ChaseSpeed * 2));
        }
        
        yield return new WaitForSeconds(0f);
    }

    public IEnumerator IdleRoutine(int rate, float speed)
    {
        Idle();
        while (true)
        {
            Anim.SetBool("isIdling", false);
            Anim.SetBool("isMoving", true);
            transform.position = Vector2.MoveTowards(transform.position, heading, speed * Time.deltaTime);
            Debug.Log(heading);
            if (new Vector2(transform.position.x, transform.position.y) == heading)
            {
                break;
            }           
        }
        Anim.SetBool("isMoving", false);
        Anim.SetBool("isIdling", true);
        transform.position = Vector2.MoveTowards(transform.position, heading, 0 * Time.deltaTime);
        yield return new WaitForSeconds(rate);
    }
}
