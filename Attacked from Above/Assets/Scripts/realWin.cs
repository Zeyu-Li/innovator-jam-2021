using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class realWin : MonoBehaviour
{
    
    public GameObject winScreen;
    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")) {
            // fade to white then show win screen
            winScreen.SetActive(true);
        }
    }
}
