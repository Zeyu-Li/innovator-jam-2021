using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class quit : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // change escape to any other character if you like 
        {
            Application.Quit();
        } else if (Input.GetKeyDown(KeyCode.R)) // change escape to any other character if you like 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    
    }
}
