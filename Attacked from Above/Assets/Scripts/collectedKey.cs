using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectedKey : MonoBehaviour
{
    
    // audio
    AudioSource audioSource;
    public AudioClip collectClip;

    void Start() {
        audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")) {
            // set pref
            PlayerPrefs.SetInt("coin", 1);
            audioSource.PlayOneShot(collectClip, .5f);

            // destroy and play sound
            Destroy(gameObject);

        }
    }
}
