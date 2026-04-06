using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Starts a new game by loading the main game scene
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // Make sure your scene is named exactly "GameScene"
    }

    // Loads a saved game (you can add your saved game logic here)
    public void LoadGame()
    {
        // Example placeholder for loading a saved scene
        // Replace "SavedGameScene" with your actual scene name or loading logic
        SceneManager.LoadScene("SavedGameScene");
    }

    // Quits the application
    public void QuitGame()
    {
        Application.Quit();

        // For testing in the Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}