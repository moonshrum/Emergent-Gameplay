﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRenderScript : MonoBehaviour
{
    [SerializeField]
    private int sortingOrderBase = 3;
    [SerializeField]
    private int offset = 0;
    [SerializeField]
    private bool runOnlyOnce = false;

    private float timer;
    private float timerMax = .1f;
    private Renderer myRenderer;

    // Start is called before the first frame update
    private void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = timerMax;
            myRenderer.sortingOrder = (int)(sortingOrderBase - transform.position.y - offset);
            if (runOnlyOnce)
            {
                Destroy(this);
            }
        }
    }
}
