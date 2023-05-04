using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Firebase;
public class publicval : MonoBehaviour
{
    public static int flago = 0;
    public static FirebaseApp app;
    public static Firebase.Auth.FirebaseAuth auth;
    public static Firebase.Auth.FirebaseUser user;
    public static Stack<string> scenes = new Stack<string>();
    public static int lang = 0;
    public static int is_sign = 0;
}
