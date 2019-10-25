using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMovement : MonoBehaviour
{

    private Vector2 velocity;
    private Rigidbody2D rb2d;

    public float barVelocity;

    private bool isCollidingLeft;
    private bool isCollidingRight;

    // Start is called before the first frame update
    void Start()
    {
        this.barVelocity = 3.0f;
        this.isCollidingLeft = false;
        this.isCollidingRight = false;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int left = (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && !isCollidingLeft ? -1 : 0;
        int right = (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && !isCollidingRight ? 1 : 0;

        velocity = new Vector2((barVelocity * (left + right)), 0.0f);

        rb2d.MovePosition(rb2d.position + velocity * Time.fixedDeltaTime);
    }

    // OnTriggerEnter is called when a collision is trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            if (other.gameObject.name == "RightWall")
            {
                this.isCollidingRight = true;
            }
            else
            {
                this.isCollidingLeft = true;
            }
        }
    }

     void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            if (other.gameObject.name == "RightWall")
            {
                this.isCollidingRight = false;
            }
            else
            {
                this.isCollidingLeft = false;
            }
        }
    }
}
