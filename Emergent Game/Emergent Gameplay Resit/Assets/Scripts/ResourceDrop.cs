using UnityEngine;

public class ResourceDrop : MonoBehaviour
{
    public Resource.ResourceType Type;
    public bool CanBeSetOnFire;
    public bool IsOnFire;
    public bool Consubamle;
    public Resource.EffectOnPlayer EffectOnPlayer;
    public int Amount;
    public int DefaultAmount = 10;
    [System.NonSerialized]
    public Sprite InstructionSprite;

    private void Awake()
    {
        InstructionSprite = Resources.Load<Sprite>("Pick Up Icon");
        transform.Find("Intructions Image").GetComponent<SpriteRenderer>().sprite = InstructionSprite;
    }
}
