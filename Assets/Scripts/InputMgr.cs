using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AC
{
    public class InputMgr : Singleton<InputMgr>
    {
        public bool InputF => _input_F;
        public bool InputR => _input_R;
        public float Horizontal => _horizontal;
        public float Vertical => _vertical;

        private bool _input_F = false;
        private bool _input_R = false;
        private float _horizontal = 0.0f;
        private float _vertical = 0.0f;
        
        private void Update()
        {
            Tick();
        }

        public void Tick()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
            _input_F = Input.GetKeyDown(KeyCode.F);
            _input_R = Input.GetKeyDown(KeyCode.R);
        }
    }
}