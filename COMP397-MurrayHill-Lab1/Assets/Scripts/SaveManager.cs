using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System.Collections;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public Transform player; // assign in inspector or use FindWithTag
    private string savePath;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        savePath = Application.persistentDataPath + "/save.json";
        Debug.Log("Save file path: " + savePath);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded: " + scene.name);

        if (PlayerPrefs.GetInt("LoadGame", 0) == 1)
        {
            if (player == null)
            {
                player = GameObject.FindWithTag("Player")?.transform;
            }

            if (player != null)
            {
                Debug.Log("Player found, loading saved position...");
                LoadGame();
                PlayerPrefs.SetInt("LoadGame", 0);
            }
            else
            {
                Debug.LogWarning("Player not found immediately, waiting one frame...");
                StartCoroutine(DelayedLoad());
            }
        }
    }

    private IEnumerator DelayedLoad()
    {
        yield return null; // wait one frame
        if (player == null)
        {
            player = GameObject.FindWithTag("Player")?.transform;
        }

        if (player != null)
        {
            Debug.Log("Player found after delay, loading saved position...");
            LoadGame();
            PlayerPrefs.SetInt("LoadGame", 0);
        }
        else
        {
            Debug.LogError("Player still not found after delay!");
        }
    }

    public void SaveGame()
    {
        if (player == null)
        {
            Debug.LogError("Player reference is null, cannot save!");
            return;
        }

        SaveData data = new SaveData
        {
            posX = player.position.x,
            posY = player.position.y,
            posZ = player.position.z
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);

        Debug.Log("Game Saved!");
        Debug.Log("Saved Position: X=" + data.posX + " Y=" + data.posY + " Z=" + data.posZ);
        Debug.Log("Save file exists: " + File.Exists(savePath));
    }

    public void LoadGame()
    {
        if (!File.Exists(savePath))
        {
            Debug.LogError("No save file found to load!");
            return;
        }

        string json = File.ReadAllText(savePath);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        if (player != null)
        {
            player.position = new Vector3(data.posX, data.posY, data.posZ);
            Debug.Log("Loaded Position: X=" + data.posX + " Y=" + data.posY + " Z=" + data.posZ);
        }
        else
        {
            Debug.LogError("Player is null when trying to load!");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F key pressed: attempting to save game...");
            SaveGame();
        }
    }
}

[System.Serializable]
public class SaveData
{
    public float posX;
    public float posY;
    public float posZ;
}