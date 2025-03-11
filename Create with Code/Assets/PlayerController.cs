using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 10.0f;
    [SerializeField]
    private float moveSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalinput = Input.GetAxis("Horizontal");

//            velocity = Vector3.forward * verticalInput * moveSpeed;
        transform.Rotate(Vector3.up, horizontalinput * Time.deltaTime * rotationSpeed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * moveSpeed);
    }
}
