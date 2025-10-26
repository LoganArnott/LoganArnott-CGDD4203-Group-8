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

    public virtual void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Bullet") {
            health -= 1;
        }
    }
}
