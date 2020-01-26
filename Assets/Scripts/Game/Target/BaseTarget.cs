﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vagrant.Game.Targeting {

    public abstract class BaseTarget : MonoBehaviour, ITargetable {


        public void onNotTargetable() {
            TargetManager.instance.RemoveTarget(this);
        }

        public void onTargetable() {
            TargetManager.instance.AddTarget(this);
        }


    }

}