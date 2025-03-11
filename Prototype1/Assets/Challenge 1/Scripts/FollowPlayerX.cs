using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        cameraPosition.z = plane.transform.position.z;
        cameraPosition.y = plane.transform.position.y;
        transform.position = cameraPosition;
    }
}
