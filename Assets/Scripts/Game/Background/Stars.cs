using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    float speed;
    float timeElapsedCheck;
    float timeElapsedMultiplier;
    Vector3 targetPosition;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
        SpeedMultipler();
        TargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        // Destroys stars if it goes below the screen
        if(transform.position.y <= targetPosition.y) {
            Destroy(gameObject);
        }
    }

    // Set targetPosition to bottom of screen
    public void TargetPosition()
    {
        cam = Camera.main;
        Vector3 tempPosition = cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        targetPosition = new Vector3(transform.position.x, tempPosition.y - 2, transform.position.z);
    }

    // Speed multiplier
    public void SpeedMultipler()
    {
        timeElapsedCheck = GameObject.Find("Game Manager").GetComponent<Score>().timeElapsed;
        timeElapsedMultiplier = timeElapsedCheck / 40f;
        if(timeElapsedCheck > 20f && timeElapsedCheck < 180f) {
            speed *= timeElapsedMultiplier;
        } else if(timeElapsedCheck > 180f) {
            speed *= 4.5f;
        } else {
            speed = 1f;
        }
    }

    // Movement method
    public void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
