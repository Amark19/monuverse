using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using UnityEngine.Networking;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTracking : MonoBehaviour
{
    GameObject placeablePrefabs;
    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();
    private ARTrackedImageManager trackedImageManager;
    public GameObject help;
    public Slider ProgressSlider;
    public Text PercentageText;
    public GameObject LoadingCanvas;
    AssetBundle assetBundle;
    public string name_model;
    public string url;
    string name;

    public void Awake()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>(); 
        downloadmodel();   
    }
    public void Start(){      
        Debug.Log("start");
        name="";
        
        trackedImageManager.trackedImagesChanged += ImageChanged;        
    }
    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += ImageChanged;
    }
    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= ImageChanged;
    }
    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateImage(trackedImage);
            Debug.Log("added "+trackedImage.referenceImage.name);
        }
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {            
            UpdateImage(trackedImage);           
            Debug.Log("update "+trackedImage.referenceImage.name);
        }
        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            spawnedPrefabs[trackedImage.referenceImage.name].SetActive(false);
        }
    }
    private void UpdateImage(ARTrackedImage trackedImage)
    {       
        name = trackedImage.referenceImage.name;
        Vector3 position = trackedImage.transform.position;
        Debug.Log("Updateimage "+name+" tracked name: "+ trackedImage.referenceImage.name);
        try
        {GameObject prefab = spawnedPrefabs[name];
        prefab.transform.position = position;
        prefab.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        prefab.SetActive(true);}
        catch(KeyNotFoundException e){Debug.Log("Exception "+name+"  key not found "+ e.Message +" "+trackedImage.referenceImage.name);}
        
        
        help.SetActive(false);

        foreach (GameObject go in spawnedPrefabs.Values)
        {
            if (go.name != name || trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.None || trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Limited)
            {
                go.SetActive(false);
                help.SetActive(true);
                Debug.Log("Go "+name);
                
            }
        }
    }

    ////////////////////////////////////////////////////////////
    public IEnumerator webReq(string url, string namee){
        WWW request = WWW.LoadFromCacheOrDownload(url, 0);
        //WWW request = new WWW(url);
        while (!request.isDone)
        {
            publicval.flago = 0;
            ProgressSlider.value = request.progress;
            string persentateTemp = "" + request.progress * 100;
            string[] strArray = persentateTemp.Split(char.Parse("."));
            PercentageText.text = strArray[0] + "%";
            // Debug.Log(strArray[0] + "%");
            yield return null;
        }

        if (request.error == null)
        {
            ProgressSlider.value = 1;
            PercentageText.text = "100%";
            AssetBundle assetBundle = request.assetBundle;
            LoadingCanvas.SetActive(false);
            StartCoroutine(setModel(assetBundle.LoadAsset<GameObject>(namee)));
            assetBundle.Unload(false);
            Debug.Log("Success!!!");
            
        }
        else
        {
            ProgressSlider.value = 1;
            PercentageText.text = "100%";
            AssetBundle assetBundle = request.assetBundle;
            LoadingCanvas.SetActive(false);
            StartCoroutine(setModel(assetBundle.LoadAsset<GameObject>(namee)));
            Debug.Log("Error" + request.error);
        }
        yield return null;
    }

    public void downloadmodel(){
        //this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        StartCoroutine(webReq(url, name_model)); 
    }
    public IEnumerator setModel(GameObject obj){       
        placeablePrefabs = obj;
        Debug.Log("place name: " + placeablePrefabs.name);
        //this.gameObject.transform.GetChild(0).gameObject.SetActive(true);

        GameObject newPrefab = Instantiate(placeablePrefabs, Vector3.zero, Quaternion.identity);
        newPrefab.name = placeablePrefabs.name;
        Debug.Log(newPrefab.name+" instance");
        newPrefab.transform.localScale = new Vector3(0, 0, 0);
        spawnedPrefabs.Add(placeablePrefabs.name, newPrefab);
        yield return null;
    }




}