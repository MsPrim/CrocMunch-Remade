using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] foodPrefabs;

    private float spawnLimitLeft = -11;
    private float spawnLimitRight = 11;
    private float spawnPosY = 14;

    private float startDelay = 1.0f;
    private float spawnInterval = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomFish", startDelay, spawnInterval);
    }

    void SpawnRandomFish()
    {
        int randomFishIndex = Random.Range(0, foodPrefabs.Length);

        //Generate random fish index and a random spawning position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitLeft, spawnLimitRight), spawnPosY, 0);

        //Instantiate fish at random spawn location
        Instantiate(foodPrefabs[randomFishIndex], spawnPos, foodPrefabs[0].transform.rotation);
    }

    // Update is called once per frame
    private void Update()
    {
        float timeNow = Time.realtimeSinceStartup;

        if (timeNow >= spawnInterval)
        {
            SpawnRandomFish();
            spawnInterval += Random.Range(3.0f, 5.0f);
        }
    }
}
