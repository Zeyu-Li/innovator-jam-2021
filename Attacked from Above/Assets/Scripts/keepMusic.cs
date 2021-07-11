using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepMusic : MonoBehaviour
{
    public string destroy = "";

    // Start is called before the first frame update
    void Start()
    {
        // destroy previous song
        if (destroy != "") {
            try {
                Destroy(GameObject.Find(destroy));
            } catch {
                ;
            }
        }

        // if already loaded
        if (GameObject.FindGameObjectsWithTag("NewMusic").Length <= 1) {
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }
    }
}
