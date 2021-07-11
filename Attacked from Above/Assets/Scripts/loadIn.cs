using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadIn : MonoBehaviour
{
    public GameObject fog;
    public float startDistance = 7.43f;
    public float endDistance = 0f;
    // Movement speed in units per second.
    public float speed = 1.0f;
    
    // Time when the movement started.
    private float startTime;

    bool hasSeen;
    bool done = false;
    void Start()
    {
        hasSeen = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name) == 0;
        if (hasSeen)
            fog.transform.position = new Vector3(0, startDistance, 0);

        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // if transition has not been seen before, play it
        if (hasSeen && !done) {
            // set transition seen to true
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
            
            float distCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distCovered / (startDistance-endDistance);

            if (fractionOfJourney > 1.0f)
                done = true;
            
            fog.transform.position = Vector3.Lerp(new Vector3(0, startDistance, 0), new Vector3(0, endDistance, 0), fractionOfJourney);
        }
        
    }
}
