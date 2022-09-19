using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    PlayerController playerController;
    public GameObject playerControllerScript;

    public GameObject enemyPrefab;
    public int spawnRange = 9;
    public int enemyCount;
    public int currentWave = 1;
    public bool gameoverIndicator;
    public bool gameover = false;
    public GameObject powerupPrefab;

    private void Awake()
    {
        playerController = playerControllerScript.GetComponent<PlayerController>();
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(currentWave);

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyBehaviour>().Length;

        if (playerController.gameover)
        {
            currentWave = 0;
            gameoverIndicator = true;
        }
        else if (enemyCount == 0) { currentWave++; SpawnEnemyWave(currentWave); Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation); }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosY);
        return randomPos;
    }

    void SpawnEnemyWave(int enemySpawnCount)
    {
        for (int i = 0; i < enemySpawnCount; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}