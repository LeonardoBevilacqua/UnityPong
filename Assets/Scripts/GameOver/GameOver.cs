using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{

    // variable to hold the final points object
    public Text finalPoints;

    // variable to hold the top score object
    public Text topScore;

    // Start is called before the first frame update
    void Start()
    {
        this.finalPoints.text = "Sua pontuação: " + Manager.Instance.GetCurrentPoints().ToString();
        this.topScore.text = "Melhor pontuação: " + Manager.Instance.GetTopScore().ToString();
    }

    // Method responsible to reset the main game scene
    public void Reset()
    {
        // Reset the main scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(gameObject);
    }

     // Method responsible to change to menu scene
    public void GoToMenu()
    {
        Manager.Instance.GoToMenu();
    }
}
