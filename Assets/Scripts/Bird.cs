using UnityEngine;

public class Bird : MonoBehaviour
{
    public float forceQuotient;

    private GameManager manager;
    private Rigidbody2D rb;
    private bool keySpace;
    private Vector3 screen;

    void Start()
    {
        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        rb = this.GetComponent<Rigidbody2D>();
        manager = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        var curY = this.transform.position.y;

        if (curY < -screen.y)
        {
			manager.GameOver();

            return;
        }

        keySpace = Input.GetKey(KeyCode.Space);

        if (rb.velocity.y > 0)
            this.transform.rotation = Quaternion.Euler(0, 0, 30);
        else
            this.transform.rotation = Quaternion.Euler(0, 0, -30);
    }

    void FixedUpdate()
    {
        if (keySpace)
            rb.velocity = Vector2.up * forceQuotient * Time.deltaTime * 35;
    }
}
