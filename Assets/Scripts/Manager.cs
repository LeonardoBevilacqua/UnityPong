using UnityEngine;

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
