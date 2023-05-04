using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class emailUpdate : MonoBehaviour
{
    public Text oldemail;
    public InputField newemail;
    public GameObject error;
    public Text errtxt;
    int is_issue = 0;
    int is_okay  = 0;
    // Start is called before the first frame update
    void Start()
    {
        oldemail.text = publicval.user.Email;
    }
    void Update(){
        if (is_okay== 1)
        {
            StartCoroutine(wait());
        }
        if (is_issue == 1)
        {
            error.SetActive(true);
            errtxt.text = "Invalid Email !";
            is_issue = 0;
        }
    }
    IEnumerator wait()
    {
        error.SetActive(true);
        errtxt.text = "";
        errtxt.text = "Email updated successfully!";
        publicval.is_sign = 0;
        publicval.auth.SignOut();
        is_okay = 0;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("auth");
    }
    public void save()
    {
        if (newemail.text == "")
        {
            error.SetActive(true);
            errtxt.text = "Fields cannot be null !";
        }
        else if (newemail.text == oldemail.text)
        {
            error.SetActive(true);
            errtxt.text = "New email cannot be same as old one!";
        }
        else
        {

            if (publicval.user != null)
            {
                publicval.user.UpdateEmailAsync(newemail.text).ContinueWith(task =>
                {
                    if (task.IsCanceled)
                    {
                        is_issue = 1;
                        return;
                    }
                    if (task.IsFaulted)
                    {
                        is_issue = 1;
                        Debug.LogError("UpdateUserProfileAsync encountered an error: " + task.Exception);
                        return;
                    }
                    is_okay = 1;
                });
            }
        }
    }
    public void closebtn(){
        error.SetActive(false);
    }
}
