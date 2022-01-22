using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AC
{
    public class InfoPanel : MonoBehaviour
    {
        private Text infoText;
        public static string txtContext = "null";
        private void Awake()
        {
            infoText = transform.GetChild(0).gameObject.GetComponent<Text>();
        }
    
        private void Update()
        {
            infoText.text = InfoPanel.txtContext;
        }
    }
}