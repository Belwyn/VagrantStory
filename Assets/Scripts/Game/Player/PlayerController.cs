using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Vagrant.Input;
using Vagrant.Game.Targeting;

using UnityStandardAssets.Characters.ThirdPerson;



namespace Vagrant.Game.Player {
    public class PlayerController : MonoBehaviour, MainInput.IPlayerActions{


        //MainInput mainInput;

        ThirdPersonUserControl _characterControl;

        public bool debug = false;

        public bool isAttacking { get; private set; }

        Targeter _targeter;

        /*

        public void OnEnable() {
            if (mainInput == null) {
                mainInput = new MainInput();
                // Tell the "gameplay" action map that we want to get told about
                // when actions get triggered.
                mainInput.Player.SetCallbacks(this);
            }
            mainInput.Player.Enable();
        }


        */

        private void Awake() {
            _characterControl = GetComponentInChildren<ThirdPersonUserControl>();
            _targeter = GetComponentInChildren<Targeter>();
            _targeter.Deactivate();
        }


        private void Start() {
            GameManager.instance.playerController = this;
            GameManager.instance.onTargetingMode.AddListener(OnTargetMode);
            GameManager.instance.onNormalMode.AddListener(OnNormalMode);
        }



        private void TargetMode() {
            GameManager.instance.TargetingMode();
        }

        private void NormalMode() {
            GameManager.instance.NormalMode();
        }


        private void OnTargetMode() {
            isAttacking = true;
            _targeter.Activate();
        }

        private void OnNormalMode() {
            isAttacking = false;
            _targeter.Deactivate();
        }


        //////// IPlayerActions implementation

        public void OnAttack(InputAction.CallbackContext context) {
            if (debug) 
                Debug.Log($"{context.action.name} {context.phase} {context.ReadValue<float>()}");
            
            if (!isAttacking) {
                TargetMode();
            }            

        }

        public void OnJump(InputAction.CallbackContext context) {
            if (debug)
                Debug.Log($"{context.action.name} {context.phase} {context.ReadValue<float>()}");
            if (_characterControl != null) {
                _characterControl.m_Jump = context.ReadValue<float>() == 1;
            }
        }

        public void OnMove(InputAction.CallbackContext context) {
            if (debug)
                Debug.Log($"{context.action.name} {context.phase} {context.ReadValue<Vector2>()}");

            if (_characterControl != null) {
                Vector2 move = context.ReadValue<Vector2>();
                _characterControl.v = move.y;
                _characterControl.h = move.x;
            }
        }

        public void OnCancel(InputAction.CallbackContext context) {
            if (debug)
                Debug.Log($"{context.action.name} {context.phase} {context.ReadValue<float>()}");

            NormalMode();
            
        }
    }
}