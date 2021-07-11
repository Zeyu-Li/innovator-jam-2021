using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour
{
    public GameObject winEvent;
    public GameObject shooter;
    public GameObject healthManger;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")) {
            shooter.GetComponent<shooter>().pause = true;
            // set to negative one so player cannot die
            healthManger.GetComponent<healthManager>().health = -1;
            winEvent.SetActive(true);
        }
    }
}
