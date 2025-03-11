using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHealth : MonoBehaviour
{
    private int startingHealth;
    private int health;
    private PlayerGameManager player;
    [SerializeField]
    private Image healthBar;

    public void hit(int dmg)
    {
        health -= dmg;
        healthBar.fillAmount = (float)health/startingHealth;
        if(health <= 0)
        {
            die();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        startingHealth = Random.Range(10, 40);
        health = startingHealth;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void die()
    {
        player.animalFullyFead(10);
        Destroy(gameObject);
    }
}
