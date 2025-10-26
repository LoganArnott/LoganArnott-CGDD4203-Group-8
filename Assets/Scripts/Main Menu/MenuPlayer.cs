using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayer : MonoBehaviour
{
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        Vector3 temp = cam.ScreenToWorldPoint(new Vector3(Screen.width * 50 / 100, Screen.height * 15 / 100, 0));
        transform.position = new Vector3(temp.x, temp.y, transform.position.z);
    }
}
