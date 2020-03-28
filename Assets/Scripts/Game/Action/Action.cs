using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Vagrant.Action {


    public class Action : MonoBehaviour {


        private bool _ended;

        [SerializeField]
        private Animation _animation;

        public bool isEnded() { return _ended; }


        public void BeginAction() {
            _ended = false;
            _animation.Play();
        }


        public void EndAction() {
            _ended = true;
        }



    }

}