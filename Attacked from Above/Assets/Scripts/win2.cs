using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class win2 : MonoBehaviour
{
    public float FadeRate = .5f;
    private Image image;
    
    void Start() {
        this.image = this.GetComponent<Image>();
    }

    void Update() {
        Color curColor = this.image.color;
        float alphaDiff = Mathf.Abs(curColor.a-.95f);
        if (alphaDiff>0.0001f) {
            curColor.a = Mathf.Lerp(curColor.a, .95f, this.FadeRate*Time.deltaTime);
            this.image.color = curColor;
        }
    }
}
