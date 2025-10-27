using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    bool gameOver = false;
    float timer = 3f;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver) {
            timer -= Time.deltaTime;
            if(timer <= 0f) {
                SceneManager.LoadScene("Main Menu");
            }
        }
    }

    public void GameOver()
    {
        gameOver = true;
    }
}
