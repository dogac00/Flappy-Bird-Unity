using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        var pos = collider.transform.position;

        var manager = GameObject.Find("Manager");

        var script = manager.GetComponent<GameManager>();

        script.GameOver();
    }
}
