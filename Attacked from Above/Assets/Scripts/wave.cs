using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave : MonoBehaviour
{
    public float speed = 5f;
    public float volume = .4f;
    // audio
    AudioSource audioSource;
    public AudioClip hurtClip;

    Rigidbody rb;
    GameObject healthManager;
    public bool invincible = false;
    public float invincibleTime = 2f;
    float time;
    float timer;
    void Start()
    {
        // find auto source
        audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    void Update() {
        if (invincible) {
            timer += Time.deltaTime;
            if (timer - time > invincibleTime)
                invincible = false;
        }
    }

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player") && !invincible) {
            // decrease player health
            healthManager = GameObject.Find("HealthManager");
            healthManager.GetComponent<healthManager>().health -= 1;

            // play sound and destroy
            audioSource.PlayOneShot(hurtClip, volume);
            // Destroy(gameObject);
            invincible = true;
            time = Time.time;
            timer = time;
        }
    }
}
