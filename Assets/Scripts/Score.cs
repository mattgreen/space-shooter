using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score = 0;

    public void Increment(int amount)
    {
        score += amount;
    }

    void Update()
    {
        GetComponent<Text>().text = string.Format("SCORE: {0}", score);
    }
}
