using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource audioData;
    public AudioSource audioData2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyDeath()
    {
        audioData2.PlayOneShot(audioData2.clip);
    }
    
    public void PlayerDeath()
    {
        audioData.PlayOneShot(audioData.clip);
    }
}
