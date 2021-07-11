using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class quit1 : MonoBehaviour
{
    void Start() {
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // change escape to any other character if you like 
        {
            Application.Quit();
        } else if (Input.GetKeyDown(KeyCode.R)) // change escape to any other character if you like 
        {
            Time.timeScale = 1f;
            // destroy music
            try {
                Destroy(GameObject.Find("Music"));
            } catch {
                ;
            }
            SceneManager.LoadScene(0);
        }
    }
}
