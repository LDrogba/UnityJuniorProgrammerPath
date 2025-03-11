using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerGameManager : MonoBehaviour
{
    [SerializeField]
    private Canvas gameOverCanvas;
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private GameObject[] livesImages;

    private int lives = 3;
    private int score = 0;

    public void animalFullyFead(int meatValue)
    {
        score += meatValue;
        updateScore();
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Kolizja z " + collision.gameObject.name);
        if (collision.gameObject.tag != "Animal") return;
        collisionWithAnimal();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void collisionWithAnimal()
    {
        lives--;
        livesImages[lives].gameObject.SetActive(false);
        if(lives <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
        transform.Rotate(Vector3.right, 90f);
    }

    void updateScore()
    {
        scoreText.text = score.ToString();
    }
}
