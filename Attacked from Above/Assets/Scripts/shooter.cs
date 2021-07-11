using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{
    public float startPauseTime = 2f;
    public float pauseTime = 1f;
    public float destroyTime = 10f;

    public float spawnX = 9.85f;
    public float spawnY = 6.23f;
    public float spawnZ = 0f;

    public bool pause = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Shoot");
    }

    IEnumerator Shoot() {
        // stall for 2 seconds
        yield return new WaitForSeconds(startPauseTime);

        while (!pause) {
            // create new object
            GameObject enemyShip = (GameObject)Instantiate(Resources.Load("Prefabs/laser"));
            enemyShip.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            
            // destroys object after 10 seconds
            Destroy(enemyShip, destroyTime);

            yield return new WaitForSeconds(pauseTime);
        }
    }
}
