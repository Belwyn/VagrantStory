using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.Characters.ThirdPerson;

using Vagrant.Game;

namespace Vagrant.Character {

    public class CharController : MonoBehaviour {

        [SerializeField]
        private Character _character;

        private bool _controlEnabled = true;

        private bool _jump = false;
        private Vector3 _move = new Vector3();

        private float _v = 0.0f;
        private float _h = 0.0f;
        private Vector3 _forward = new Vector3();

        protected void Awake() {
            if (_character == null) _character = GetComponentInChildren<Character>();
        }

        void Start() {
            GameManager.instance.onNormalMode.AddListener(EnableControl);
            GameManager.instance.onTargetingMode.AddListener(DisableControl);
        }


        void Update() {
            //GetComponentInChildren<Animator>().speed = GetComponent<TimeScaledBehaviour>().timescale;
            //_character.m_MoveSpeedMultiplier = _timeScaledBehaviour.timescale;
            //_character.m_AnimSpeedMultiplier = _timeScaledBehaviour.timescale;
            //_character.timescale = _timeScaledBehaviour.timescale;
        }


        private void FixedUpdate() {

            //if (cam) {
            _forward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            _move = _v * _forward + _h * Camera.main.transform.right;
            //}
            //else {
            //_move = _v * Vector3.forward + _h * Vector3.right;
            //}
            _character.Move(_move, _jump);
            _jump = false;
        }



        public void EnableControl() {
            _controlEnabled = true;
        }

        public void DisableControl() {
            Jump(false);
            Move(Vector2.zero);
            _controlEnabled = false;
        }



        public void Jump(bool value) {
            if (_controlEnabled)
                _jump = value;
        }


        public void Move(Vector2 movement) {
            if (_controlEnabled) {
                _v = movement.y;
                _h = movement.x;
            }

        }


    }


}