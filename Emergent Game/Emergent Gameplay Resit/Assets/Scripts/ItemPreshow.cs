﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPreshow : MonoBehaviour
{
    private float _roatationSpeed = 5;
    private void Update()
    {
        transform.Rotate(Vector3.up * (_roatationSpeed * Time.deltaTime));
    }
}
