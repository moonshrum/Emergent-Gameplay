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
    [Header("Fill in if the challenge requires the player to collect certain amount of a particular resource")]
    //public bool Collect;
    public int AmountToCollect;
    public Resource.ResourceType TypeToCollect;
    [Space(25f)]
    [Header("Fill in if the challenge requires the player to kill someone")]
    public int AmountToKill;
    public Animal.AnimalType AnimalToKill;

}
