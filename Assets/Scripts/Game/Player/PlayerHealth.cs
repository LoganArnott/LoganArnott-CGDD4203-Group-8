using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    int health;
    bool invincible;
    float timer;
    float healthTimer;
    public Image health1;
    public Image health2;
    public AudioSource audioData;

    void Start()
    {
        health = 2;
        invincible = false;
        timer = 3f;
        healthTimer = 10f;
        health1.enabled = true;
        health2.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Invincibility frames
        if(invincible) {
            timer -= Time.deltaTime;
            if(timer <= 0) {
                invincible = false;
                timer = 3f;
            }
        }

        // Health regen timer
        if(health < 2) {
            healthTimer -= Time.deltaTime;
            if(healthTimer <= 0) {
                health = 2;
                healthTimer = 10f;
                health2.enabled = true;
            }
        }

        // Death at health = 0
        if(health <= 0) {
            GameObject.Find("Game Manager").GetComponent<SceneLoader>().GameOver();
            GameObject.Find("Game Manager").GetComponent<Score>().StopScore();
            GameObject.Find("Main Camera").GetComponent<Audio>().PlayerDeath();
            Destroy(gameObject);
            health1.enabled = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if((col.gameObject.tag == "Enemy" || col.gameObject.tag == "EnemyBullet") && !invincible) {
            health -= 1;
            invincible = true;
            health2.enabled = false;
            audioData.PlayOneShot(audioData.clip);
        }
    }
}
