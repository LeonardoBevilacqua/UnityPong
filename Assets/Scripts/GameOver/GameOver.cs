using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{

    // variable to hold the final points object
    public Text finalPoints;

    // Start is called before the first frame update
    void Start()
    {
        finalPoints.text = "Sua pontuação: " + Manager.Instance.getCurrentPoints().ToString();
    }

    // Method responsible to reset the main game scene
    public void Reset()
    {
        // Reset the main scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(gameObject);
    }
}
