using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health;
    public int Damage;
    public int AttackRange;
    public int NoticeRange;
    public enum EnemySate { Idle, Walking, Attacking};
    public EnemySate State;

    private List<Transform> _targets = new List<Transform>();

    private void Start()
    {
        _targets.Add(Player1.Instance.transform);
        _targets.Add(Player2.Instance.transform);
    }

    public void ChangeState(EnemySate state)
    {
        State = state;
    }

    private void FixedUpdate()
    {
        switch (State)
        {
            case EnemySate.Idle:
                LookForPlayer();
                break;
            case EnemySate.Walking:
                break;
            case EnemySate.Attacking:
                break;
        }
    }

    private Transform LookForPlayer()
    {
        float distance1 = Vector3.Distance(transform.position, _targets[0].position);
        float distance2 = Vector3.Distance(transform.position, _targets[1].position);

        if (distance1 < NoticeRange)
        {
            return _targets[0];
        } else if (distance2 < NoticeRange)
        {
            return _targets[1];
        } else
        {
            return null;
        }
    }
}
