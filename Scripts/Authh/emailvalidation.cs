using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;
public class emailvalidation : MonoBehaviour
{
    public InputField Email, password;
    public Text errors;
    string errtxt;
    bool checkinvalid = false;
    public GameObject ShowError;

    // username;
    void Start()
    {
        publicval.auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        publicval.auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    void Update()
    {
        if (publicval.is_sign == 1) { SceneManager.LoadScene("Home"); }
        if (checkinvalid)
        {
            activeShowError();
            errors.text = "";
            errors.text = errtxt;
            checkinvalid = false;
        }
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (publicval.auth.CurrentUser != publicval.user)
        {
            bool signedIn = publicval.user != publicval.auth.CurrentUser && publicval.auth.CurrentUser != null;
            if (!signedIn && publicval.user != null)
            {
                publicval.is_sign = 0;
                Debug.Log("Signed out " + publicval.user.UserId);
                activeShowError();
                errors.text = "Signed Out";
            }
            publicval.user = publicval.auth.CurrentUser;
            if (signedIn)
            {
                publicval.is_sign = 1;
                //activeShowError();
                Debug.Log("Signed in " + publicval.user.UserId);
            }
        }
    }

    public void emailauth()
    {
        if (Email.text == "" || password.text == "")
        {
            activeShowError();
            errors.text = "email or password cannot be empty";
            return;
        }
        publicval.auth.SignInWithEmailAndPasswordAsync(Email.text, password.text).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                checkinvalid = true;
                return;
            }
            if (task.IsFaulted)
            {
                checkinvalid = true;
                if (password.text.Length < 6)
                {
                    errtxt = "password length is less than 6";
                }
                else
                {
                    errtxt = "Invalid Credentials!";
                }
                return;
            }
            Firebase.Auth.FirebaseUser newUser = task.Result;
            publicval.is_sign = 1;
        });
    }

    public void activeShowError()
    {
        ShowError.SetActive(true);
    }

    public void deactiveShowError()
    {
        ShowError.SetActive(false);
    }


}
