using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    protected float speed = 5;
    protected float points = 20;
    public float health = 3;
    protected float timeElapsedCheck;
    protected float timeElapsedMultiplier;
    protected Vector3 targetPosition;
    protected Camera cam;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        // Destroys enemy if it goes below the screen
        if(transform.position.y <= targetPosition.y) {
            Destroy(gameObject);
        }

        // Destroys enemy is health == 0
        if(health == 0) {
            Destroy(gameObject);
            GameObject.Find("Scorekeeper").GetComponent<Score>().EnemyPoints(points);
        }
    }

    // Set targetPosition to bottom of screen
    public virtual void TargetPosition()
    {
        cam = Camera.main;
        Vector3 tempPosition = cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        targetPosition = new Vector3(transform.position.x, tempPosition.y - 2, transform.position.z);
    }

    // Speed multiplier
    public virtual void SpeedMultipler()
    {
        timeElapsedCheck = GameObject.Find("Scorekeeper").GetComponent<Score>().timeElapsed;
        timeElapsedMultiplier = timeElapsedCheck / 40f;
        if(timeElapsedCheck > 20f && timeElapsedCheck < 180f) {
            speed *= timeElapsedMultiplier;
        } else if(timeElapsedCheck > 180f) {
            speed *= 4.5f;
        } else {
            speed = 2.5f;
        }
    }

    // Movement method
    public virtual void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
