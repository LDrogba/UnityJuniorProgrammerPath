using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundHandler : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -5)
            Destroy(gameObject);
    }
}
