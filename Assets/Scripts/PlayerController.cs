using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    private Touch touch;
    int positionCheck = 0;
    Vector2 startTouchPosition;
    Vector2 currentTouchPosition;
    float dragDistance;
    bool swiped = false;
    Camera cam;
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
        
        if(Mathf.Abs(transform.position.x - targetPosition.x) > 0.1f) {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 20 * Time.deltaTime);
        } else if(Mathf.Abs(transform.position.x - targetPosition.x) <= 0.1f) {
            transform.position = targetPosition;
        }

        if(Input.touchCount > 0) {
            for(int i = 0; i < Input.touchCount; i++) {
                touch = Input.GetTouch(i);
                if(touch.phase == TouchPhase.Began) {
                    startTouchPosition = Input.GetTouch(i).position;
                }

                currentTouchPosition = Input.GetTouch(i).position;

                if((currentTouchPosition.x - startTouchPosition.x) > dragDistance) {
                    MoveRight();
                }
                if((currentTouchPosition.x - startTouchPosition.x) < (dragDistance * -1)) {
                    MoveLeft();
                }
            }
            if(touch.phase == TouchPhase.Ended) {
                swiped = false;
            }
        }

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

    void MoveRight()
    {
        if(positionCheck != 1 && !swiped) {
            Vector3 tempPosition = cam.ScreenToWorldPoint(new Vector3(Screen.width * 20 / 100, 0, 0));
            targetPosition = new Vector3(transform.position.x - tempPosition.x, -2.5f, 0);
            positionCheck += 1;
        }

        swiped = true;
    }

    void MoveLeft()
    {
        if(positionCheck != -1 && !swiped) {
            Vector3 tempPosition = cam.ScreenToWorldPoint(new Vector3(Screen.width * 20 / 100, 0, 0));
            targetPosition = new Vector3((transform.position.x + tempPosition.x), -2.5f, 0);
            positionCheck -= 1;
        }

        swiped = true;
    }
}
