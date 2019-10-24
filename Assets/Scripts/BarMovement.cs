using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMovement : MonoBehaviour
{

    private Vector2 velocity;
    public Rigidbody2D rb2d;

    public float barVelocity = 1.75f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int left = Input.GetKey(KeyCode.LeftArrow) ? -1 : 0;
        int right = Input.GetKey(KeyCode.RightArrow) ? 1 : 0;

        velocity = new Vector2((barVelocity * (left + right)), 0.0f);

        rb2d.MovePosition(rb2d.position + velocity * Time.fixedDeltaTime);
    }

    // OnTriggerEnter is called when a collision is trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Wall"))
        {
            velocity = new Vector2(0.0f, 0.0f);
        }
    }
}
