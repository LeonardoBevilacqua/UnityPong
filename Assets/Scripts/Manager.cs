using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    // Singleton reference
    public static Manager Instance { get; private set; }

    // Game points
    private int currentPoints;

    // Game state
    private bool isGamingRunning;

    // Called when created
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method responsible to change to game main Scene
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    // Method responsible to exit the game
    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    // Method responsible to change to menu scene
    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    // getters and setters
    public int getCurrentPoints()
    {
        return this.currentPoints;
    }

    public void setCurrentPoints(int currentPoints)
    {
        this.currentPoints = currentPoints;
    }

    public bool getIsGamingRunning()
    {
        return this.isGamingRunning;
    }

    public void setIsGamingRunning(bool isGamingRunning)
    {
        this.isGamingRunning = isGamingRunning;
    }
}
