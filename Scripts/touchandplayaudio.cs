using UnityEngine;
using UnityEngine.UI;
public class touchandplayaudio: MonoBehaviour
{
   public AudioSource audsHindi,audsEng;
   public Sprite playy,pausee;
   public Button audioBtn;
   int a=0;
    public void playaudi()
    {
  
      
       if(a==0 && publicval.lang ==0){
          audsEng.Play();
          audioBtn.GetComponent<Image>().sprite=pausee;
     
          a=1;
     } 
     else if(a==0 && publicval.lang==1){
          audsHindi.Play();
          audioBtn.GetComponent<Image>().sprite=pausee;
          a=1;
       }
        else{
          audsEng.Pause();
            audsHindi.Pause();
          audioBtn.GetComponent<Image>().sprite=playy;
          a=0;
       } 
       
    }
}
