using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float dogCooldown;

    // Update is called once per frame
    void Update()
    {
        dogCooldown -= Time.deltaTime;
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dogCooldown < 0)
            {
                Invoke("SpawnDog", 0);
            }
            dogCooldown = 1;
        }
    }
    private void SpawnDog()
    {
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        dogCooldown = 1;
    }
}
