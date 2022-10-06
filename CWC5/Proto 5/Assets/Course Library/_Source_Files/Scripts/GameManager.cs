using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] targets;

    private float spawnRate = 1.0f;

    private int score;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    { 
        StartCoroutine(SpawnTarget());
        score = 0;
        scoreText.text = "Score ( " + score+ " )";
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Length);
            Instantiate(targets[index]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
