using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logSpawnManager2 : MonoBehaviour
{
    public bool isGameActive = false;
    public GameObject[] logPrefabs;

    private float spawnLimitLeft = -6;
    private float spawnLimitRight = 6;
    private float spawnPosY = 7;

    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;

    private Coroutine spawningCoroutine;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Main Scene")
        {
            isGameActive = true;
            StartSpawning();
        }
    }

    void StartSpawning()
    {
        if (isGameActive)
        {
            spawningCoroutine = StartCoroutine(SpawnLogs());
        }
    }

    void StopSpawning()
    {
        if (spawningCoroutine != null)
        {
            StopCoroutine(spawningCoroutine);
        }
    }

    IEnumerator SpawnLogs()
    {
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            if (isGameActive)
            {
                SpawnRandomLog();
                float randomInterval = Random.Range(1.0f, 2.0f);
                yield return new WaitForSeconds(randomInterval);
            }
            else
            {
                yield return null;
            }
        }
    }

    void SpawnRandomLog()
    {
        int randomLogIndex = Random.Range(0, logPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitLeft, spawnLimitRight), spawnPosY, 0);
        Instantiate(logPrefabs[randomLogIndex], spawnPos, Quaternion.identity);
    }

    public void GameOver()
    {
        StopSpawning();
        isGameActive = false;
    }
}
