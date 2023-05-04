using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadAssetBundle : MonoBehaviour
{
    public string url="";
    void Start(){
        StartCoroutine(webReq());
    }

    IEnumerator webReq(){
        using (WWW web = new WWW(url))
        {
            yield return web;
            AssetBundle remoteAssetBundle = web.assetBundle;
            if (remoteAssetBundle == null) {
                Debug.LogError("Failed to download AssetBundle!");
                yield break;
            }
            Instantiate(remoteAssetBundle.LoadAsset("charminar"));
            remoteAssetBundle.Unload(false);
        }
    }
}
