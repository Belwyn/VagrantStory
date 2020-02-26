using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.Characters.ThirdPerson;

namespace Vagrant.Character {


    public class CharController : MonoBehaviour {

        ThirdPersonUserControl _characterControl;

        protected void Awake() {
            _characterControl = GetComponentInChildren<ThirdPersonUserControl>();
        }

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {

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