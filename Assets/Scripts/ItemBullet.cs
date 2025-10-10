using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBullet : MonoBehaviour
{
    GameObject player;
    Camera cam;
    Vector3 height;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        cam = Camera.main;
        height = cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        transform.localScale = new Vector3(0.2f, height.y, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Enemy") {
            col.gameObject.GetComponent<EnemyBase>().health = 0;
        }
    }
}
