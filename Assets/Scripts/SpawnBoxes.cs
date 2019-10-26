using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoxes : MonoBehaviour
{
    // exported variable that hold a box prefab reference
    public GameObject box;

    // exported variable that hold a ball reference
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        // create the first box
        CreateBoxes();
    }

    // Update is called once per frame
    void Update()
    {
        // verify if has boxes
        if (GameObject.FindGameObjectsWithTag("Box").Length == 0)
        {
            CreateBoxes();
        }
    }

    // Method responsible to create boxes
    private void CreateBoxes()
    {
        // create a range of 1 to 10 boxes
        for (int i = 0; i < (int)Random.Range(1, 10); i++)
        {
            // set the position of the box
            float positionX = Random.Range(-3f, 3f);
            float positionY = Random.Range(0f, 4f);

            // verify if the ball is not in the position
            if ((int)ball.transform.position.x != (int)positionX &&
                (int)ball.transform.position.y != (int)positionY)
            {
                // create the box
                Vector3 position = new Vector3(positionX, positionY, 0);
                Instantiate(box, position, Quaternion.identity);
            }
        }
    }
}
