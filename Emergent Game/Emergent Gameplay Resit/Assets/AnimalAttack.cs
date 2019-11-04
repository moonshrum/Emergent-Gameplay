using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAttack : MonoBehaviour
{
    public Animal AnimalInterface;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (AnimalInterface.Target.GetComponent<Player>() != null)
            AnimalInterface.Target.GetComponent<Player>().TakeDamage(AnimalInterface.Damage);
        else
            AnimalInterface.Target.GetComponent<Animal>().TakeDamage(AnimalInterface.Damage);
    }
}
