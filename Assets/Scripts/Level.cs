using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public Text statusText;
    public float phaseLength = 15f;

    public EnemySpawner enemySpawner;
    public AsteroidSpawner asteroidSpawner;

    public void OnShipDestroyed()
    {
        StopAllCoroutines();
        
        StartCoroutine(OnGameOver());
    }

    void Start()
    {
        StartCoroutine(Go());
    }

    private IEnumerator Go()
    {
        Time.timeScale = 0f;

        var countdown = 3;
        for (int i = countdown; i > 0; i--)
        {
            statusText.text = i.ToString();
            yield return new WaitForSecondsRealtime(1f);
        }

        statusText.enabled = false;

        Time.timeScale = 1f;

        var score = FindObjectOfType<Score>();
        StartCoroutine(asteroidSpawner.Spawn());

        var ship = FindObjectOfType<Ship>();
        int enemySpawnCount = 5;

        int wave = 1;
        while (ship != null)
        {
            yield return new WaitForSeconds(3f);

            if ((wave % 2) == 0)
            {
                asteroidSpawner.spawnCount++;
                enemySpawnCount++;
            }

            asteroidSpawner.spawnDelay -= 0.02f;
            asteroidSpawner.maxSpeed += 3;

            yield return StartCoroutine(enemySpawner.SpawnColumn(enemySpawnCount));
                
            if ((wave % 4) == 0)
            {
                enemySpawner.SpawnStation();
            }

            wave++;
            score.IncrementWave();
        }
    }

    private IEnumerator OnGameOver()
    {
        yield return new WaitForSecondsRealtime(2.0f);

        Time.timeScale = 0.0f;
        statusText.text = "Game Over";
        statusText.enabled = true;

        yield return new WaitForSecondsRealtime(5.0f);

        SceneManager.LoadScene("MainMenu");
    }
}
