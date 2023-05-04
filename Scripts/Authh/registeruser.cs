using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;
public class registeruser : MonoBehaviour
{

    public Text email, username;
    public InputField Email, password;
    public Text errors;
    string errtxt;
    public Sprite red, green;
    bool checkinvalid = false;
    public GameObject ShowError;
    // Start is called before the first frame update
    void Start()
    {
        publicval.auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        publicval.auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }
    void Update()
    {
        if (publicval.is_sign == 1) { Debug.Log("idhar ara kya bro?"); StartCoroutine(wait()); }
        if (checkinvalid)
        {
            activeShowError();
            errors.text = "";
            errors.text = errtxt;
            checkinvalid = false;
        }
    }
    IEnumerator wait()
    {
        //activeShowError();
        //
        ShowError.GetComponent<Image>().sprite = green;
        errors.text = "";
        errors.text = "Account created!! Redirecting to home page!!";
        yield return new WaitForSeconds(2);
        // errors.GetComponent<Image>().color = Color(255, 40, 0, 150);
        SceneManager.LoadScene("Home");
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
            }
            publicval.user = publicval.auth.CurrentUser;
            if (signedIn)
            {
                publicval.is_sign = 1;
                Debug.Log("Signed in " + publicval.user.UserId);
            }
        }
    }

    public void createauth()
    {
        if (Email.text == "" || password.text == "" || username.text == "")
        {
            activeShowError();
            errors.text = "fields cannot be empty";
            return;
        }

        publicval.auth.CreateUserWithEmailAndPasswordAsync(Email.text, password.text).ContinueWith(task =>
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
                        errtxt = "email is invalid or already exists";
                    }
                    return;
                }

                // Firebase user has been created.
                Firebase.Auth.FirebaseUser newUser = task.Result;
                Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile
                {
                    DisplayName = username.text.ToString(),
                };
                newUser.UpdateUserProfileAsync(profile);

                publicval.is_sign = 1;
                Debug.LogFormat("Firebase user created successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);


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
