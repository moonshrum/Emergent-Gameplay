using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchRadius : MonoBehaviour
{
    public Animal AnimalInterface;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") AnimalInterface.Target = other.transform;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform == AnimalInterface.Target) AnimalInterface.Target = null;
    }
}
