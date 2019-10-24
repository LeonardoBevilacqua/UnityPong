using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMovement : MonoBehaviour
{

    private Vector2 velocity;
    public Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector2(1.75f, 0.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + velocity * Time.fixedDeltaTime);
    }

    // OnTriggerEnter is called when a collision is trigger
     void OnTriggerEnter(Collider other) 
     {
         
         if (other.gameObject.CompareTag ("Wall"))
         {
             other.gameObject.SetActive (false);
         }
     }
}
