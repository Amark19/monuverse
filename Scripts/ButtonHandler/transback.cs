using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class transback : MonoBehaviour
{
    public GameObject navmenu, btnnn;
    public void backnav()
    {
        navmenu.SetActive(false);
        btnnn.SetActive(false);
    }
}