using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoader : MonoBehaviour
{
    public void LoadGame()
    {
        PlayerPrefs.SetInt("LoadGame", 1); // set flag before loading
        SceneManager.LoadScene("GameScene"); // load the game scene
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("LoadGame", 0);
        SceneManager.LoadScene("GameScene");
    }
}