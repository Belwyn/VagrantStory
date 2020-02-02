using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vagrant.Game.Core {

    public interface ISelectable {

        string name { get; }

        GameObject gameObject { get; }


        void onSelected();

        void onUnselected();


        void onSelectionConfirm();
    }

}