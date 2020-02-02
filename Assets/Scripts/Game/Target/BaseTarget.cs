using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vagrant.Game.Core;

namespace Vagrant.Game.Targeting {

    public abstract class BaseTarget : MonoBehaviour, ITargetable, ISelectable {

        // ITargetable

        public void onNotTargetable() {
            TargetManager.instance.RemoveTarget(this);
        }

        public void onTargetable() {
            TargetManager.instance.AddTarget(this);
        }


        public abstract void onTargeted();



        // ISelectable

        public virtual void onSelected() {
            
        }

        public void onSelectionConfirm() {
            onTargeted();
        }

        public void onUnselected() {
            
        }
    }

}