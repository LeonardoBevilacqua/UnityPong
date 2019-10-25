using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehaviourControl : MonoBehaviour
{

    private int lifePoints;

    // Start is called before the first frame update
    void Start()
    {
        this.lifePoints = Random.Range(5, 15);
        this.gameObject.GetComponentInChildren<TextMesh>().text = this.lifePoints.ToString();
    }

    // OnTriggerEnter is called when a collision is trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            this.lifePoints--;
            this.gameObject.GetComponentInChildren<TextMesh>().text = this.lifePoints.ToString();
        }

        if (this.lifePoints == 0)
        {
            Destroy(gameObject);
        }
    }
}
