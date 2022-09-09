using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver = false;

    private float floatForce = 7f;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public float floatCooldown = 0.0f;
    private int playerMaxY = 14;
    private float playerMinY = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {

        // While space is pressed and player is low enough, float up
            if (Input.GetKey(KeyCode.Space) && !gameOver && playerRb.transform.position.y < 14)
            {
                playerRb.AddForce(Vector3.up * floatForce);
            }

            if(playerRb.transform.position.y >= playerMaxY)
            {
                transform.position = new Vector3(transform.position.x, playerMaxY, transform.position.z);
            }
            else if(playerRb.transform.position.y < playerMinY)
            {
            transform.position = new Vector3(transform.position.x, playerMinY, transform.position.z);
        }
        }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }
        else
        {
            gameOver = false;
        }
    }
}
