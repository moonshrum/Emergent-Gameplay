﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDrop : MonoBehaviour
{
    public Resource.ResourceType Type;
    public bool CanBeSetOnFire;
    public int Amount;
    public int DefaultAmount = 10;
}
