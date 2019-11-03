using UnityEngine;

public class ResourceDrop : MonoBehaviour
{
    public Resource.ResourceType Type;
    public Resource.ResourceType Type2;
    public bool CanBeSetOnFire;
    public bool IsOnFire;
    public bool Consubamle;
    public Resource.EffectOnPlayer EffectOnPlayer;
    public int Amount = 1;
    [System.NonSerialized]
    public Sprite InstructionSprite;

    private void Awake()
    {
        InstructionSprite = Resources.Load<Sprite>("Pick Up Icon");
        transform.Find("Instructions Image").GetComponent<SpriteRenderer>().sprite = InstructionSprite;
    }
}
