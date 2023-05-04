using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class displayQues_acc_monument : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] mcqList;
    public Material right, wrong, actual;
    public TextMesh question;
    public Text curr_scr;
    string[,] current_monument_arr;
    int qs_no = 0;
    bool handle_click = true;
    public GameObject show_scoreBtn;
    void Start()
    {
        if (ButtonsHandler.to_which_monu_quiz == "tajmahal")
        {
            scores_details_tracker.current_score = 0;
            scores_details_tracker.current_monument = "tajmahal";
            current_monument_arr = all_quizzes_dict.tajMahalQuiz;
            displayQs(current_monument_arr);
            //Debug.Log(current_monument_arr.GetLength(0));
        }
        else if (ButtonsHandler.to_which_monu_quiz == "charminar")
        {
            scores_details_tracker.current_score = 0;
            scores_details_tracker.current_monument = "charminar";
            current_monument_arr = all_quizzes_dict.charminar;
            displayQs(current_monument_arr);
        }
    }
    void Update()
    {
        if ((Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && handle_click) || (Input.GetMouseButton(0) && handle_click))
        {
            validClickOptions();
            handle_click = false;
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        handle_click = true;
    }
    public void displayQs(string[,] qs)
    {
        question.text = qs[qs_no, 0];
        for (int i = 0; i < mcqList.Length; i++)
        {
            mcqList[i].transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = qs[qs_no, i + 1];
        }
    }
    public void validClickOptions()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            for (int i = 0; i < mcqList.Length; i++)
            {

                if (hit.collider.gameObject.name == mcqList[i].name)
                {

                    if (qs_no < current_monument_arr.GetLength(0))
                    {
                        if (mcqList[i].transform.GetChild(0).gameObject.GetComponent<TextMesh>().text == current_monument_arr[qs_no, 5])
                        {
                            //change material to right
                            mcqList[i].transform.gameObject.GetComponent<Renderer>().material = right;
                            scores_details_tracker.current_score += 1;
                        }
                        else
                        {
                            //change material to wrong
                            mcqList[i].transform.gameObject.GetComponent<Renderer>().material = wrong;

                        }

                        qs_no += 1;
                        //coroutine common
                        StartCoroutine(hold(mcqList[i].transform.gameObject, current_monument_arr, false));

                    }
                    if (qs_no >= current_monument_arr.GetLength(0))
                    {
                        StartCoroutine(hold(mcqList[i].transform.gameObject, current_monument_arr, true));
                        //Debug.Log(mcqList[i].transform.gameObject);

                    }

                }
            }
        }
    }
    IEnumerator hold(GameObject temp, string[,] current_pass_monument_arr, bool is_last)
    {
        yield return new WaitForSeconds(.5f);
        temp.GetComponent<Renderer>().material = actual;
        if (is_last)
        {
            qs_no += 1;
            this.transform.GetChild(0).gameObject.SetActive(false);
            curr_scr.text = scores_details_tracker.current_score.ToString();
            show_scoreBtn.SetActive(true);
        }
        else
        {
            displayQs(current_pass_monument_arr);

        }

    }

}