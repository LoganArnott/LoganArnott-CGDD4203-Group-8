using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public float timeElapsed;
    float score;
    int displayScore;
    public TMP_Text currentScore;

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Time
        timeElapsed = Time.time;

        // Score
        score += Time.deltaTime;
        displayScore = (int)score;

        currentScore.text = "Score: " + displayScore.ToString();
    }

    public void EnemyPoints(float points)
    {
        score += points;
    }
}
