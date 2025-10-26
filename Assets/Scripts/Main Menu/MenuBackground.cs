using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackground : MonoBehaviour
{
    Camera cam;
    Vector3 scale;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        scale = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        transform.localScale = new Vector3(scale.x / 2.5f, scale.y / 5f, 1f);
    }
}
