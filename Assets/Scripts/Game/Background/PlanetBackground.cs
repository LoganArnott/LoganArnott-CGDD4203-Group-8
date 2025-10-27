using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBackground : MonoBehaviour
{
    float speed;
    Vector3 targetPosition;
    Camera cam;
    Vector3 scale;

    // Sets scale of background to screen size
    void Start()
    {
        speed = 1f;
        cam = Camera.main;
        scale = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        transform.localScale = new Vector3(scale.x / 2.5f, scale.y / 5f, 1f);
        TargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        // Destroys planet background if it goes below the screen
        if(transform.position.y <= targetPosition.y) {
            Destroy(gameObject);
        }
    }

    // Set targetPosition to bottom of screen
    public void TargetPosition()
    {
        Vector3 tempPosition = cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        targetPosition = new Vector3(transform.position.x, tempPosition.y - 5, transform.position.z);
    }

    // Movement method
    public void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
