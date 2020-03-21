using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Belwyn.Utils;

using Vagrant.Game;

namespace Vagrant.Action {
    
    
    public class ActionManager :  SingletonBehaviour<ActionManager>{

        [SerializeField]
        private float _actionSeconds;


        void Start() {
            GameManager.instance.onActionMode.AddListener(BeginAction);
        }


        private void BeginAction() {
            Debug.LogWarning("ActionBegin");
            StartCoroutine(CoAction());
        }

        private void EndAction() {
            Debug.LogWarning("Action Ended");
            GameManager.instance.NormalMode();
        }


        private IEnumerator CoAction() {
            yield return new WaitForSeconds(_actionSeconds);
            EndAction();
        }

    }


}
