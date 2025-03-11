using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] animals;
    [SerializeField]
    int numberOfSpawnsUntilLvlUp = 5;
    [SerializeField]
    float expectedDeltaTimeBetweenSpawns = 3f;
    [SerializeField]
    float spawnLocationRange = 20f;

    float timeSinceLastSpawn = 30f;
    int numberOfSpawnedAnimals = 0;
    int numberOfAnimalsPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        numberOfAnimalsPrefabs = animals.Length;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn > expectedDeltaTimeBetweenSpawns)
        {
            float spawnPostition_x = Random.Range(-spawnLocationRange, spawnLocationRange);
            //Instantiate(animals[Random.Range(0, numberOfAnimalsPrefabs)]).transform.position = new Vector3(spawnPostition_x, 0, transform.position.z);
            var animal = Instantiate(animals[Random.Range(0, numberOfAnimalsPrefabs)]);
            animal.transform.position = transform.position;
            animal.transform.rotation = transform.rotation;
            animal.transform.Translate(Vector3.right * spawnPostition_x);
            timeSinceLastSpawn = 0;
            numberOfSpawnedAnimals++;

            if(numberOfSpawnedAnimals >= numberOfSpawnsUntilLvlUp && expectedDeltaTimeBetweenSpawns > 0.5f)
            {
                numberOfSpawnedAnimals = 0;
                expectedDeltaTimeBetweenSpawns *= 0.8f;
            }
        }
    }
}
