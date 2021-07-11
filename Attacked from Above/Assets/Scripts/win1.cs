using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win1 : MonoBehaviour
{
    public GameObject winEvent;
    AudioSource audioSource;
    public AudioClip winAudioClip;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")) {
            winEvent.SetActive(true);
            
            // play sound
            audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
            audioSource.PlayOneShot(winAudioClip, .5f);
        }
    }
}
