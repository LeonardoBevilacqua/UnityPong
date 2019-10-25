using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Vector2 velocity;

    private Rigidbody2D rb2d;

    private int moveX = 1;
    private int moveY = -1;

    public float ballVelocity;
    // Start is called before the first frame update
    void Start()
    {
        this.ballVelocity = 5.0f;

        transform.position = new Vector3(Random.Range(-3.0f, 3.0f), 3, 0);
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector2(ballVelocity * moveX, ballVelocity * moveY);

        rb2d.MovePosition(rb2d.position + velocity * Time.fixedDeltaTime);
    }

    // OnTriggerEnter is called when a collision is trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Box")
        {
            if ((this.transform.position.x - other.GetComponent<Collider2D>().transform.position.x) < 0 || (this.transform.position.x - other.GetComponent<Collider2D>().transform.position.x) > 0)
            {
                moveX *= -1;
            }
            if ((this.transform.position.y - other.GetComponent<Collider2D>().transform.position.y) < 0 || (this.transform.position.y - other.GetComponent<Collider2D>().transform.position.y) > 0)
            {
                moveY *= -1;
            }
        }


        if (other.gameObject.CompareTag("Wall"))
        {
            if (other.gameObject.name == "TopWall")
            {
                moveY *= -1;
            }
            else
            {
                moveX *= -1;
            }
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            moveY *= -1;
        }
    }
}
