using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AC
{
    public class CameraMgr : MonoBehaviour
    {
        public Transform followTarget;
        private Vector3 shakeVector3 = new Vector3();
        private float ShakeTime { get; set; }
        private float shakeValue = .5f;
        private Vector3 localPosOrigin = new Vector3(0.0f,3.67f,-13.8f);

        private void Awake()
        {
            if (followTarget == null)
            {
                followTarget = transform.parent;
            }
        }

        private void FixedUpdate()
        {
            if (InputMgr.Instance.Input_F)
            {
                ShakeTime = 0.5f;
            }
            transform.localPosition = localPosOrigin;
            ShakeCamera(Time.fixedDeltaTime);
            transform.localPosition += shakeVector3;
        }

        private void ShakeCamera(float deltaTime)
        {
            if (ShakeTime > 0.0f)
            {
                ShakeTime -= deltaTime;
                float shakeX = Random.Range(0.0f, 1.0f) * shakeValue;
                float shakeY = Random.Range(0.0f, 1.0f) * shakeValue;
                float shakeZ = Random.Range(0.0f, 1.0f) * shakeValue;
                shakeVector3.Set(shakeX, shakeY, shakeZ);
            }
            else
            {
                ShakeTime = 0.0f;
                shakeVector3.Set(0.0f,0.0f,0.0f);
            }
        }
    }
}

