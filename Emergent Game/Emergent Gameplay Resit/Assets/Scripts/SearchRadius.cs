using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchRadius : MonoBehaviour
{
    public Animal AnimalInterface;
    private Transform[] nearbyCreatures;
    Transform tMin = null;

    void Update()
    {
        float minDist = Mathf.Infinity;
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 20);
        Vector3 currentPos = transform.position;
        foreach (Collider2D hit in hits)
        {
            float dist = Vector3.Distance(hit.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = hit.transform;
                minDist = dist;
            }
        }

        AnimalInterface.Target = tMin;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.GetComponent<Player>() != null) AnimalInterface.Target = other.transform;

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform == AnimalInterface.Target) AnimalInterface.Target = null;
    }

    Transform GetClosestObject(Transform[] obj)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform t in obj)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }
}
