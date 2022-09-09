using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private int spawnLimitXLeft = -22;
    private int spawnLimitXRight = 7;
    private int spawnPosY = 30;

    public float startDelay = 1;
    public float spawnInterval = 6;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRandomBall", startDelay);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        //spawnInterval = Random.Range(0.65f, 2);

        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[Random.Range(0, 3)], spawnPos, ballPrefabs[Random.Range(0,2)].transform.rotation);

        //spawnInterval = Random.Range(3, 5);
        Invoke("SpawnRandomBall", spawnInterval);
    }

}
