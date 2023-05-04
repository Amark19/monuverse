using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class adminlogin : MonoBehaviour
{
    public InputField Email, password;
    public Text error;
    public GameObject err;

    public void signinn()
    {
        if (Email.text == "yashpandhare9870@gmail.com" && password.text == "123456")
        {
            SceneManager.LoadScene("admin_home");
        }
        else
        {
            err.SetActive(true);
            error.text = "Incorrect Password or Email.";
        }
    }
    public void cloose()
    {
        err.SetActive(false);
    }
}
