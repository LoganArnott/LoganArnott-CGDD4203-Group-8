using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemyBase
{

    // Start is called before the first frame update
    void Start()
    {
        SpeedMultipler();
        TargetPosition();
        points = 40;
        health = 5;

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if(transform.position.y <= targetPosition.y) {
            Destroy(gameObject);
        }
    }
}
