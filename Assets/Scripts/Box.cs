using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    private int lifePoints;

    private bool isColliding;

    // Start is called before the first frame update
    void Start()
    {
        this.lifePoints = Random.Range(5, 15);
        this.gameObject.GetComponentInChildren<TextMesh>().text = this.lifePoints.ToString();

        this.isColliding = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // OnTriggerEnter is called when a collision is trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            this.lifePoints--;
            this.gameObject.GetComponentInChildren<TextMesh>().text = this.lifePoints.ToString();

            this.isColliding = true;
        }
    }

     void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            this.isColliding = false;
        }
    }
}
