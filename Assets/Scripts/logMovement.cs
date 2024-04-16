using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logMovement : MonoBehaviour
{
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //make the log swim down
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //load the restart screen if the player collides with a log
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
