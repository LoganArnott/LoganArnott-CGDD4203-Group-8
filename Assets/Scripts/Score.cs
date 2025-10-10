using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public float timeElapsed;
    public GameObject[] enemies;
    float timer = 0.5f;
    Camera cam;
    Vector3 left;
    Vector3 middle;
    Vector3 right;
    float score;
    int displayScore;

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0;
        score = 0;

        // Positions of left/middle/right for the enemies
        cam = Camera.main;
        left = cam.ScreenToWorldPoint(new Vector3(Screen.width * 20 / 100, Screen.height * 15 / 100, 0));
        middle = cam.ScreenToWorldPoint(new Vector3(Screen.width * 50 / 100, Screen.height * 15 / 100, 0));
        right = cam.ScreenToWorldPoint(new Vector3(Screen.width * 80 / 100, Screen.height * 15 / 100, 0));
    }

    // Update is called once per frame
    void Update()
    {
        // Time
        timeElapsed = Time.time;

        // Starts a coroutine of spawning enemies every second
        if(timer <= 0f) {
            StartCoroutine(EnemySpawn());
            timer = 1f;
        } else {
            timer -= Time.deltaTime;
        }

        // Score
        score += Time.deltaTime;
        displayScore = (int)score;
    }

    // Enemy spawn coroutine
    IEnumerator EnemySpawn()
    {
        // Waits randomly between 1 and 15 seconds before spawning the enemy
        yield return new WaitForSeconds(Random.Range(1f, 15f));

        // Randomly select left/middle/right to spawn
        Vector3 spawnPos = middle;
        int randomLocation = Random.Range(1, 4);

        // Picks Location enemy
        switch (randomLocation)
        {
            case 1: spawnPos = left; break;
            case 2: spawnPos = middle; break;
            case 3: spawnPos = right; break;
        }
        //Picks from an array of enemies
        if (enemies.Length > 0)
        {
            int randomEnemy = Random.Range(0, enemies.Length);
            Instantiate(enemies[randomEnemy], new Vector3(spawnPos.x, 5, 0), Quaternion.identity);
        }

        // Ends the coroutine
        StopCoroutine(EnemySpawn());
    }

    public void EnemyPoints(float points)
    {
        score += points;
    }
}
