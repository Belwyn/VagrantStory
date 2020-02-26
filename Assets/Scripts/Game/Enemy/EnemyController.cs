using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Vagrant.Character;

namespace Vagrant.Enemy {


    [RequireComponent(typeof(CharController))]
    public class EnemyController : MonoBehaviour {

        CharController _charController;

        private void Awake() {
            _charController = GetComponent<CharController>();
        }


        private void Update() {
            if (Random.value <= 0.02f)
                _charController.Jump(true);
            else
                _charController.Jump(false);
        }

    }


}