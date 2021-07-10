using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthManager : MonoBehaviour
{
    public int health = 2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0) {
            // death screen
        }
    }
}
