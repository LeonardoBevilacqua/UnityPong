using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;

public class Manager : MonoBehaviour
{
    // Singleton reference
    public static Manager Instance { get; private set; }

    // Variable to hold the save file location
    private string savePath;

    // Game points
    private int currentPoints;

    private ArrayList topScores;

    // Game state
    private bool isGamingRunning;

    // Called when created
    private void Awake()
    {
        if (Instance == null)
        {
            this.Initialize();
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method responsible to initialize the variables
    private void Initialize()
    {
        this.savePath = Application.persistentDataPath + "/gamesave.save";
        this.topScores = new ArrayList();

        ReadScore();
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
        SaveScore();
        SceneManager.LoadScene("MenuScene");
    }

    // Method responsible to save the score
    public void SaveScore()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Open(this.savePath, FileMode.OpenOrCreate);

        binaryFormatter.Serialize(file, topScores);
        file.Close();
    }

    // Method responsible to read the score
    public void ReadScore()
    {
        if (File.Exists(this.savePath))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(this.savePath, FileMode.Open);

            this.topScores = (ArrayList)binaryFormatter.Deserialize(file);

            file.Close();
        }
    }

    public int GetTopScore()
    {
        return (int)this.topScores[this.topScores.Count - 1];
    }

    public void EndGame()
    {
        this.SetIsGamingRunning(false);
        this.AddTopScore(this.currentPoints);
    }

    // getters and setters
    public int GetCurrentPoints()
    {
        return this.currentPoints;
    }

    public void SetCurrentPoints(int currentPoints)
    {
        this.currentPoints = currentPoints;
    }

    public bool GetIsGamingRunning()
    {
        return this.isGamingRunning;
    }

    public void SetIsGamingRunning(bool isGamingRunning)
    {
        this.isGamingRunning = isGamingRunning;
    }

    public void AddTopScore(int score)
    {
        this.topScores.Add(score);
        this.topScores.Sort();
    }
}
