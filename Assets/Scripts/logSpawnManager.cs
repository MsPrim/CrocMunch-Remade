using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawnManager : MonoBehaviour
{
    public GameObject[] logPrefabs;

    private float spawnLimitLeft = -8;
    private float spawnLimitRight = 8;
    private float spawnPosY = 12;

    private float startDelay = 2.0f;
    private float spawnInterval = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomLog", startDelay, spawnInterval);
    }

    void SpawnRandomLog()
    {
        int randomLogIndex = Random.Range(0, logPrefabs.Length);

        //Generate random fish index and a random spawning position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitLeft, spawnLimitRight), spawnPosY, 0);

        //Instantiate fish at random spawn location
        Instantiate(logPrefabs[randomLogIndex], spawnPos, logPrefabs[0].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        float timeNow = Time.realtimeSinceStartup;

        if (timeNow >= spawnInterval)
        {
            SpawnRandomLog();
            spawnInterval += Random.Range(3.0f, 6.0f);
        }
    }
}
