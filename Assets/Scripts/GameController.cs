using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAsteroid", 2, spawnRate);
    }

    void SpawnAsteroid()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(hazard, spawnPosition, spawnRotation);
    }
}
