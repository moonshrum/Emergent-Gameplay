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
        Debug.Log(hits);
        Vector3 currentPos = transform.position;
        foreach (Collider2D hit in hits)
        {
            float dist = Vector2.Distance(hit.transform.position, currentPos);
            if (hit.GetComponent<Animal>() != null)
            {
                if (hit.GetComponent<Animal>().Type != AnimalInterface.Type)
                {
                    if (dist < minDist)
                    {
                        tMin = hit.transform;
                        minDist = dist;
                    }
                }
            }
            else if (hit.GetComponent<Player>() != null)
            {
                if (dist < minDist)
                {
                    tMin = hit.transform;
                    minDist = dist;
                }
            }
            else
            {
                //tMin = null;
            }
        }
        AnimalInterface.Target = tMin;
        Debug.Log(AnimalInterface.Target);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        //if (other.GetComponent<Player>() != null) AnimalInterface.Target = other.transform;

    }

    void OnTriggerExit2D(Collider2D other)
    {
        //if (other.transform == AnimalInterface.Target) AnimalInterface.Target = null;
    }

    /*Transform GetClosestObject(Transform[] obj)
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
    }*/
}
