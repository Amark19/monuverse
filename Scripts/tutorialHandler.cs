using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class tutorialHandler : MonoBehaviour
{
    public int c=0;
     void Awake()
    {
        
        if (PlayerPrefs.GetInt("il") == 0)
        {
            GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(4).transform.gameObject.SetActive(true);
            onClassroomModeTap();
        }
    }

    

    public void onClassroomModeTap(){
        GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(2).transform.gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(3).transform.gameObject.SetActive(false);
        
        Transform a=GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(4);
        
        if(c==0){                      
            a.transform.gameObject.SetActive(true);
            a.transform.GetChild(0).transform.gameObject.SetActive(true);
            c++;
        }
        else if(c==1){
            c++;
            a.transform.GetChild(0).transform.gameObject.SetActive(false);
            a.transform.GetChild(1).transform.gameObject.SetActive(true);
        }
        else if(c==2){
            c++;
            a.transform.GetChild(1).transform.gameObject.SetActive(false);
            a.transform.GetChild(2).transform.gameObject.SetActive(true);
        }
        else{
            c=0;        
            a.transform.GetChild(2).transform.gameObject.SetActive(false);
            a.transform.gameObject.SetActive(false);
        }
    }

}
