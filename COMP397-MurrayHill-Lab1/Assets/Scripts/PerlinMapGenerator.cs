using UnityEngine;

public class PerlinMapGenerator : MonoBehaviour
{
    public int width = 20;
    public int height = 20;
    public float scale = 5f;

    public GameObject waterPrefab;
    public GameObject sandPrefab;
    public GameObject grassPrefab;
    public GameObject mountainPrefab;

    public Transform mapCenter;

    void Start()
    {
        GeneratePerlinMap();
        SetupCamera();
    }

    void GeneratePerlinMap()
    {
        Debug.Log("Perlin Map Generation Started");

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                float noise = Mathf.PerlinNoise(x * 0.2f, z * 0.2f);
                GameObject tile;

                if (noise < 0.3f)
                    tile = waterPrefab;
                else if (noise < 0.5f)
                    tile = sandPrefab;
                else if (noise < 0.7f)
                    tile = grassPrefab;
                else
                    tile = mountainPrefab;

                Vector3 pos = new Vector3(x, 0.5f, z);
                GameObject spawned = Instantiate(tile, pos, Quaternion.identity, transform);
                Debug.Log("Spawned " + spawned.name + " at " + spawned.transform.position);
            }
        }

        if (mapCenter != null)
            mapCenter.position = new Vector3(width / 2f, 0, height / 2f);
    }

    void SetupCamera()
    {
        Camera.main.transform.position = new Vector3(width / 2f, 20, -width / 2f);
        Camera.main.transform.rotation = Quaternion.Euler(45, 45, 0);
    }
}