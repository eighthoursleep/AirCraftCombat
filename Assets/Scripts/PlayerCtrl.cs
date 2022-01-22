using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AC
{
    public class PlayerCtrl : MonoBehaviour
    {
        public GameObject model;
        public Camera cameraFollow;

        [Header("当前速度")]
        public float velocity = 50.0f;
        [Header("转向速度")]
        public float rotSpeed = 30.0f;
        [Header("模型转向速度")]
        public float rotSpeedModel = 3.0f;
        
        public float PITCH_MAX = 10.0f;
        public float YAW_MAX = 10.0f;
        public float ROLL_MAX = 10.0f;

        private Vector3 moveDir = new Vector3();
        private Vector3 startPos = new Vector3();
        private void Awake()
        {
            if (model == null)
            {
                model = transform.GetChild(0).gameObject;
            }

            if (cameraFollow == null)
            {
                GameObject camera = transform.Find("CameraFollow").gameObject;
                cameraFollow = camera.GetComponent<Camera>();
            }
        }

        private void Start()
        {
            startPos.Set(transform.position.x, transform.position.y, transform.position.z);
        }

        private void FixedUpdate()
        {
            UpdateMoveRot(Time.fixedDeltaTime);
            UpdateRotaion(Time.fixedDeltaTime);
            UpdatePosition(Time.fixedDeltaTime);
        }

        private void UpdateMoveRot(float deltaTime)
        {
            float yaw = InputMgr.Instance.Horizontal;
            float pitch = InputMgr.Instance.Vertical;
            if (yaw != 0.0f || pitch != 0.0f)
            {
                transform.RotateAround(transform.position,transform.up, yaw * rotSpeed * deltaTime);
                transform.RotateAround(transform.position,-transform.right, pitch * rotSpeed * deltaTime);
            }
        }
        /// <summary>
        /// 改变前进方向，原理是直接在前进方向上叠加输入，效果很怪，不像真实飞机转向。
        /// </summary>
        private void UpdateMoveDir()
        {
            moveDir = transform.forward;
            float horizontal = rotSpeed * InputMgr.Instance.Horizontal;
            float vertical = rotSpeed * InputMgr.Instance.Vertical;
            Vector3 dir = Vector3.zero;
            dir.x = horizontal;
            dir.y = vertical;
            moveDir += dir;
        }
        /// <summary>
        /// 改变模型转向
        /// </summary>
        /// <param name="deltaTime"></param>
        private void UpdateRotaion(float deltaTime)
        {
            Quaternion curRotation = model.transform.rotation;
            Quaternion targetRotation = transform.rotation;
            float pitch = PITCH_MAX * -InputMgr.Instance.Vertical;
            float yaw = YAW_MAX * InputMgr.Instance.Horizontal;
            float roll = ROLL_MAX * -InputMgr.Instance.Horizontal;
            targetRotation *= Quaternion.Euler(pitch,yaw,roll);
            InfoPanel.txtContext = string.Format("targetRotation : {0}", targetRotation);
            Quaternion newRotation = Quaternion.Slerp(curRotation,targetRotation, rotSpeedModel * deltaTime);
            model.transform.rotation = newRotation;
        }

        private void UpdatePosition(float deltaTime)
        {
            Vector3 translation = transform.forward * velocity * deltaTime;
            transform.Translate(translation,Space.World);
        }

        private void Update()
        {
            if (InputMgr.Instance.Input_R)
            {
                Debug.Log("is R");
                transform.position.Set(startPos.x, startPos.y, startPos.z);
                transform.position = transform.position;
            }
        }
    }
}

