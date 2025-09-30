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
        points = 50;
        health = 3;

    }

    // // Update is called once per frame
    // void Update()
    // {

    // }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet") {
            health -= 1;
        }
    }
}
