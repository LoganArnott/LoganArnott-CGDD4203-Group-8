using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public float timeElapsed;
    public GameObject enemy;
    float timer = 0.5f;
    Camera cam;
    Vector3 left;
    Vector3 middle;
    Vector3 right;
    float score;

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
    }

    // Enemy spawn coroutine
    IEnumerator EnemySpawn()
    {
        // Waits randomly between 1 and 15 seconds before spawning the enemy
        yield return new WaitForSeconds(Random.Range(1f, 15f));
        // Randomly select left/middle/right to spawn
        int randomLocation = Random.Range(1, 4);
        // Spawns enemy
        switch(randomLocation) {
            case 1:
                GameObject enem1 = Instantiate (enemy, new Vector3(left.x, 5, 0), Quaternion.identity) as GameObject;
                break;
            case 2:
                GameObject enem2 = Instantiate (enemy, new Vector3(middle.x, 5, 0), Quaternion.identity) as GameObject;
                break;
            case 3:
                GameObject enem3 = Instantiate (enemy, new Vector3(right.x, 5, 0), Quaternion.identity) as GameObject;
                break;
        }
        // Ends the coroutine
        StopCoroutine(EnemySpawn());
    }

    public void EnemyPoints(float points)
    {
        score += points;
    }
}
