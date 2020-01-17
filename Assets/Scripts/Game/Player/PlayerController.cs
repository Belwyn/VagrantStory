using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Vagrant.Input;

using UnityStandardAssets.Characters.ThirdPerson;

namespace Vagrant.Game.Player {
    public class PlayerController : MonoBehaviour, MainInput.IPlayerActions{


        MainInput mainInput;

        ThirdPersonUserControl _characterControl;

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
        }

        //////// IPlayerActions implementation

        public void OnAttack(InputAction.CallbackContext context) {
            Debug.Log($"{context.action.name} {context.phase} {context.ReadValue<float>()}");
        }

        public void OnJump(InputAction.CallbackContext context) {
            Debug.Log($"{context.action.name} {context.phase} {context.ReadValue<float>()}");
            if (_characterControl != null) {
                _characterControl.m_Jump = context.ReadValue<float>() == 1;
            }
        }

        public void OnMove(InputAction.CallbackContext context) {
            Debug.Log($"{context.action.name} {context.phase} {context.ReadValue<Vector2>()}");

            if (_characterControl != null) {
                Vector2 move = context.ReadValue<Vector2>();
                _characterControl.v = move.y;
                _characterControl.h = move.x;
            }
        }

    }
}