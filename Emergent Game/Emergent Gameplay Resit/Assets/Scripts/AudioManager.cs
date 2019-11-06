using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    //Pick Up
    public AudioClip pickUp;
    public AudioSource pickUpSource;
    //Dead
    public AudioClip dead;
    public AudioSource deadSource;
    //Night Time
    public AudioClip nightTime;
    public AudioSource nightTimeSource;
    //Sword Attack
    public AudioClip swordAttack;
    public AudioSource swordAttackSource;
    //Win round
    public AudioClip roundWin;
    public AudioSource roundWinSource;
    //Chop
    public AudioClip chop;
    public AudioSource chopSource;
    //Stone Hit
    public AudioClip stoneHit;
    public AudioSource stoneHitSource;
    //Burning
    public AudioClip fireCrackle;
    public AudioSource fireCrackleSource;
    //Select/Button
    public AudioClip button;
    public AudioSource buttonSource;
    //Craft
    public AudioClip craft;
    public AudioSource craftSource;
    //Bear eats poison berries
    public AudioClip bearSick;
    public AudioSource bearSickSource;
    //Bear attack (player is in attack radius)
    public AudioClip bearAttack;
    public AudioSource bearAttackSource;
    //Footsteps player 1
    public AudioClip footstepsP1;
    public AudioSource footstepsP2;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
