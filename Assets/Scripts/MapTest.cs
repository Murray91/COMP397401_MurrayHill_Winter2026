using UnityEngine;

public class TestMap : MonoBehaviour
{
    public GameObject tile;

    void Start()
    {
        Debug.Log("TEST MAP RUNNING");

        for (int x = 0; x < 10; x++)
        {
            for (int z = 0; z < 10; z++)
            {
                Instantiate(tile, new Vector3(x, 0, z), Quaternion.identity);
            }
        }
    }
}
