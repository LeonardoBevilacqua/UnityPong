using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // variable responsible to set the direction
    private Vector2 target;

    // variable responsible to hold the ball rigid body reference
    private Rigidbody2D ballRigidBody;

    // variable responsible to set the X direction
    private int moveX;

    // variable responsible to set the Y direction
    private int moveY;

    private int points;

    // exported variable responsible to set the ball velocity
    public float ballVelocity = 5.0f;

    // exported variable that holds the Points label reference
    public Text pointsLabel;
    
    // Start is called before the first frame update
    void Start()
    {
        // initialize variables
        this.moveX = 1;
        this.moveY = -1;
        this.points = 0;

        // get the ball rigid body
        this.ballRigidBody = gameObject.GetComponent<Rigidbody2D>();

        // set the ball to a random position
        transform.position = new Vector3(Random.Range(-3.0f, 3.0f), 3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // set the ball velocity
        target = new Vector2(ballVelocity * moveX, ballVelocity * moveY);

        // move sprite towards the target location
        float step = ballVelocity * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }

    // OnTriggerEnter is called when a collision is trigger
    void OnTriggerEnter2D(Collider2D objectCollider)
    {
        switch (objectCollider.gameObject.tag)
        {
            case "Box":
                this.VerifyBoxCollision(objectCollider);
                break;
            case "Wall":
                this.VerifyWallCollision(objectCollider);
                break;
            case "Player":
                VerifyPlayerCollision(objectCollider);
                break;
        }
    }

    // Method responsible to change the ball behaviour after collide with a wall
    private void VerifyWallCollision(Collider2D objectCollider)
    {
        // check if hit the ceiling
        if (objectCollider.gameObject.name == "Ceiling")
        {
            moveY *= -1;
        }
        else
        {
            moveX *= -1;
        }
    }

    // Method responsible to change the ball behaviour after collide with a box
    private void VerifyBoxCollision(Collider2D objectCollider)
    {
        // set the X and Y distance
        float distanceX = this.transform.position.x - objectCollider.GetComponent<Collider2D>().transform.position.x;
        float distanceY = this.transform.position.y - objectCollider.GetComponent<Collider2D>().transform.position.y;

        // verify if hit the X axis
        if (distanceX != 0)
        {
            moveX *= -1;
        }

        // verify if hit the Y axis
        if (distanceY != 0)
        {
            moveY *= -1;
        }

        // update points
        this.UpdatePoints();
    }

    // Method responsible to change the ball behaviour after collide with the player
    private void VerifyPlayerCollision(Collider2D objectCollider)
    {
        // get where was hit
        float distanceY = this.transform.position.y - objectCollider.GetComponent<Collider2D>().transform.position.y;

        // verify if hit the Y axis
        if (distanceY > 0)
        {
            // bounce the ball up
            moveY *= -1;
        }
    }

    // Method responsible to update the points count and show it
    private void UpdatePoints() 
    {
        this.pointsLabel.text = (++this.points).ToString();

    }
}
