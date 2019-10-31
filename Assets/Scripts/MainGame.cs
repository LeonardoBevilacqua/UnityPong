using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        // verify the game still active
        if (!gameObject.GetComponentInChildren<BallMovement>().IsGameActive())
        {
            // hide the game and show the game over
            this.gameOver.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    // Method responsible to reset the main game scene
    public void Reset()
    {
        // Reset the main scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
