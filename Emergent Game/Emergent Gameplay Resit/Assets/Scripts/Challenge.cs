using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Challenge", menuName = "Challenges/Challenge")]
public class Challenge : ScriptableObject
{
    public enum ChallengeType { ResourceCollection, Killing};
    public ChallengeType Type;
    [Tooltip("Text that will be shown in the Challenge Announcement")]
    public string TextToAnnounce;
    [System.NonSerialized]
    public bool Complete;
    [Tooltip("Write down the amount that the player needs to collect or kill")]
    public int AmountToCollectOrKill;
    [Space(25f)]
    [Header("Fill in if the challenge requires the player to collect certain amount of a particular resource")]
    //public bool Collect;
    public Resource.ResourceType TypeToCollect;
    [System.NonSerialized]
    public int AmountCollected;
    [Space(25f)]
    [Header("Fill in if the challenge requires the player to kill someone")]
    //public int AmountToKill;
    public Animal.AnimalType AnimalToKill;

}
