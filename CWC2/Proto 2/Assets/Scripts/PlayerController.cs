using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xLimit = 10;
    public float projectileCooldown = 1;
    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -xLimit)
        {
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= xLimit)
        {
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        projectileCooldown -= Time.deltaTime;
        if (projectileCooldown < 0)
        {
            projectileCooldown = 0;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (projectileCooldown == 0)
            {
                Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
                projectileCooldown = 0.2f;
            }
        }
    }

}