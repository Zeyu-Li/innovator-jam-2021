using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour
{
    public GameObject winEvent;
    public Image image;

    void Start() {
        image.gameObject.SetActive(false);
    }

    public void play() {
        winEvent.SetActive(true);
        
        image.gameObject.SetActive(true);
        image.GetComponent<CanvasRenderer>().SetAlpha(0f);
        image.CrossFadeAlpha(1f, 0.1f, false);
    }

    public void quit() {
        Application.Quit();
    }
}
