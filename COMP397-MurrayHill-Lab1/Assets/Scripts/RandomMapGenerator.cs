using UnityEngine;

public class RandomMapGenerator : MonoBehaviour
{
    public int width = 20;
    public int height = 20;

    public GameObject waterPrefab;
    public GameObject sandPrefab;
    public GameObject grassPrefab;
    public GameObject mountainPrefab;

    public Transform mapCenter;

    void Start()
    {
        GenerateRandomMap();
        SetupCamera();
    }

    void GenerateRandomMap()
    {
        Debug.Log("Random Map Generation Started");

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                GameObject tile = ChooseRandomTile();
                Vector3 position = new Vector3(x, 0.5f, z); // y=0.5 so it sits above ground
                GameObject spawned = Instantiate(tile, position, Quaternion.identity, transform);
                Debug.Log("Spawned " + spawned.name + " at " + spawned.transform.position);
            }
        }

        if (mapCenter != null)
            mapCenter.position = new Vector3(width / 2f, 0, height / 2f);
    }

    GameObject ChooseRandomTile()
    {
        float r = Random.value;
        if (r < 0.25f) return waterPrefab;
        if (r < 0.5f) return sandPrefab;
        if (r < 0.75f) return grassPrefab;
        return mountainPrefab;
    }

    void SetupCamera()
    {
        Camera.main.transform.position = new Vector3(width / 2f, 20, -width / 2f);
        Camera.main.transform.rotation = Quaternion.Euler(45, 45, 0);
    }
}
