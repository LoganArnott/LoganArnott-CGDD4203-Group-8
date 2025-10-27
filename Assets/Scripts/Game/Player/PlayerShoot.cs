using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerShoot : MonoBehaviour
{
    private Touch touch;
    Vector2 startTouchPosition;
    Vector2 endTouchPosition;
    float dragDistance;
    float startTime;
    float endTime;
    public GameObject bullet;
    public GameObject itemBullet;
    bool hasItem = false;
    bool itemShoot = false;
    Camera cam;
    Vector3 height;
    float timer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        dragDistance = Screen.width * 10 / 100;
        cam = Camera.main;
        height = cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
    }

    // Update is called once per frame
    void Update()
    {
        // Mobile Devices
        #if UNITY_IOS || UNITY_ANDROID

        // Checking touch
        if(Input.touchCount > 0) {
            // Detects multiple touches
            for(int i = 0; i < Input.touchCount; i++) {
                touch = Input.GetTouch(i);
                // Position of touch and time at touch begin
                if(touch.phase == TouchPhase.Began) {
                    startTouchPosition = Input.GetTouch(i).position;
                    startTime = Time.time;
                }

                // Position of touch and time at touch end
                if(touch.phase == TouchPhase.Ended) {
                    endTouchPosition = Input.GetTouch(i).position;
                    endTime = Time.time;
                    // If its a click and not a hold/drag
                    if((Mathf.Abs(endTouchPosition.x - startTouchPosition.x)) < dragDistance && 
                       (endTime - startTime) < 0.5f && !itemShoot) {
                        Shoot();
                    }
                    if((Mathf.Abs(endTouchPosition.x - startTouchPosition.x)) < dragDistance && 
                       (endTime - startTime) > 3f && hasItem) {
                        ItemShoot();
                    }
                }
            }
        }

        // Desktop
        #else

        if(Input.GetKeyDown("space") && !itemShoot) {
            Shoot();
        }
        if(Input.GetKeyDown("left shift") && hasItem) {
            ItemShoot();
        }

        #endif

        // So you can't shoot until the item is finished being used
        if(itemShoot) {
            timer -= Time.deltaTime;
            if(timer <= 0) {
                itemShoot = false;
                timer = 5f;
            }
        }
    }

    // Shoots a bullet
    void Shoot()
    {
        float speed = 15;
        // Where the bullet will be created
        Vector3 shotSpawn = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        
        // Creates 1 bullet at shotSpawn
        GameObject g = Instantiate (bullet, shotSpawn, Quaternion.identity) as GameObject;
        Rigidbody bulletRig = g.GetComponent<Rigidbody>();
        bulletRig.velocity = transform.up * speed;
        Destroy (g, 0.5f);
    }

    void ItemShoot()
    {
        itemShoot = true;
        // Where the bullet will be created
        Vector3 shotSpawn = new Vector3(transform.position.x, transform.position.y + (height.y / 1.25f), transform.position.z);
        
        // Creates 1 bullet at shotSpawn
        GameObject g = Instantiate (itemBullet, shotSpawn, Quaternion.identity) as GameObject;
        Rigidbody bulletRig = g.GetComponent<Rigidbody>();
        Destroy (g, 5f);
        hasItem = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Item") {
            hasItem = true;
        }
    }
}
