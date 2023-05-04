using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;
using Firebase.Extensions;
using UnityEngine.SceneManagement;

public class displayScoreHist : MonoBehaviour
{
    public GameObject user_card;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        fetchData(user_card);
    }
    public static async Task fetchData(GameObject user_card)
    {
        float x = 0f;
        float y = 2500f;
        FirebaseFirestore db;
        db = FirebaseFirestore.DefaultInstance;
        Query docRef = db.Collection("user_scores").Document(publicval.user.Email).Collection("user_details");
        QuerySnapshot userDet = await docRef.GetSnapshotAsync();
        foreach (DocumentSnapshot snapshot in userDet.Documents)
        {
            string monu = "";
            string score = "";
            string time = "";
            GameObject obj = Instantiate(user_card, new Vector3(0, 0, 0), Quaternion.identity);
            obj.transform.parent = GameObject.Find("bg").transform;
            obj.transform.localPosition = new Vector3(x, y, 0);
            obj.transform.localScale = new Vector3(1, 1, 1);
            await db.Collection("user_scores").Document(publicval.user.Email).Collection("user_details").Document(snapshot.Id).GetSnapshotAsync().ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    DocumentSnapshot s = task.Result;

                    monu = s.ToDictionary()["monument_type"].ToString();
                    score = s.ToDictionary()["user_score"].ToString();
                    time = s.ToDictionary()["time"].ToString();

                    if (s.Exists)
                    {
                        return;
                    }
                }
            });

            if (monu != "" && score != "")
            {
                obj.transform.GetChild(0).transform.gameObject.GetComponent<Text>().text += score;
                obj.transform.GetChild(1).transform.gameObject.GetComponent<Text>().text += monu;
                obj.transform.GetChild(2).transform.gameObject.GetComponent<Text>().text += time;
                y -= 300;
            }

        }
    }
}
