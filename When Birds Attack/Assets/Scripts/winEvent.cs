using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winEvent : MonoBehaviour
{
    public GameObject fog;
    public float startDistance = 0f;
    public float endDistance = 8f;
    // Movement speed in units per second.
    public float speed = 8.0f;
    
    // Time when the movement started.
    private float startTime;

    bool hasSeen;
    void Start()
    {
        fog.transform.position = new Vector3(0, startDistance, 0);

        startTime = Time.time;
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / (startDistance-endDistance);

        if (fractionOfJourney > 1.5f) {
            // load new scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        fog.transform.position = Vector3.Lerp(new Vector3(0, endDistance, 0), new Vector3(0, startDistance, 0), fractionOfJourney);
    }
}
