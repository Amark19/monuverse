using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeModel : MonoBehaviour
{

    GameObject objToSpawn;
    private GameObject spawnedObj;
    // Start is called before the first frame update
    public void clkToSpawn()
    {
        spawnedObj = Instantiate(objToSpawn, new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f, 0f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateModel(GameObject obj)
    {
        objToSpawn = obj;
    }
}
