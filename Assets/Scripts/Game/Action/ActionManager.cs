using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Belwyn.Utils;
using Belwyn.Events;

using Vagrant.Game;
using Vagrant.Input;
using UnityEngine.InputSystem;

namespace Vagrant.Action {
    
    
    public class ActionManager :  SingletonBehaviour<ActionManager>, MainInput.IPlayerActions {

        private BaseAction _action;
        public BaseAction action { private get; set; }

        private bool _chainActivationEnabled = false;
        private bool _chained = false;

        [SerializeField]
        public BoolEvent onChainActivationEnabled;
        

        // TODO move it somewhere else
        [SerializeField]
        private BaseAction _placeholderAction;



        void Start() {
            GameManager.instance.onActionMode.AddListener(BeginAction);
        }


        public void SetChainActivation(bool enable) {
            Debug.LogWarning($"Chain Activation {enable}");
            _chainActivationEnabled = enable;
            onChainActivationEnabled.Invoke(enable);
        }

        private void BeginAction() {
            Debug.LogWarning("ActionBegin");
            action = _placeholderAction;
            StartCoroutine(CoAction());
        }

        private void EndAction() {
            if (_chained) {
                Debug.LogWarning("Action Chained");
                _chained = false;
                BeginAction();
            }
            else {
                Debug.LogWarning("Action Ended");
                GameManager.instance.NormalMode();
                action = null;
            }
        }


        private IEnumerator CoAction() {
            action.BeginAction();
            yield return new WaitUntil(action.isEnded);
            EndAction();
        }



        // INPUT


        public void OnMove(InputAction.CallbackContext context) {
            throw new System.NotImplementedException();
        }

        public void OnAttack(InputAction.CallbackContext context) {
            

        }

        public void OnCancel(InputAction.CallbackContext context) {
            
        }

        public void OnJump(InputAction.CallbackContext context) {
            if (_chainActivationEnabled && context.ReadValue<float>() == 1) {
                _chained = true;
                SetChainActivation(false);
            }
        }
    }


}
