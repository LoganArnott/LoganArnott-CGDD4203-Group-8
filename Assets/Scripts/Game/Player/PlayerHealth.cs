using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    int health = 2;
    bool invincible = false;
    float timer = 3f;
    float healthTimer = 10f;

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
            }
        }

        // Death at health = 0
        if(health <= 0) {
            GameObject.Find("Game Manager").GetComponent<SceneLoader>().GameOver();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if((col.gameObject.tag == "Enemy" || col.gameObject.tag == "EnemyBullet") && !invincible) {
            health -= 1;
            invincible = true;
        }
    }
}
