using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class passwordUpdate : MonoBehaviour
{
    public InputField current_pass;

    bool checkinvalid = false;

    bool checkvalid = false;

    public GameObject error;
    public Text err;
    public GameObject newPassSec;
    public InputField newPass;
    public InputField confirmPass;
    public GameObject checkBtn;
    int should_update = 0;

    // Update is called once per frame
    void Update()
    {
        if (checkinvalid)
        {
            error.SetActive(true);
            err.text = "Invalid Password";
        }
        if (checkvalid)
        {
            error.SetActive(false);
            newPassSec.SetActive(true);
            checkvalid = false;
            checkBtn.SetActive(false);
        }
        if (should_update == 1)
        {
            StartCoroutine(wait());
        }
    }
    IEnumerator wait()
    {
        error.SetActive(true);
        err.text = "";
        err.text = "Password updated successfully!";
        publicval.is_sign = 0;
        publicval.auth.SignOut();
        should_update = 0;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("auth");
    }

    public void validate_currentPass()
    {
        publicval.auth.SignInWithEmailAndPasswordAsync(publicval.user.Email, current_pass.text).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                checkinvalid = true;
                return;
            }
            if (task.IsFaulted)
            {
                checkinvalid = true;
                return;
            }
            checkvalid = true;
            checkinvalid = false;
        });
    }

    public bool check_password_valid()
    {
        if (newPass.text != confirmPass.text)
        {
            error.SetActive(true);
            err.text = "Password Don't Match !";
            return false;
        }
        else if (newPass.text == "" || confirmPass.text == "")
        {
            error.SetActive(true);
            err.text = "Fields cannot be Empty !";
            return false;
        }
        else if (newPass.text.Length < 6)
        {
            error.SetActive(true);
            err.text = "Password length should be greater than 5";
            return false;
        }
        return true;
    }
    public void update_password()
    {
        if (check_password_valid())
        {
            if (publicval.user != null)
            {
                publicval.user.UpdatePasswordAsync(confirmPass.text).ContinueWith(task =>
                {
                    if (task.IsCanceled)
                    {
                        Debug.LogError("UpdatePasswordAsync was canceled.");
                        return;
                    }
                    if (task.IsFaulted)
                    {
                        Debug.LogError("UpdatePasswordAsync encountered an error: " + task.Exception);
                        return;
                    }
                    should_update = 1;
                });
            }

        }
        else
        {

        }
    }

    public void close()
    {
        error.SetActive(false);
    }

}
