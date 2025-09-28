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

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0;

        cam = Camera.main;
        left = cam.ScreenToWorldPoint(new Vector3(Screen.width * 20 / 100, Screen.height * 15 / 100, 0));
        middle = cam.ScreenToWorldPoint(new Vector3(Screen.width * 50 / 100, Screen.height * 15 / 100, 0));
        right = cam.ScreenToWorldPoint(new Vector3(Screen.width * 80 / 100, Screen.height * 15 / 100, 0));
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed = Time.time;

        if(timer <= 0f) {
            StartCoroutine(EnemySpawn());
            timer = 1f;
        } else {
            timer -= Time.deltaTime;
        }

    }

    IEnumerator EnemySpawn()
    {
        float checkIt = Random.Range(1f, 15f);
        yield return new WaitForSeconds(checkIt);
        int randomLocation = Random.Range(1, 4);
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
        StopCoroutine(EnemySpawn());
    }
}
