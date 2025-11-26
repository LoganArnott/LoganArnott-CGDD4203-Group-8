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
    public TMP_Text highScore;
    bool stopScore;

    // Start is called before the first frame update
    void Start()
    {
        stopScore = false;
        timeElapsed = 0;
        score = 0;
        highScore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Time
        timeElapsed = Time.timeSinceLevelLoad;

        // Score
        if(!stopScore) {
            score += Time.deltaTime;
        }
        displayScore = (int)score;

        currentScore.text = "Score: " + displayScore.ToString();
    }

    public void EnemyPoints(float points)
    {
        score += points;
    }

    public void StopScore()
    {
        stopScore = true;
        PlayerPrefs.SetInt("Highscore", displayScore);
    }
}
