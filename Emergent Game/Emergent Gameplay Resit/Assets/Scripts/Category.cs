﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Category : MonoBehaviour
{
    public string CategoryName;
    public List<Item> CategoryItems = new List<Item>();
    public GameObject ItemsContainer;
    


    private void Awake()
    {
        InstantiateItemPrefabsInTheContainer();
    }

    public void InstantiateItemPrefabsInTheContainer()
    {
        foreach (Item item in CategoryItems)
        {
            GameObject itemPrefab = Instantiate(FindObjectOfType<Shop>().ItemPrefab, ItemsContainer.transform);
        }
    }
}
