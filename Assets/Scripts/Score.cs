using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score = 0;
    private int wave = 1;

    public void IncrementScore(int amount)
    {
        score += amount;
    }

    public void IncrementWave()
    {
        wave++;
    }

    void Update()
    {
        GetComponent<Text>().text = string.Format("SCORE: {0}\nWAVE: {1}", 
            score.ToString("000000"),
            wave.ToString("000"));
    }
}
