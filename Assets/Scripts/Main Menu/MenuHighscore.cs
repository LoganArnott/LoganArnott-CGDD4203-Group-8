using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuHighscore : MonoBehaviour
{
    public TMP_Text highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "Highscore: \n" + PlayerPrefs.GetInt("Highscore").ToString();
    }
}
