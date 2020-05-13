using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipes;

    private GameManager manager;

    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<GameManager>();

        var dist = manager.pipeDistance;
        var begin = 0F;

        Instantiate(pipes, new Vector3(begin += dist, Random.Range(-2, 2)), pipes.transform.rotation);
        Instantiate(pipes, new Vector3(begin += dist, Random.Range(-2, 2)), pipes.transform.rotation);
        Instantiate(pipes, new Vector3(begin += dist, Random.Range(-2, 2)), pipes.transform.rotation);
        Instantiate(pipes, new Vector3(begin += dist, Random.Range(-2, 2)), pipes.transform.rotation);
    }
}
