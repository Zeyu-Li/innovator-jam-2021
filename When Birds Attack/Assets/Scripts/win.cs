using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour
{
    public GameObject winEvent;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")) {        
            winEvent.SetActive(true);
        }
    }
}
