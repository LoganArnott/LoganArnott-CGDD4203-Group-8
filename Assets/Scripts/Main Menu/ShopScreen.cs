using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopScreen : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("Monetization");
    }
}
