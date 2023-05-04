using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class userNameUpdt : MonoBehaviour
{
    public Text oldusername;
    public InputField newusername;
    public GameObject error;
    public Text errtxt;
    int is_issue = 0;
    int is_okay  = 0;
    // Start is called before the first frame update
    void Start()
    {
        oldusername.text = publicval.user.DisplayName;
    }
    void Update(){
        if (is_okay== 1)
        {
            StartCoroutine(wait());
        }
        if (is_issue == 1)
        {
            error.SetActive(true);
            errtxt.text = "Uhh..There is some issue !";
            is_issue = 0;
        }
    }
    IEnumerator wait()
    {
        error.SetActive(true);
        errtxt.text = "";
        errtxt.text = "Username updated successfully!";
        is_okay = 0;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Home");
    }
    public void save()
    {
        if (newusername.text == "")
        {
            error.SetActive(true);
            errtxt.text = "Fields cannot be null !";
        }
        else if (newusername.text == oldusername.text)
        {
            error.SetActive(true);
            errtxt.text = "New username cannot be same as old one!";
        }
        else if (newusername.text.Length < 4)
        {
            error.SetActive(true);
            errtxt.text = "Username length should be atleast 4";
        }
        else
        {

            if (publicval.user != null)
            {
                Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile
                {
                    DisplayName = newusername.text,
                };
                publicval.user.UpdateUserProfileAsync(profile).ContinueWith(task =>
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
                    //Debug.Log("User profile updated successfully.");
                });
            }
        }
    }
    public void closebtn(){
        error.SetActive(false);
    }

}
