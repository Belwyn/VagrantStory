using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Vagrant.Action {
 
    
    public abstract class BaseAction : MonoBehaviour {

        private bool _ended;

        [SerializeField]
        private Animation _animation;

        public bool isEnded() { return _ended; }


        public void BeginAction() {
            _ended = false;
            if (!_animation.isPlaying)
                _animation.Play();
            else
                _animation.PlayQueued(_animation.clip.name);
        }


        public void EndAction() {
            _ended = true;
        }


        public void EnableChain() {
            ActionManager.instance.SetChainActivation(true);
        }

        public void DisableChain() {
            ActionManager.instance.SetChainActivation(false);
        }

    }

}