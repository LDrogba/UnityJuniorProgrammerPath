using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float maxHorizontalPlayerOffsetFromCenter;
    [SerializeField]
    private float maxVerticalPlayerOffsetFromCenter;
    [SerializeField]
    private GameObject ammoPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 moveVector = Vector3.zero;

        if ((horizontalInput > 0f && transform.position.x > -maxHorizontalPlayerOffsetFromCenter) ||
            (horizontalInput < 0f && transform.position.x < maxHorizontalPlayerOffsetFromCenter))
        {
            moveVector.x = -horizontalInput * Time.deltaTime * moveSpeed;
        }
        if ((verticalInput > 0f && transform.position.z > -maxVerticalPlayerOffsetFromCenter) ||
            (verticalInput < 0f && transform.position.z < maxVerticalPlayerOffsetFromCenter))
        {
            moveVector.z = -verticalInput * Time.deltaTime * moveSpeed;
        }
        moveVector = Vector3.ClampMagnitude(moveVector, 1f * Time.deltaTime * moveSpeed);

        transform.Translate(moveVector);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(ammoPrefab, transform.position, ammoPrefab.transform.rotation);
            bullet.GetComponent<BullerCollisionHandler>().player = this.gameObject;
        }
    }
}
