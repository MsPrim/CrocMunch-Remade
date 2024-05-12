using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fishSpawnManager2 : MonoBehaviour
{
    public bool isGameActive = false;
    public GameObject[] foodPrefabs;

    private float spawnLimitLeft = -6;
    private float spawnLimitRight = 6;
    private float spawnPosY = 7;

    private float startDelay = 1.0f;
    private float spawnInterval = 1.0f;

    private Coroutine spawningCoroutine;

    // Start is called before the first frame update
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
            spawningCoroutine = StartCoroutine(SpawnFood());
        }
    }

    void StopSpawning()
    {
        if (spawningCoroutine != null)
        {
            StopCoroutine(spawningCoroutine);
        }
    }

    private IEnumerator SpawnFood()
    {
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            if (isGameActive)
            {
                SpawnRandomFish();
                float randomInterval = Random.Range(1.0f, 2.0f);
                yield return new WaitForSeconds(randomInterval);
            }
            else
            {
                yield return null;
            }
        }
    }

    void SpawnRandomFish()
    {
        int randomFishIndex = Random.Range(0, foodPrefabs.Length);
        Vector3 spawnPos = new Vector2(Random.Range(spawnLimitLeft, spawnLimitRight), spawnPosY);
        Instantiate(foodPrefabs[randomFishIndex], spawnPos, Quaternion.identity);
    }

    public void GameOver()
    {
        StopSpawning();
        isGameActive = false;
    }
}

