using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehaviourControl : MonoBehaviour
{
    // variable responsible to hold the life points of the ball
    private int lifePoints;

    // Start is called before the first frame update
    void Start()
    {
        // set the life points from a range of 5 to 15
        this.lifePoints = Random.Range(5, 15);
        this.gameObject.GetComponentInChildren<TextMesh>().text = this.lifePoints.ToString();
    }

    // OnTriggerEnter is called when a collision is trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        // if the the box is hit, remove one life point
        if (other.gameObject.CompareTag("Ball"))
        {
            this.gameObject.GetComponentInChildren<TextMesh>().text = (--this.lifePoints).ToString();
        }

        // check if the box should be destroyed
        if (this.lifePoints == 0)
        {
            Destroy(gameObject);
        }
    }
}
