using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class ARPlacement : MonoBehaviour
{
    public string name_model;
    public string url;
    public GameObject arObjectToSpawn;
    public GameObject placementIndicator;
    private GameObject spawnedObject;
    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;
    public GameObject helperovlay;
    public bool isfetch = true;//for puzzle as we r placing obj but not fetching it from db
    public GameObject pauseBtn;

    void Start()
    {
        helperovlay.SetActive(false);
        if (isfetch){
        publicval.flago = 0;
        downloadmodel();
        }
        else{
        helperovlay.SetActive(true);
        publicval.flago = -1;
        }
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
    }
    void Update()
    {
        if (spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ARPlaceObject();
        }

        UpdatePlacementPose();
        UpdatePlacementIndicator();

        // if (publicval.flago == 0)
        // {
        //     GameObject.Find("Canvas").transform.GetChild(0).transform.gameObject.SetActive(true);
        //     //GameObject.Find("cano").transform.GetChild(0).transform.gameObject.SetActive(true);
        //     GameObject.Find("bghint").transform.GetChild(0).GetComponent<Animation>().Play();
        // }
        // if (publicval.flago == 1)
        // {
        //     publicval.flago = -1;
        //     StartCoroutine(stopper());
        // }

    }
    void UpdatePlacementIndicator()
    {
        if (spawnedObject == null && placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            PlacementPose = hits[0].pose;
        }
    }

    void ARPlaceObject()
    {
        if(isfetch){
            spawnedObject = Instantiate(arObjectToSpawn, PlacementPose.position, PlacementPose.rotation);
            if(name_model == "kedarnath"){
                pauseBtn.SetActive(true);
            }
        }
        else{
            spawnedObject = arObjectToSpawn;
            arObjectToSpawn.SetActive(true);
            spawnedObject.transform.SetPositionAndRotation(new Vector3(PlacementPose.position.x,PlacementPose.position.y + .5f,PlacementPose.position.z), PlacementPose.rotation);
        }
        Debug.Log("here-5");
        var planeManager = this.GetComponent<ARPlaneManager>();
        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
        this.GetComponent<ARPlaneManager>().enabled = false;
        this.GetComponent<ARPlane>().enabled = false;
        helperovlay.SetActive(false);
    }

    IEnumerator stopper()
    {
        yield return new WaitForSeconds(3);
    }
     void downloadmodel(){
        //this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        StartCoroutine(this.GetComponent<loadassets>().webReq(url, name_model));
        
    }
     public void setModel(GameObject obj){
       
        Debug.Log("finish");
        helperovlay.SetActive(true);
        arObjectToSpawn = obj;
        publicval.flago = 0;
    }

}
