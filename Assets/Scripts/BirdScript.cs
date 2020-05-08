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
			var manager = GameObject.Find("Manager");
			
			var script = manager.GetComponent<GameManager>();
			
            script.GameOver();

            return;
        }

        var rb = this.GetComponent<Rigidbody2D>();
        var velocity = rb.velocity;

        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector2.up * forceQuotient;
        }

        if (velocity.y > 0)
            this.transform.eulerAngles = new Vector3(0, 0, 30);
        else
            this.transform.eulerAngles = new Vector3(0, 0, -30);
    }
}
