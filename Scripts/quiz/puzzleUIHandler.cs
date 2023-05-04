using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class puzzleUIHandler : MonoBehaviour
{
    public GameObject refImgPanel;
    public GameObject completePanel;
    public GameObject refBtn;
    public Text puzzle_size;

    public void showRefImage()
    {
        refImgPanel.SetActive(true);
        refImgPanel.transform.GetChild(0).gameObject.GetComponent<RawImage>().texture = ar_puzzle.originalImage;
    }


    public void closeRefImgPanel()
    {
        refImgPanel.SetActive(false);
    }

    public void showNextPanel(int size)
    {
        Debug.Log(size);
        puzzle_size.text = $"{size}x{size} puzzle";
        completePanel.SetActive(true);
        refBtn.SetActive(false);
    }

    public void closeNextPanel()
    {
        completePanel.SetActive(false);
        refBtn.SetActive(true);
    }
}
