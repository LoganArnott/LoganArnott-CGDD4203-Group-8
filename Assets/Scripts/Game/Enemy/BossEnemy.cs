using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : EnemyBase
{
    public GameObject Enembullet;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        SpeedMultipler();
        TargetPosition();
        points = 50;
        health = 10;
        timer = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

        if (timer <= 0f)
        {
            StartCoroutine(Shoot());
            timer = 1f;
        }
        else
        {
            timer -= Time.deltaTime;
        }
       
    }


    public virtual void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            health -= 1;
        }
    }



    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1f);

            float speed = 10;
            // Where the bullet will be created
            Vector3 shotSpawn = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);

            // Creates 1 bullet at shotSpawn
            GameObject g = Instantiate(Enembullet, shotSpawn, Quaternion.identity) as GameObject;
            Rigidbody bulletRig = g.GetComponent<Rigidbody>();
            bulletRig.velocity = transform.up * speed *-1 ;
            Destroy(g, 0.5f);
            StopCoroutine(Shoot());
    }



    }
