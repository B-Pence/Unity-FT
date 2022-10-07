using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    private int minspeed = 12;
    private int maxspeed = 16;
    private int maxTorque = 10;
    private int xRange = 4;
    private float ySpawnPos = -3;
    public int pointValue;

    private GameManager gameManager;

    public ParticleSystem explosionParticle;

    private Rigidbody targetRb;

    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();

        Vector3 RandomForce() {  return Vector3.up * Random.Range(minspeed, maxspeed); }
        float RandomTorque() { return Random.Range(-maxTorque, maxTorque); }
        Vector3 RandomSpawnPos() { return new Vector3(Random.Range(-xRange, xRange), ySpawnPos); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() 
    {
        Destroy(gameObject);
        if (CompareTag("Good"))
        {
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
        else if (CompareTag("Bad")) 
        { 
            gameManager.UpdateScore(-5);
            gameManager.gameOver = true;
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
    }
    private void OnTriggerEnter(Collider other) 
    { 
        Destroy(gameObject);
        if (gameObject.CompareTag("Good")) { gameManager.gameOver = true; }
    }
}
