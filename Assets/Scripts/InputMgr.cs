using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AC
{
    public class InputMgr : Singleton<InputMgr>
    {
        private bool input_F = false;
        private bool input_R = false;
        private float horizontal = 0.0f;
        private float vertical = 0.0f;
        
        public float Horizontal
        {
            get { return horizontal; }
        }
        public float Vertical
        {
            get { return vertical; }
        }
        public bool Input_F
        {
            get { return input_F;}
        }
        public bool Input_R
        {
            get { return input_R;}
        }
        private void FixedUpdate()
        {
            Tick();
        }

        public void Tick()
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            input_F = Input.GetKeyDown(KeyCode.F);
            input_R = Input.GetKeyDown(KeyCode.R);
        }
    }
}