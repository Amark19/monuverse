using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playPauseMusicInKedarnath : MonoBehaviour
{public AudioSource namonamoShankara;
   public Sprite playy,pausee;
   public Button audioBtn;
   int a=0;
    public void playaudi()
    {
       if(a==0 ){
         namonamoShankara.Play();
         audioBtn.GetComponent<Image>().sprite=pausee;
         a=1;
       }
        else{
        namonamoShankara.Pause();
        audioBtn.GetComponent<Image>().sprite=playy;
        a=0;
       } 
       
    }
    }

