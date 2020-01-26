using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Vagrant.Game.Targeting {

    public class TriggerTarget : BaseTarget {


        private void OnTriggerEnter(Collider other) {
            onTargetable();
        }


        private void OnTriggerExit(Collider other) {
            onNotTargetable();
        }

    }

}