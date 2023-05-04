using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;
using Firebase.Extensions;
using UnityEngine.SceneManagement;

public class firestore_manager : MonoBehaviour
{
    FirebaseFirestore db;
    Dictionary<string,object> user_score;
    string current_time = "";
    //int id = 0;
    // Start is called before the first frame update
    void Awake()
    {
        db = FirebaseFirestore.DefaultInstance;
        //Debug.Log(current_time);
    }
    public void saveData()
    {  
        current_time = System.DateTime.UtcNow.ToLocalTime().ToString("d/M/yy HH:mm tt");
        user_score = new Dictionary<string, object>{
            {"monument_type",scores_details_tracker.current_monument},
            {"user_score",scores_details_tracker.current_score},
            {"time",current_time},
        };
        
        updateId(user_score);

    }
    void GetData()
    {
        db.Collection("user_score").Document(publicval.user.Email).GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            if(task.IsCompleted){
                DocumentSnapshot snapshot = task.Result;
                if(snapshot.Exists){
                    user_score = snapshot.ToDictionary();
                }
            }
        });
    }
    public static async Task updateId(Dictionary<string,object> user_score)
        {
            FirebaseFirestore db;
            int tmp_id = 0;
            db = FirebaseFirestore.DefaultInstance;
            Query docRef = db.Collection("user_scores").Document(publicval.user.Email).Collection("user_details");
            QuerySnapshot userDet = await docRef.GetSnapshotAsync();
            foreach (DocumentSnapshot snapshot in userDet.Documents)
            {
                tmp_id = int.Parse(snapshot.Id);
                // Dictionary<string, object> city = documentSnapshot.ToDictionary();
                // foreach (KeyValuePair<string, object> pair in city)
                // {
                //     Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
                // }
                // Console.WriteLine("");
            }
            tmp_id+=1;
            scores_details_tracker.user_id = tmp_id.ToString();
            //Debug.Log(scores_details_tracker.user_id);
            DocumentReference userScoresRef = db.Collection("user_scores").Document(publicval.user.Email).Collection("user_details").Document(scores_details_tracker.user_id);
            await userScoresRef.SetAsync(user_score);
            SceneManager.LoadScene("user_score_history");
            // [END fs_get_all_docs]
        }






}