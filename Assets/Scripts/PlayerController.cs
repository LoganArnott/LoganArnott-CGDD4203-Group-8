using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    private Touch touch;
    Vector2 startTouchPosition;
    Vector2 currentTouchPosition;
    // Used to check if player is to the left/right of screen
    int positionCheck = 0;
    // Threshold to detect dragging touch
    float dragDistance;
    // Used to detect if the player has already swiped before lifting their finger
    bool swiped = false;
    Camera cam;
    // Where the player will move to
    Vector3 targetPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        dragDistance = Screen.width * 15 / 100;
        cam = Camera.main;
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Mobile Devices
        #if UNITY_IOS || UNITY_ANDROID
        
        // Moves the player to targetPosition
        if(Mathf.Abs(transform.position.x - targetPosition.x) > 0.1f) {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 20 * Time.deltaTime);
        } else if(Mathf.Abs(transform.position.x - targetPosition.x) <= 0.1f) {
            transform.position = targetPosition;
        }

        // Checking touch
        if(Input.touchCount > 0) {
            // Detects multiple touches
            for(int i = 0; i < Input.touchCount; i++) {
                touch = Input.GetTouch(i);
                // Position of touch at touch begin
                if(touch.phase == TouchPhase.Began) {
                    startTouchPosition = Input.GetTouch(i).position;
                }

                // Tracks the current position of the player's finger
                currentTouchPosition = Input.GetTouch(i).position;

                // Swipe right 
                if((currentTouchPosition.x - startTouchPosition.x) > dragDistance) {
                    MoveRight();
                }
                // Swipe left
                if((currentTouchPosition.x - startTouchPosition.x) < (dragDistance * -1)) {
                    MoveLeft();
                }
            }
            // Resets swiped at touch end
            if(touch.phase == TouchPhase.Ended) {
                swiped = false;
            }
        }

        // Desktop
        #else

        if(Input.GetKeyDown("d")) {
            if(positionCheck != 1) {
                Vector3 tempPosition = cam.ScreenToWorldPoint(new Vector3(Screen.width * 20 / 100, 0, 0));
                transform.position -= new Vector3(tempPosition.x, 0, 0);
                positionCheck += 1;
            }
        }
        if(Input.GetKeyDown("a")) {
            if(positionCheck != -1) {
                Vector3 tempPosition = cam.ScreenToWorldPoint(new Vector3(Screen.width * 20 / 100, 0, 0));
                transform.position += new Vector3(tempPosition.x, 0, 0);
                positionCheck -= 1;
            }
        }

        #endif
    }

    // Sets targetPosition to the right of the player
    void MoveRight()
    {
        // Checks if the player is at the right of the screen and has already swiped before lifting their finger
        if(positionCheck != 1 && !swiped) {
            Vector3 tempPosition = cam.ScreenToWorldPoint(new Vector3(Screen.width * 20 / 100, 0, 0));
            targetPosition = new Vector3(transform.position.x - tempPosition.x, -2.5f, 0);
            positionCheck += 1;
        }

        swiped = true;
    }

    // Sets targetPosition to the left of the player
    void MoveLeft()
    {
        // Checks if the player is at the left of the screen and has already swiped before lifting their finger
        if(positionCheck != -1 && !swiped) {
            Vector3 tempPosition = cam.ScreenToWorldPoint(new Vector3(Screen.width * 20 / 100, 0, 0));
            targetPosition = new Vector3((transform.position.x + tempPosition.x), -2.5f, 0);
            positionCheck -= 1;
        }

        swiped = true;
    }
}
