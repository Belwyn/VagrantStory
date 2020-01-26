using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Vagrant.Game.UI {

    public class SelectableSceneElement : Selectable {

        private GameObject _sceneElement;
        public GameObject sceneElement => _sceneElement;



        public SelectableSceneElement assignSceneObject(GameObject go) {
            _sceneElement = go;
            if (GetComponentInChildren<Text>() != null)
                GetComponentInChildren<Text>().text = go.name;
            return this;
        }


        protected override void OnEnable() {
            interactable = true;
        }

        protected override void OnDisable() {
            _sceneElement = null;
            interactable = false;
        }


    }

}
