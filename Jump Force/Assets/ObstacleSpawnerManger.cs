using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerManger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject[] obstacles;
    [SerializeField]
    float spawnCooldown = 4f;
    [SerializeField]
    float obstacleSpeed = 4f;

    float spawnDeltaTime;
    int numOfObstaclePrefabs;
    int numOfSpawnedObstacles;

    void Start()
    {
        spawnDeltaTime = spawnCooldown + 1f;
        numOfObstaclePrefabs = obstacles.Length;
        if(numOfObstaclePrefabs == 0)
        {
            Debug.LogError("List of obstacle prefabs is empty!");
        }
        InvokeRepeating("SpawnObstacle", spawnCooldown, spawnCooldown);
    }

    void SpawnObstacle()
    {
        if (this.gameObject.activeSelf)
        {
            numOfSpawnedObstacles++;

            var obstacle = Instantiate(obstacles[Random.Range(0, numOfObstaclePrefabs - 1)]);
            obstacle.transform.position = transform.position;
            obstacle.GetComponent<MoveLeft>().setSpeed(obstacleSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setSpeed(float speed)
    {
        obstacleSpeed = speed;
    }
}
