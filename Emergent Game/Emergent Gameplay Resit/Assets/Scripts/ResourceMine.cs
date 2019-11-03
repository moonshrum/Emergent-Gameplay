using UnityEngine;

public class ResourceMine : MonoBehaviour
{
    public Resource.ResourceType Type;
    public Item.ItemType NeededItem;
    public bool WillBeDestroyed;
    public bool WillChangeSprite;
    public bool CanBeSetOnFire;
    public bool ConsumableDrop;
    public Resource.EffectOnPlayer EffectOnPlayer;
    [System.NonSerialized]
    public bool IsOnFire;
    [System.NonSerialized]
    public bool CanBeCollected = true;
    [Header("Assing if the mine needs to change sprite")]
    public Sprite SpriteToChangeTo;
    [System.NonSerialized]
    public Sprite InstructionSprite;

    private void Awake()
    {
        InstructionSprite = Resources.Load<Sprite>("Interact Icon");
        transform.Find("Intructions Image").GetComponent<SpriteRenderer>().sprite = InstructionSprite;
    }
}
