using UnityEngine;
using UnityEngine.UI;
public class tochandsow : MonoBehaviour
{
    public GameObject[] ObjectList;
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                for (int i = 0; i < ObjectList.Length; i++)
                {

                    if (hit.collider.gameObject.name == ObjectList[i].name)
                    {

                        ObjectList[i].transform.GetChild(0).gameObject.SetActive(true);
                    }
                    else
                    {
                        ObjectList[i].transform.GetChild(0).gameObject.SetActive(false);

                    }
                }
            }
        }

    }
}
