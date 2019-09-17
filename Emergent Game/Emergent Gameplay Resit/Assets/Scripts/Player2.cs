using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : Player
{
    public static Player2 Instance;
    PlayerInputs input;

    public List<Resource> AllResources = new List<Resource>();
    public Inventory Inventory;

    public float speed;
    private Rigidbody2D rb;
    private Vector2 mv;
    private Vector2 rv;

    private void Awake()
    {
        GeneratePlayerResources();
        Inventory = new Inventory();

        rb = GetComponent<Rigidbody2D>();

        input = new PlayerInputs();

        input.Player2.Move.performed += ctx => mv = ctx.ReadValue<Vector2>();
        input.Player2.Move.canceled += ctx => mv = Vector2.zero;

        input.Player2.Rotate.performed += ctx => rv = ctx.ReadValue<Vector2>();
        input.Player2.Rotate.canceled += ctx => rv = Vector2.zero;
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

    void Update()
    {
        Vector2 m = new Vector2(-mv.x, mv.y) * Time.deltaTime;
        transform.Translate(m, Space.World);

        Vector2 r = new Vector2(-rv.x, -rv.y) * 100f * Time.deltaTime;
        transform.Rotate(r, Space.World);
    }
}
