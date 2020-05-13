using UnityEngine;

public class Pipes : MonoBehaviour
{
    private GameManager manager;

    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (manager.isGameOver)
            return;

        this.transform.position += Vector3.left * Time.deltaTime * manager.gameSpeed;

        if (this.transform.position.x < -8.4F)
        {
            float newX = this.transform.position.x + manager.pipeDistance * 5;
            float newY = Random.Range(-2F, 2F);

            this.transform.position = new Vector3(newX, newY);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        manager.IncrementScore();
    }
}
