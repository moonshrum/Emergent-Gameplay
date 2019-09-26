using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    public int Health = 100;
    public int Attack = 10;
    public int Defense = 10;
    public int Wood = 0;
    public int AnimalSkin = 0;
    public int Stone = 0;
    public int Cloth = 0;
    public int GoldOre = 0;
    public int IronOre = 0;
    public float MovementSpeed = 10;
    public bool IsShopOpen = false;

    [Header("Does not need reference")]
    public ResourceMine NearbyResourceMine;

    [Header("Needs reference")]
    public GameObject Shop;
    public Animator Anim;


    [System.NonSerialized]
    public List<Resource> AllResources = new List<Resource>();
    [System.NonSerialized]
    public Inventory Inventory;
    private void Awake()
    {
        GeneratePlayerResources();
        Inventory = new Inventory();
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

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
    public void GeneratePlayerResources()
    {
        Resource WoodResource = new Resource(0, Resource.ResourceType.Wood);
        AllResources.Add(WoodResource);
        Resource StoneResource = new Resource(0, Resource.ResourceType.Stone);
        AllResources.Add(StoneResource);
        Resource AnimalSkinResource = new Resource(0, Resource.ResourceType.AnimalSkin);
        AllResources.Add(AnimalSkinResource);
        Resource GoldOreResource = new Resource(0, Resource.ResourceType.GoldOre);
        AllResources.Add(GoldOreResource);
        Resource IronOreResource = new Resource(0, Resource.ResourceType.IronOre);
        AllResources.Add(IronOreResource);
        Resource ClothResource = new Resource(0, Resource.ResourceType.Cloth);
        AllResources.Add(ClothResource);
    }
    public void GenerateInventory()
    {
        Inventory = new Inventory();
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
