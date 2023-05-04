using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsHandler : MonoBehaviour
{
    public static string to_which_monu_quiz = "";
    public void tohome()
    {
        SceneManager.LoadScene("Home");
    }

    public void updatelocalstrg()
    {
        if (PlayerPrefs.GetInt("il") != 1)
        {
            PlayerPrefs.SetInt("il", 1);
        }
    }

    /////////////////////////////////////////


    public void toregister()
    {
        SceneManager.LoadScene("register");
    }
    public void toGate()
    {
        SceneManager.LoadScene("Home");
    }
    public void totutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void toadmin()
    {
        SceneManager.LoadScene("admin_login");
    }

    public void toaudiolang()
    {
        SceneManager.LoadScene("audioLangChange");
    }
    public void togateofindia()
    {
        SceneManager.LoadScene("gateofindia");
    }
    public void togateofindiaInfo()
    {
        SceneManager.LoadScene("gateofindiaInfo");
    }
    public void toplacedgateofindiaInfo()
    {
        SceneManager.LoadScene("placedgateofindia");
    }

    /////////////////////////////////////////

    public void toDemo()
    {
        SceneManager.LoadScene("demo");
    }
    public void todemoCharminar()
    {
        SceneManager.LoadScene("demo1");
    }

    ///////////////////////////////////////////
    public void toplacetajmahal()
    {
        SceneManager.LoadScene("placedtajmahal");
    }
    public void toplacecharminar()
    {
        SceneManager.LoadScene("placedcharminar");
    }
    public void toplacekedarnath()
    {
        SceneManager.LoadScene("placedkedarnath");
    }

    /////////////////////////////////////////


    public void to3Dcharminar()
    {
        to_which_monu_quiz = "charminar";
        SceneManager.LoadScene("charminar");
    }
    public void to3Dtajmahal()
    {
        to_which_monu_quiz = "tajmahal";
        SceneManager.LoadScene("tajmahal");
    }
    public void to3Dkedarnath()
    {
        SceneManager.LoadScene("kedarnath");
    }
    public void to3Dexplorekedarnath()
    {
        SceneManager.LoadScene("exploremodeKedarnath");
    }
    public void to3DexploreDYP()
    {
        SceneManager.LoadScene("explorDYP");
    }

    ////////////////////////////////////

    public void toClassroom()
    {
        SceneManager.LoadScene("classroom_H");
    }
    public void toExplore()
    {
        SceneManager.LoadScene("exploration_H");
    }

    ///////////////////////////////////

    public void toquiztaj()
    {
        SceneManager.LoadScene("arquizui");
    }
    public void toActivity()
    {
        SceneManager.LoadScene("ar_puzzle");
    }
    public void toculturehome()
    {
        SceneManager.LoadScene("CultureHome");
    }
    public void tomonumenthome()
    {
        SceneManager.LoadScene("MonumentsHome");
    }
    /////////////////////////////////

    public void toClassGatewayofindia()
    {
        SceneManager.LoadScene("gateWayOfIndiaInfo");
    }
    public void toClassTajmahal()
    {
        SceneManager.LoadScene("tajmahalInfo");
    }
    public void toClassroomKedarnath()
    {
        SceneManager.LoadScene("kedarnathClassroomModeInfo");
    }
    public void toClassCharminar()
    {
        SceneManager.LoadScene("charminarInfo");
    }

    public void toExploreKedarnath()
    {
        SceneManager.LoadScene("kedarnathExploreModeInfo");
    }

    //////////////////////////////

    public void tousersettings()
    {
        SceneManager.LoadScene("UserSettings");
    }

    ///////////////////////////////

    public void toculturerajasthan()
    {
        SceneManager.LoadScene("culturerajasthan");
    }
    public void toculturemaharashtra()
    {
        SceneManager.LoadScene("culturemaharashtra");
    }
    public void toculturekerla()
    {
        SceneManager.LoadScene("culturekerla");
    }

    /////////////////////////////////

    public void toauth()
    {
        //publicval.is_sign = 0;
        if (publicval.user == null)
        {
            SceneManager.LoadScene("auth");
        }
    }
    public void signoutt()
    {
        publicval.auth.SignOut();
        publicval.is_sign = 0;
        SceneManager.LoadScene("auth");
    }
}
