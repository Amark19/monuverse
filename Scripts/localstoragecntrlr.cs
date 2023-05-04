using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class localstoragecntrlr : MonoBehaviour
{
    void Awake()
    {
        if (PlayerPrefs.GetInt("il") == 1)
        {
            SceneManager.LoadScene("auth");
        }
    }

}
