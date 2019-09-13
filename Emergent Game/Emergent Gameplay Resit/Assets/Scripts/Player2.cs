using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public Player Instance;

    public int Health;
    public int Attack;
    public int Defense;

    public List<Resource> AllResources = new List<Resource>();

    private void Awake()
    {
        Instance = new Player();
        Health = Instance.Health;
        Attack = Instance.Attack;
        Defense = Instance.Defense;
        GeneratePlayerResources();
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

    public void CollectResource(Resource.ResourceType _type)
    {
        if (_type == Resource.ResourceType.Wood)
        {
            foreach (Resource resource in AllResources)
            {
                if (resource.Type == Resource.ResourceType.Wood)
                {
                    resource.IncreaseResource(5);
                }
            }
        }
        else if (_type == Resource.ResourceType.Rock)
        {
            foreach (Resource resource in AllResources)
            {
                if (resource.Type == Resource.ResourceType.Rock)
                {
                    resource.IncreaseResource(5);
                }
            }
        }
        else if (_type == Resource.ResourceType.Water)
        {
            foreach (Resource resource in AllResources)
            {
                if (resource.Type == Resource.ResourceType.Water)
                {
                    resource.IncreaseResource(5);
                }
            }
        }
    }
}
