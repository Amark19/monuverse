using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class userSettings : MonoBehaviour
{
    public GameObject confirm;
    public GameObject error;

    public Text errtxt;

    int is_delete = 0;
    int is_error = 0;

    string errtext;

    public void to_usernameUpdate(){
        SceneManager.LoadScene("userNameUpdate");
    }
    public void to_emailUpdate(){
        SceneManager.LoadScene("emailUpdate");
    }
    public void to_passwordUpdate(){
        SceneManager.LoadScene("passwordUpdate");
    }
    private void Update()
    {
        if (is_delete == 1)
        {
            StartCoroutine(wait());
        }
        if (is_error == 1)
        {
            error.SetActive(true);
            is_error = 0;
        }
    }
    IEnumerator wait()
    {
        error.SetActive(true);
        errtxt.text = "";
        errtxt.text = "Deleted suceesfully.Redirecting to login page";
        publicval.user = null;
        is_delete = 0;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("auth");
    }
    public void DeleteAccnt()
    {
        confirm.SetActive(true);
    }
    public void Yes()
    {
        if (publicval.user != null)
        {

            publicval.user.DeleteAsync().ContinueWith(task =>
            {
                if (task.IsCanceled)
                {
                    error.SetActive(true);
                    return;
                }
                if (task.IsFaulted)
                {
                    is_error = 1;
                    return;
                }
                is_delete = 1;

            });
        }
    }
    public void No()
    {
        confirm.SetActive(false);
    }
}
