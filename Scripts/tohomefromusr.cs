using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class tohomefromusr : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
      if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Home");
        }   
    }
}
