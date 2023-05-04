using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioLangChange : MonoBehaviour
{
    public Sprite enabled,disabled;
   public Button hindiLang,engLang;
 void Start(){
 if(publicval.lang==1){
      hindiLang.GetComponent<Image>().sprite=enabled;
        engLang.GetComponent<Image>().sprite=disabled;
 }
 else{
     hindiLang.GetComponent<Image>().sprite=disabled;
        engLang.GetComponent<Image>().sprite=enabled;
 }
}
   public void Hindi(){
        publicval.lang=1;
        hindiLang.GetComponent<Image>().sprite=enabled;
        engLang.GetComponent<Image>().sprite=disabled;
    }

   public void English(){
        publicval.lang=0;
        hindiLang.GetComponent<Image>().sprite=disabled;
        engLang.GetComponent<Image>().sprite=enabled;
   }

}
