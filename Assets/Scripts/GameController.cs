using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public float spawnRate;
    public float waveRate;
    public int waveCount;
    public Text scoreText;
    public Text gameOverText;
    public Button restartButton;

    private int score;
    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWave());
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    IEnumerator SpawnWave()
    {
        while (true)
        {
            for (int i = 0; i < waveCount; i++)
            {
                SpawnAsteroid();
                yield return new WaitForSeconds(spawnRate);
            }
            yield return new WaitForSeconds(waveRate);
        }
    }

    void SpawnAsteroid()
    {
        if (!gameOver)
        {
            GameObject hazard = hazards[Random.Range(0, hazards.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(hazard, spawnPosition, spawnRotation);
        }
    }

    public void AsteroidDestroyed()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
