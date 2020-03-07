using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vagrant.Game.Core {

    public interface ISelectable {

        string name { get; }

        GameObject gameObject { get; }


        void onHighlight();

        void onNonHighlight();


        void onSelected();
    }

}