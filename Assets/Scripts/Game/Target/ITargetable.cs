using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vagrant.Game.Targeting {

    public interface ITargetable {

        string name { get; }

        GameObject gameObject { get; }

        void onTargetable();

        void onNotTargetable();


    }

}