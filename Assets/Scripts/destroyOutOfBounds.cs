using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DestroyOutOfBounds : MonoBehaviour
{
    private float topLimit = 15;
    private float lowerLimit = -8;

    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {

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
                SceneManager.LoadScene("GameOverScene");
            }
        }
        else if (transform.position.y < lowerLimit)
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene("GameOverScene");
                Debug.Log("Game Over: Out Of Bounds");
            }
        }

    }
}
