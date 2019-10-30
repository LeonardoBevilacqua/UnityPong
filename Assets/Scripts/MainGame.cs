using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    // variable responsible to hold the main game object
    private GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        // get the game over
        this.gameOver = GameObject.Find("GameOver");
        this.gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.GetComponentInChildren<BallMovement>().IsGameActive())
        {
            this.gameOver.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
