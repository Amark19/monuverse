// NetworkingManager.cs
using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class download_url : MonoBehaviour
{
    public void downloadurl(){
        Application.OpenURL ("https://drive.google.com/file/d/18I71lOcvY35llxnyhQ-JnszXoS1_0k6f/view?usp=share_link");           
    }
}