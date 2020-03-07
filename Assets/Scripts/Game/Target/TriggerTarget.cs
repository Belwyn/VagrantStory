using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vagrant.Game.Core;


namespace Vagrant.Game.Targeting {

    public class TriggerTarget : BaseTarget {

        public UnityEvent onHighlighted;
        public UnityEvent onNonHighlighted;



        // ITargetable

        private void OnTriggerEnter(Collider other) {
            //onTargetable();
        }


        private void OnTriggerExit(Collider other) {
            //onNotTargetable();
        }

        public override void onTargeted() {
            // TODO
            Debug.Log($"I've been targeted! {name}");
            GameManager.instance.NormalMode();
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