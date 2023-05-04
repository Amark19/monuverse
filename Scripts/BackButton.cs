using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
 {
    public GameObject fade;
    public void BackB()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);               
    }
}