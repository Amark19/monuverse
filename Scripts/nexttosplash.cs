using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class nexttosplash : MonoBehaviour
{
   
    public void Start()
    {
       
        StartCoroutine(logo());
    }

    IEnumerator logo() 
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("caro");
    }
}