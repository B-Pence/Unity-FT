using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    [SerializeField] float speed = 50;
    private Rigidbody enemyRb;
    public GameObject playerGoal;
    SpawnManagerX spawnManager;
    //public GameObject spawnManagerContainer;

    private void Awake()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>();
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Player Goal");
    }

    // Update is called once per frame
    void Update()
    {
        speed = 50 * (spawnManager.waveCount * 0.9f);
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);        
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }

}
