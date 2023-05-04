using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dypExplore : MonoBehaviour
{

    public GameObject doors;
    public GameObject instructionText;

    void Update()
    {
        if ((Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) || (Input.GetMouseButton(0)))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "audi Managment")
                {
                    //play animation
                    doors.GetComponent<Animation>().Play("door_sliding");
                    //disable the text
                    instructionText.SetActive(false);
                }
            }
        }
    }

}
