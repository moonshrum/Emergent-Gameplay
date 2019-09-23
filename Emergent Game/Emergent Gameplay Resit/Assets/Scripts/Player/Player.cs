using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    public int Health = 100;
    public int Attack = 10;
    public int Defense = 10;
    public int Wood = 0;
    public int Water = 0;
    public int Rock = 0;
    public float MovementSpeed = 10;

    [Header("Does not need reference")]
    public ResourceMine NearbyResourceMine;

    [Header("Needs reference")]
    public GameObject Shop;



    [System.NonSerialized]
    public List<Resource> AllResources = new List<Resource>();
    [System.NonSerialized]
    public Inventory Inventory;
    //public Shop Shop;
    private void Awake()
    {
        GeneratePlayerResources();
        Inventory = new Inventory();
        //Shop = new Shop();
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
        Resource WaterResource = new Resource(0, Resource.ResourceType.Water);
        AllResources.Add(WaterResource);
        Resource RockResource = new Resource(0, Resource.ResourceType.Rock);
        AllResources.Add(RockResource);
    }
    public void GenerateInventory()
    {
        Inventory = new Inventory();
    }
    public void CollectResource(ResourceMine mine)
    {
        if (mine.Type == Resource.ResourceType.Wood)
        {
            foreach (Resource resource in AllResources)
            {
                if (resource.Type == Resource.ResourceType.Wood)
                {
                    resource.IncreaseResource(mine.ResourceAmount);
                }
            }
        }
        else if (mine.Type == Resource.ResourceType.Rock)
        {
            foreach (Resource resource in AllResources)
            {
                if (resource.Type == Resource.ResourceType.Rock)
                {
                    resource.IncreaseResource(mine.ResourceAmount);
                }
            }
        }
        else if (mine.Type == Resource.ResourceType.Water)
        {
            foreach (Resource resource in AllResources)
            {
                if (resource.Type == Resource.ResourceType.Water)
                {
                    resource.IncreaseResource(mine.ResourceAmount);
                }
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
    public void ToggleShop()
    {
        Shop.SetActive(!Shop.activeSelf);
    }
}
