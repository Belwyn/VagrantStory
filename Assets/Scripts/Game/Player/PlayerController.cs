using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Vagrant.Character;
using Vagrant.Input;
using Vagrant.Game.Targeting;

using UnityStandardAssets.Characters.ThirdPerson;


namespace Vagrant.Game.Player {

    [RequireComponent(typeof(CharController))]
    public class PlayerController : MonoBehaviour, MainInput.IPlayerActions{


        //MainInput mainInput;
        CharController _charController;
        public CharController charController => _charController;

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
            _charController = GetComponent<CharController>();
            _targeter = GetComponentInChildren<Targeter>();
            _targeter.Deactivate();
        }


        private void Start() {
            GameManager.instance.playerController = this;
            GameManager.instance.onTargetingMode.AddListener(OnTargetMode);
            GameManager.instance.onNormalMode.AddListener(OnNormalMode);
            GameManager.instance.onActionMode.AddListener(OnNormalMode);
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

        private void OnActionMode() {
            OnNormalMode();
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

            _charController.Jump(context.ReadValue<float>() == 1);
        }

        public void OnMove(InputAction.CallbackContext context) {
            if (debug)
                Debug.Log($"{context.action.name} {context.phase} {context.ReadValue<Vector2>()}");

            Vector2 move = context.ReadValue<Vector2>();
            _charController.Move(move);


        }

        public void OnCancel(InputAction.CallbackContext context) {
            if (debug)
                Debug.Log($"{context.action.name} {context.phase} {context.ReadValue<float>()}");

            NormalMode();
            
        }
    }
}