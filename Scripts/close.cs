using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class close : MonoBehaviour
{

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "gateofindia"){
            ar_puzzle.monument = "gateofindia";
        }
        else if(SceneManager.GetActiveScene().name == "kedarnath"){
            ar_puzzle.monument = "kedarnath";
        }
        if (publicval.scenes.Count <= 1 || (SceneManager.GetActiveScene().name) != (publicval.scenes.Peek()))
            publicval.scenes.Push(SceneManager.GetActiveScene().name);

    }
    void Update()
    {
        previousScene();
    }

    public void previousScene()
    {
        //Debug.Log(publicval.scenes.Count);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (publicval.scenes.Count < 1)
            {
                Application.Quit();
            }
            else
            {
                publicval.scenes.Pop();
                string sceneToBuild = publicval.scenes.Peek();
                loadScene(sceneToBuild);
            }
        }
    }

    public void loadScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }
}