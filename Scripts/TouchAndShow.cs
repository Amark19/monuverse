using UnityEngine;
using UnityEngine.UI;
public class TouchAndShow : MonoBehaviour
{
   public GameObject[] ObjectList;
   public int a=0;
    void Update ()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            AudioSource audioSource;
            if(Physics.Raycast(ray, out hit) && publicval.lang==1)
            {
                 for (int i = 0; i < ObjectList.Length; i++)
                 {
                   
            if(hit.collider.gameObject.name==ObjectList[i].name )
                {
                    if(i==3 || i==4){
                         audioSource=ObjectList[i].transform.GetComponent<AudioSource>();
                    }
                    else{
                    audioSource=ObjectList[i].transform.GetChild(0).transform.GetComponent<AudioSource>();}
                     if (!audioSource.isPlaying)
        {
           
            audioSource.Play();
        }else{
            audioSource.Pause();
        }
                    // ObjectList[i].transform.GetChild(0).gameObject.SetActive(true);
                }
                // else{
                //     ObjectList[i].transform.GetComponent<AudioSource>().Pause();

                // }
                }          
            }
            if(Physics.Raycast(ray, out hit) && publicval.lang==0)
            {
                 for (int i = 0; i < ObjectList.Length; i++)
                 {
                    
                if(hit.collider.gameObject.name==ObjectList[i].name)
                {
                      if(i==3 || i==4){
                         audioSource=ObjectList[i].transform.GetComponent<AudioSource>();
                    }
                    else{
                    audioSource=ObjectList[i].transform.GetChild(1).transform.GetComponent<AudioSource>();}
                        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }else{
            audioSource.Pause();
        }
                    // ObjectList[i].transform.GetChild(0).gameObject.SetActive(true);
                }
                // else{
                //     ObjectList[i].transform.GetComponent<AudioSource>().Pause();

                // }
                }          
            }
        }
        
    }
}