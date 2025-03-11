using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullerCollisionHandler : MonoBehaviour
{
    public GameObject player;
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Kolizja z " + collision.gameObject.name);
        
        if (collision.gameObject.tag != "Animal") return;

        collision.gameObject.GetComponent<AnimalHealth>().hit(10);
        Destroy(gameObject);
    }
}
