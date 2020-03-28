using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.Characters.ThirdPerson;

using Vagrant.Game;

namespace Vagrant.Character {

    [RequireComponent(typeof(TimeScaledBehaviour))]
    public class CharController : MonoBehaviour {

        ThirdPersonUserControl _characterControl;
        TimeScaledBehaviour _timeScaledBehaviour;
        ThirdPersonCharacter _character;

        bool _controlEnabled = true;

        protected void Awake() {
            _characterControl = GetComponentInChildren<ThirdPersonUserControl>();
            _character = GetComponentInChildren<ThirdPersonCharacter>();
            _timeScaledBehaviour = GetComponent<TimeScaledBehaviour>();

            GameManager.instance.onNormalMode.AddListener(EnableControl);
            GameManager.instance.onTargetingMode.AddListener(DisableControl);
        }

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            //GetComponentInChildren<Animator>().speed = GetComponent<TimeScaledBehaviour>().timescale;
            //_character.m_MoveSpeedMultiplier = _timeScaledBehaviour.timescale;
            //_character.m_AnimSpeedMultiplier = _timeScaledBehaviour.timescale;
            _character.timescale = _timeScaledBehaviour.timescale;
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
                _characterControl.m_Jump = value;
        }


        public void Move(Vector2 movement) {
            if (_controlEnabled) {
                _characterControl.v = movement.y;
                _characterControl.h = movement.x;
            }
        }


    }


}