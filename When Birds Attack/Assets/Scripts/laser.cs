using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public float speed = 5f;
    // audio
    public AudioSource audioSource;
    public AudioClip audioClip;

    Rigidbody rb;
    Vector3 tmp;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * -speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Ground")) {   
            // destroy item + sound
            audioSource.PlayOneShot(audioClip, 1f);
            Destroy(gameObject);
        } else if (collision.gameObject.CompareTag("Player")) {
            // decrease player health
        }
    }
}
