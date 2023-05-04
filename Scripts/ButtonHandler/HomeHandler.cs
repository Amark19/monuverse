using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeHandler : MonoBehaviour
{
    public Text Wusername, Navname;
    public GameObject NavPop, bck;
    public GameObject UserSettings;
    public GameObject Logout;
    public void NavHandlePopactive()
    {
        NavPop.SetActive(true);
        bck.SetActive(true);
    }
    public void NavHandlePopDeactive()
    {
        bck.SetActive(false);
        NavPop.SetActive(false);

    }

    private void Start()
    {
        if(publicval.auth.CurrentUser != null){
            Wusername.text = "Welcome, " + publicval.auth.CurrentUser.DisplayName + " !";
            Navname.text = "Hello, " + publicval.auth.CurrentUser.DisplayName;
        }
        else{
            Wusername.text = "Welcome, Guest !";
            Navname.text = "Hello, Guest";
            UserSettings.SetActive(false);
            Logout.SetActive(false);
        }
    }

}
