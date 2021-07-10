using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public float speed = 5f;
    // audio
    AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip hurtClip;

    Rigidbody rb;
    Vector3 tmp;
    GameObject healthManager;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * -speed;
        // find auto source
        audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Ground")) {   
            // destroy item + sound
            audioSource.PlayOneShot(audioClip, 1f);
            Destroy(gameObject);
        } else if (collision.gameObject.CompareTag("Player")) {
            // decrease player health
            healthManager = GameObject.Find("HealthManager");
            healthManager.GetComponent<healthManager>().health -= 1;

            // play sound and destroy
            audioSource.PlayOneShot(hurtClip, 1f);
            Destroy(gameObject);
        }
    }
}
