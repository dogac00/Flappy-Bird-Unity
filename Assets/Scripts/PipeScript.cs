using UnityEngine;

public class PipeScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        var manager = GameObject.Find("Manager");

        var script = manager.GetComponent<GameManager>();

        script.GameOver();
    }
}
