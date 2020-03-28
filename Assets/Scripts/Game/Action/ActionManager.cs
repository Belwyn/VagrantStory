using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Belwyn.Utils;

using Vagrant.Game;

namespace Vagrant.Action {
    
    
    public class ActionManager :  SingletonBehaviour<ActionManager>{

        private Action _action;
        public Action action { private get; set; }


        // TODO move it somewhere else
        [SerializeField]
        private Action _placeholderAction;



        void Start() {
            GameManager.instance.onActionMode.AddListener(BeginAction);
        }


        private void BeginAction() {
            Debug.LogWarning("ActionBegin");
            action = _placeholderAction;
            StartCoroutine(CoAction());
        }

        private void EndAction() {
            Debug.LogWarning("Action Ended");
            GameManager.instance.NormalMode();
            action = null;
        }


        private IEnumerator CoAction() {
            action.BeginAction();
            yield return new WaitUntil(action.isEnded);
            EndAction();
        }

    }


}
