using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);

        if (Mathf.Abs(transform.position.z) >= 20f)
        {
            Destroy(gameObject);
        }
    }
}
