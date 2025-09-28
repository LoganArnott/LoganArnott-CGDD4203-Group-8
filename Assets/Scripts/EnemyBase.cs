using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    protected float speed = 5;
    protected float points = 20;
    protected float health = 3;
    protected float timeElapsedCheck;
    protected float timeElapsedMultiplier;
    protected Vector3 targetPosition;
    protected Camera cam;

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
        timeElapsedMultiplier = timeElapsedCheck / 60f;
        if(timeElapsedCheck > 30f && timeElapsedCheck < 300f) {
            speed *= timeElapsedMultiplier;
        } else if(timeElapsedCheck > 300f) {
            speed *= 5f;
        } else {
            speed = 2.5f;
        }
    }

    // Parent movement method
    public virtual void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
