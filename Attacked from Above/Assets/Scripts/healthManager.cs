﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthManager : MonoBehaviour
{
    public int health = 2;

    public GameObject firstHeart;
    public GameObject secondHeart;
    public GameObject gameOverUI;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 1) {
            secondHeart.SetActive(false);
        } else if (health == 0) {
            // death screen
            firstHeart.SetActive(false);
            gameOverUI.SetActive(true);
        }
    }
}
