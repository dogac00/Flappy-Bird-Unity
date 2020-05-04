using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        var bird = GameObject.Find("bird");

        var script = bird.GetComponent<BirdScript>();

        script.GameOver();
    }
}
