using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winLast : MonoBehaviour
{
    public GameObject winEvent;
    public GameObject winScreen;

    void Start()
    {
        // check extra coin got
        try {
            if (PlayerPrefs.GetInt("coin") == 1) {
                // special level
                winEvent.SetActive(true);
            } else {
                // end screen
                winScreen.SetActive(true);
            }
        } catch {
            ;
        }
    }
}
