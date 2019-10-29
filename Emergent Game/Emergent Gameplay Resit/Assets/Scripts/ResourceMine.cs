using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceMine : MonoBehaviour
{
    public Resource.ResourceType Type;
    public bool WillBeDestroyed;
    public bool WillChangeSprite;
    public bool CanBeSetOnFire;
    [System.NonSerialized]
    public bool CanBeCollected = true;
    [Header("Assing if the mine needs to change sprite")]
    public Sprite SpriteToChangeTo;
}
