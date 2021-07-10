using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadIn : MonoBehaviour
{
    public GameObject fog;
    public float startDistance = 7.43f;
    public float endDistance = 0f;
    // Movement speed in units per second.
    public float speed = 1.0f;
    
    // Time when the movement started.
    private float startTime;
    void Start()
    {
        fog.transform.position = new Vector3(0, startDistance, 0);
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / (startDistance-endDistance);
        fog.transform.position = Vector3.Lerp(new Vector3(0, startDistance, 0), new Vector3(0, endDistance, 0), fractionOfJourney);
        
    }
}
