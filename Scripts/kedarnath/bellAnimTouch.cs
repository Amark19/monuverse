using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class bellAnimTouch : MonoBehaviour
{
    public AudioSource bell;
    bool is_play = true;
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.gameObject.name == "bell_trig" && is_play)
                {
                    this.GetComponent<Animation>().Play("bell-animation");
                    bell.Play();
                    is_play = false;
                    StartCoroutine(wait());
                }
            }
        }

    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(6f);
        is_play = true;
    }
}
