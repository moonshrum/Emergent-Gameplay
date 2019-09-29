using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player: MonoBehaviour
{
    public int Health = 100;
    public int Attack = 10;
    public int Defense = 10;
    /*public int Wood = 0;
    public int AnimalSkin = 0;
    public int Stone = 0;
    public int Cloth = 0;
    public int GoldOre = 0;
    public int IronOre = 0;*/
    public float MovementSpeed = 10;
    public bool IsShopOpen = false;

    [Header("Does not need reference")]
    public ResourceMine NearbyResourceMine;

    [Header("Needs reference")]
    public GameObject Shop;
    public GameObject Inventory;
    public Animator Anim;
    public Slider HealthBar;

    [System.NonSerialized]
    public List<Resource> AllResources = new List<Resource>();

    public Animator AtkRef;


    private void Awake()
    {
        GeneratePlayerResources();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "ResourceMine")
        {
            NearbyResourceMine = col.GetComponent<ResourceMine>();
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
    public void GeneratePlayerResources()
    {
        Resource WoodResource = new Resource(0, Resource.ResourceType.Wood);
        AllResources.Add(WoodResource);
        Resource StoneResource = new Resource(0, Resource.ResourceType.Stone);
        AllResources.Add(StoneResource);
        Resource AnimalSkinResource = new Resource(100, Resource.ResourceType.AnimalSkin);
        AllResources.Add(AnimalSkinResource);
        Resource GoldOreResource = new Resource(0, Resource.ResourceType.GoldOre);
        AllResources.Add(GoldOreResource);
        Resource IronOreResource = new Resource(100, Resource.ResourceType.IronOre);
        AllResources.Add(IronOreResource);
        Resource ClothResource = new Resource(0, Resource.ResourceType.Cloth);
        AllResources.Add(ClothResource);
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
        /*if (mine.Type == Resource.ResourceType.Wood)
        {
            foreach (Resource resource in AllResources)
            {
                if (resource.Type == Resource.ResourceType.Wood)
                {
                    resource.IncreaseResource(mine.ResourceAmount);
                }
            }
        }
        else if (mine.Type == Resource.ResourceType.AnimalSkin)
        {
            foreach (Resource resource in AllResources)
            {
                if (resource.Type == Resource.ResourceType.AnimalSkin)
                {
                    resource.IncreaseResource(mine.ResourceAmount);
                }
            }
        }
        else if (mine.Type == Resource.ResourceType.Stone)
        {
            foreach (Resource resource in AllResources)
            {
                if (resource.Type == Resource.ResourceType.Stone)
                {
                    resource.IncreaseResource(mine.ResourceAmount);
                }
            }
        }*/
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
    public void ToggleShop()
    {
        Shop.SetActive(!Shop.activeSelf);
        IsShopOpen = !IsShopOpen;
    }
}
