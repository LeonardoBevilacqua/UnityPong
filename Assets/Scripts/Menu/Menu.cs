using UnityEngine;

public class Menu : MonoBehaviour
{
    // Method responsible to change to game main Scene
    public void StartGame()
    {
        Manager.Instance.StartGame();
    }

    // Method responsible to exit the game
    public void ExitGame()
    {
        Manager.Instance.ExitGame();
    }
}
