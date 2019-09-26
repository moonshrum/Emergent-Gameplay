using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class Animal : MonoBehaviour
{
    public CircleCollider2D SearchRadius;
    private Transform _target = null;
    public int AtkRange;
    public float Speed;

    private Vector3 _snapshot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null) return;
        //transform.LookAt(_target);
        Vector2 heading = _target.position - transform.position;
        heading.Normalize();
        //Debug.Log(heading);
        if (Vector2.Distance(_target.position, transform.position) > AtkRange)
        {
            Speed = 2;
            heading = _snapshot - transform.position;
            heading += AddNoiseOnAngle(0, 90);
            heading.Normalize();
        }
        else
        {
            Speed = 5;
            heading = _target.position - transform.position;
        }
        transform.Translate(heading * Speed * Time.deltaTime, Space.World);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") _target = other.transform;
        _snapshot = other.transform.position;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform == _target) _target = null;
        Debug.Log("aaa");
    }

    Vector2 AddNoiseOnAngle(float min, float max)
    {
        // Find random angle between min & max inclusive
        var xNoise = Random.Range(min, max);
        var yNoise = Random.Range(min, max);

        // Convert Angle to Vector2
        var noise = new Vector2(
            Mathf.Sin(2 * Mathf.PI * xNoise / 360),
            Mathf.Sin(2 * Mathf.PI * yNoise / 360)
        );
        return noise;
    }

    void AcquireTarget(Transform enemy)
    {

    }
}
