using System;
using UnityEngine;

namespace AC
{
    public class Singleton<T> : MonoBehaviour where T :MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                return _instance;
            }
        }

        private void Awake()
        {
            _instance = this as T;
        }
    }
}