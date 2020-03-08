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

        protected void Awake() {
            _characterControl = GetComponentInChildren<ThirdPersonUserControl>();
            _character = GetComponentInChildren<ThirdPersonCharacter>();
            _timeScaledBehaviour = GetComponent<TimeScaledBehaviour>();
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



        public void Jump(bool value) {
            _characterControl.m_Jump = value;
        }


        public void Move(Vector2 movement) {
            _characterControl.v = movement.y;
            _characterControl.h = movement.x;
        }


    }


}