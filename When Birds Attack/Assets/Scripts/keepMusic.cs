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

        DontDestroyOnLoad(this.gameObject);
    }
}
