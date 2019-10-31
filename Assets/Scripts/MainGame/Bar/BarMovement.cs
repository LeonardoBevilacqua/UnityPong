using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMovement : MonoBehaviour
{
    // variable responsible to set the direction velocity
    private Vector2 velocity;

    // variable responsible to hold the bar rigid body reference
    private Rigidbody2D barRigidBody;

    // exported variable responsible to set the bar velocity
    public float barVelocity = 3.0f;

    // variable responsible to verify if is colliding with the left wall
    private bool isCollidingLeft;

    // variable responsible to verify if is colliding with the right wall
    private bool isCollidingRight;

    // Start is called before the first frame update
    void Start()
    {
        // initialize variables
        this.isCollidingLeft = false;
        this.isCollidingRight = false;

        // get the bar rigid body
        barRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get inputs from player
        int left = (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && !isCollidingLeft ? -1 : 0;
        int right = (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && !isCollidingRight ? 1 : 0;

        // get boost input
        float boost = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? 4f : 0;

        // set the bar velocity
        velocity = new Vector2(((barVelocity + boost) * (left + right)), 0.0f);

        // move the bar
        barRigidBody.MovePosition(barRigidBody.position + velocity * Time.fixedDeltaTime);
    }

    // OnTriggerEnter is called when a collision is trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        // handle collision with the wall
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
        // handle after collision with the wall
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
