using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public GameObject gameOverText, successText;
    public float forceQuotient;

    void Update()
    {
        var curY = this.transform.position.y;

        if (curY < -5)
        {
            GameOver();

            return;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            var rb = this.GetComponent<Rigidbody2D>();
            var force = new Vector2(0, forceQuotient);

            rb.AddForce(force);
        }
    }

    public void GameOver()
    {
        var camera = Camera.main;

        camera.GetComponent<CameraScript>().speed = 0;

        gameOverText.SetActive(true);

        var bird = GameObject.Find("bird");

        bird.SetActive(false);
    }

    public void Success()
    {
        var camera = Camera.main;

        camera.GetComponent<CameraScript>().speed = 0;

        successText.SetActive(true);

        var bird = GameObject.Find("bird");

        Destroy(bird);
    }
}
