using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float hInput, vInput, movementSpeed, rotationSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 3.0f;
        rotationSpeed = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * vInput * movementSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, hInput * rotationSpeed * Time.deltaTime);
    }
}
