using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

namespace AC
{
    public class ResMgr : MonoBehaviour
    {
        private AssetBundle ab;
        private List<GameObject> res;
        private void Awake()
        {
            ab = AssetBundle.LoadFromFile( Application.streamingAssetsPath + "/planeprefabs");
            GameObject gameObj = (GameObject)ab.LoadAsset("Fighter");
            // Debug.Log(gameObject.name);
            //res.Add(gameObj);
    
        }
        // public GameObject GetRes(string resName)
        // {
        //     return res[0];
        // }
    }
}