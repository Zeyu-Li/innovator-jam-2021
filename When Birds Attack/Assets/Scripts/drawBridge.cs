using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawBridge : MonoBehaviour
{
    public GameObject brigdeObject;

    public bool bridgeDrawn = false;
    public bool doneDrawn = false;
    public float speed = 8.0f;

    // Time when the movement started.
    private float startTime;

    Vector3 initialPosition;
    void Start() {
        initialPosition = brigdeObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (bridgeDrawn && !doneDrawn) {
            float distCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distCovered / (11);

            if (fractionOfJourney > 1) 
                doneDrawn = true;

            brigdeObject.transform.position = Vector3.Lerp(initialPosition + new Vector3(0, 0, 0), initialPosition + new Vector3(0, 11, 0), fractionOfJourney);

        }
    }

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")) {
            bridgeDrawn = true;
            startTime = Time.time;
            // play sound?

        }
    }
}
