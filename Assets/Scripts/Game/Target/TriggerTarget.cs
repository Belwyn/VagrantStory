using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vagrant.Game.Core;
using Vagrant.Character;


namespace Vagrant.Game.Targeting {

    public class TriggerTarget : BaseTarget {

        public UnityEvent onHighlighted;
        public UnityEvent onNonHighlighted;

        private CharController _charController;

        // ITargetable

        private void Awake() {
            _charController = GetComponentInParent<CharController>();
        }

        private void OnTriggerEnter(Collider other) {
            //onTargetable();
        }


        private void OnTriggerExit(Collider other) {
            //onNotTargetable();
        }

        public override void onTargeted() {
            // TODO
            Debug.Log($"I've been targeted! {name}");
            TargetManager.instance.AddAffectedCharacter(_charController);
            GameManager.instance.ActionMode();
        }


        public override void onHighlight() {
            base.onHighlight();
            onHighlighted.Invoke();
        }

        public override void onNonHighlight() {
            base.onNonHighlight();
            onNonHighlighted.Invoke();
        }

    }

}