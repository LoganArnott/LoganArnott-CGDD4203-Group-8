using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public float timeElapsed;
    public GameObject[] enemies;
    public GameObject[] stars;
    public GameObject item;
    float timer = 0.5f;
    Camera cam;
    Vector3 left;
    Vector3 middle;
    Vector3 right;
    Vector3 leftOfScreen;
    Vector3 rightOfScreen;
    float score;
    int displayScore;

    bool thirty = true;
    bool sixty = true;
    bool ninety = true;
    bool oneTwenty = true;
    bool oneFifty = true;
    bool oneEighty = true;

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

        leftOfScreen = cam.ScreenToWorldPoint(new Vector3(0, Screen.height * 15 / 100, 0));
        rightOfScreen = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height * 15 / 100, 0));
        
        // Spawns stars background
        StartCoroutine(StarsSpawn());
        StartCoroutine(StarsSpawn());
        StartCoroutine(StarsSpawn());
        StartCoroutine(StarsSpawn());
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

        // Updates amount of stars in background to correspond with speed
        if(timeElapsed > 30f && timeElapsed < 60f && thirty) {
            StartCoroutine(StarsSpawn());
            StartCoroutine(StarsSpawn());
            // Starts coroutine to spawn an item
            StartCoroutine(ItemSpawn());
            thirty = false;
        } else if(timeElapsed > 60f && timeElapsed < 90f && sixty) {
            StartCoroutine(StarsSpawn());
            StartCoroutine(StarsSpawn());
            sixty = false;
        } else if(timeElapsed > 90f && timeElapsed < 120f && ninety) {
            StartCoroutine(StarsSpawn());
            StartCoroutine(StarsSpawn());
            ninety = false;
        } else if(timeElapsed > 120f && timeElapsed < 150f && oneTwenty) {
            StartCoroutine(StarsSpawn());
            StartCoroutine(StarsSpawn());
            oneTwenty = false;
        } else if(timeElapsed > 150f && timeElapsed < 180f && oneFifty) {
            StartCoroutine(StarsSpawn());
            StartCoroutine(StarsSpawn());
            oneFifty = false;
        } else if(timeElapsed > 180f && oneEighty) {
            StartCoroutine(StarsSpawn());
            StartCoroutine(StarsSpawn());
            oneEighty = false;
        }
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
        // Picks from an array of enemies
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

    // Stars spawn coroutine
    IEnumerator StarsSpawn()
    {
        // Loop to spawn stars
        while(true) {
            yield return new WaitForSeconds(Random.Range(0.1f, 1f));
            Instantiate(stars[Random.Range(0, stars.Length)], new Vector3(Random.Range(leftOfScreen.x, rightOfScreen.x), 5, 0), Quaternion.identity);
        }
    }

    // Item spawn coroutine
    IEnumerator ItemSpawn()
    {
        // Loop to spawn an item
        while(true) {
            yield return new WaitForSeconds(Random.Range(5f, 15f));
            
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

            Instantiate(item, new Vector3(spawnPos.x, 5, 0), Quaternion.identity);
        }
    }
}
