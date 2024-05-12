using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logMovement : MonoBehaviour
{
    public logSpawnManager2 spawnManager;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnManager == null)
        {
            spawnManager = FindObjectOfType<logSpawnManager2>();
            if (spawnManager == null)
            {
                Debug.LogError("LogSpawnManager not found!");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Main Scene")
        {
            //make the log swim down
            transform.Translate(Vector2.down * Time.deltaTime * speed);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //load the restart screen if the player collides with a log
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over: Log Collision Detected");
            if (spawnManager != null)
            {
                spawnManager.GameOver();
            }
            else
            {
                Debug.LogError("spawnManager is null!");
            }
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
