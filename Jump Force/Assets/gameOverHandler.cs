using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverHandler : MonoBehaviour
{
    [SerializeField]
    BackgroundManager backgroundManager;
    [SerializeField]
    ObstacleSpawnerManger obstacleManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        backgroundManager.setSpeed(0f);
        obstacleManager.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
