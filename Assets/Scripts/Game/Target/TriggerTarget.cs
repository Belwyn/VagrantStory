using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vagrant.Game.Core;


namespace Vagrant.Game.Targeting {

    public class TriggerTarget : BaseTarget {        


        // ITargetable

        private void OnTriggerEnter(Collider other) {
            onTargetable();
        }


        private void OnTriggerExit(Collider other) {
            onNotTargetable();
        }

        public override void onTargeted() {
            // TODO
            Debug.Log($"I've been targeted! {name}");
        }

    }

}