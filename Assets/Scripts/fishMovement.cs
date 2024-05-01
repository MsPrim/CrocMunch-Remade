using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishMovement : MonoBehaviour
{
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //make the flish swim down
        transform.Translate(Vector2.down * Time.deltaTime * speed);

    }

    //make the fish only collide with the player and add a point to the score
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("A Fish Has Been Eaten");
            ScoreManager.instance.AddPoint();
        }
    }
}
