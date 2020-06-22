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
    public int startingHazardCount;
    public int enemyShipStartWave;
    public Text scoreText;
    public Text gameOverText;
    public Button restartButton;

    private int score;
    private bool gameOver;
    private int currentWave = 0;

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
            currentWave++;
            int extraHazards = currentWave / 5;
            int hazardCount = startingHazardCount + extraHazards;
            for (int i = 0; i < hazardCount; i++)
            {
                SpawnHazard();
                yield return new WaitForSeconds(spawnRate);
            }
            yield return new WaitForSeconds(waveRate);
        }
    }

    void SpawnHazard()
    {
        if (!gameOver)
        {
            int hazardsRange = hazards.Length;
            if (currentWave < enemyShipStartWave)
            {
                hazardsRange--;
            }
            GameObject hazard = hazards[Random.Range(0, hazardsRange)];
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(hazard, spawnPosition, spawnRotation);
        }
    }

    public void AddScore(int addScore)
    {
        score += addScore;
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
