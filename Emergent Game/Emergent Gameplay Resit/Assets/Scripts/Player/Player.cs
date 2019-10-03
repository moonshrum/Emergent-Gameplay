using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player: MonoBehaviour
{
    public int Health = 100;
    public int Attack = 10;
    public int Defense = 10;
    public float MovementSpeed = 10;
    public bool IsShopOpen = false;
    public bool IsInvToggled = false;

    [Header("Does not need reference")]
    public ResourceMine NearbyResourceMine;
    public ResourceDrop NearbyResourceDrop;

    [Header("Needs reference")]
    public GameObject Shop;
    public GameObject Inventory;
    public Animator Anim;
    public Slider HealthBar;

    [SerializeField]
    public List<Resource> AllResources = new List<Resource>();

    public Animator AtkRef;


    private void Awake()
    {
        //GeneratePlayerResources();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "ResourceMine")
        {
            NearbyResourceMine = col.GetComponent<ResourceMine>();
        }
        if (col.transform.tag == "Resource Drop")
        {
            NearbyResourceDrop = col.GetComponent<ResourceDrop>();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.tag == "ResourceMine")
        {
            NearbyResourceMine = null;
        }
    }

    public void AttackTarget()
    {
        AtkRef.SetTrigger("Attack");
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            //play death animation
            //open game over screen
            Destroy(gameObject);
        }
    }
    public void CollectResource(ResourceMine mine)
    {
        foreach (Resource resource in AllResources)
        {
            if (mine.Type == resource.Type)
            {
                resource.IncreaseResource(mine.ResourceAmount);
            }
        }
    }
    public void CollectMine()
    {
        if (NearbyResourceMine != null)
        {
            CollectResource(NearbyResourceMine);
        }
        else
        {
            Debug.LogError("No Mine Nearby");
        }
    }
    public void PickUpDrop()
    {
        if (NearbyResourceDrop != null)
        {
            InvSlotContent inventorySlot = new InvSlotContent(NearbyResourceDrop, NearbyResourceDrop.Amount);
            Inventory.GetComponent<Inventory>().AddItem(inventorySlot);
        }
        else
        {
            Debug.LogError("No ResourceDrop Nearby");
        }
    }
    public void ToggleShop()
    {
        Shop.SetActive(!Shop.activeSelf);
        IsShopOpen = !IsShopOpen;
    }
}
