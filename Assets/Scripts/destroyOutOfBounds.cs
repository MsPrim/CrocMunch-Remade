using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DestroyOutOfBounds : MonoBehaviour
{
    public logSpawnManager2 spawnManager;

    private float topLimit = 8;
    private float lowerLimit = -7;

    private bool isDead;

    private void Start()
    {
        spawnManager = FindObjectOfType<logSpawnManager2>();
    }
    // Update is called once per frame
    void Update()
    {
        //Despawn objects that that go out of view
        if (transform.position.y > topLimit)
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("Player"))
            {
                spawnManager.GameOver();
                SceneManager.LoadScene("GameOverScene");
            }
        }
        else if (transform.position.y < lowerLimit)
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("Player"))
            {
                spawnManager.GameOver();
                SceneManager.LoadScene("GameOverScene");
                Debug.Log("Game Over: Out Of Bounds");
            }
        }

    }
}
