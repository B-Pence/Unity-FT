using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellorRotationX : MonoBehaviour
{

    public GameObject Propeller;
    private float propellerRotationSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * propellerRotationSpeed);
    }
}
