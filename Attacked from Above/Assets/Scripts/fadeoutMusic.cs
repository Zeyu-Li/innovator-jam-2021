using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeoutMusic : MonoBehaviour
{
    public GameObject newMusic;
    private GameObject previousMusic;
    private AudioSource music;
    public string previousMusicName = "StartMusic";

    // Start is called before the first frame update
    void Start()
    {
        try {
            previousMusic = GameObject.Find(previousMusicName);
            music = previousMusic.GetComponent<AudioSource>();
            StartCoroutine("FadeOut");
        } catch {
            newMusic.SetActive(true);
        }
    }

    private IEnumerator FadeOut(){
        float speed = 0.08f;
        // Debug.Log(music.volume);
        while (music.volume > 0.2){
            music.volume -= speed;
            yield return new WaitForSeconds(0.1f);
        }

        newMusic.SetActive(true);
    }
}
