using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingBar : MonoBehaviour
{
    Camera cam;
    Vector3 scale;

    float transformX;
    float scaleX;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        scale = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        transform.localScale = new Vector3(scale.x / 100f, scale.y / 25f, 1f);
        transform.position = new Vector3(scale.x * 0.875f * -1f, transform.position.y, transform.position.z);
        transformX = transform.position.x;
        scaleX = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        transformX += 0.5f * Time.deltaTime;
        scaleX += 1f * Time.deltaTime;
        transform.position = new Vector3(transformX, transform.position.y, transform.position.z);
        transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        if(scaleX > scale.x * 1.75f)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
