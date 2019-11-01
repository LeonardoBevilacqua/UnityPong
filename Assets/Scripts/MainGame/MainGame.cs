using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    // variable responsible to hold the game over prefab
    private GameObject gameOver;

    // variable responsible to gold the game over instance
    private GameObject gameOverInstance;

    // Start is called before the first frame update
    void Start()
    {
        // get the game over prefab
        this.gameOver = (GameObject)Resources.Load("Prefabs/GameOver", typeof(GameObject));
    }

    // Update is called once per frame
    void Update()
    {
        // verify the game still active
        if (!Manager.Instance.GetIsGamingRunning())
        {
            // hide the game and show the game over
            gameObject.SetActive(false);

            // instantiate the game over
            this.gameOverInstance = Instantiate(this.gameOver, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
