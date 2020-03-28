using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Vagrant.Game.Core;
using Vagrant.Game.Targeting;



namespace Vagrant.Game.UI {

    [RequireComponent(typeof(Button))]
    public class UITarget : MonoBehaviour, ISelectable {

        private BaseTarget _target;
        public BaseTarget target => _target;


        public Button button { get; set; }


        private void Awake() {
            button = GetComponent<Button>();
            //button.onClick.AddListener(onSelected);
        }


        protected void OnEnable() {
            button.interactable = true;
            button.navigation = Navigation.defaultNavigation;
        }

        protected void OnDisable() {
            _target = null;
            button.interactable = false;
        }



        public UITarget assignTarget(BaseTarget target) {
            _target = target;
            if (GetComponentInChildren<Text>() != null)
                GetComponentInChildren<Text>().text = target.name;
            return this;
        }


        // ISelectable
        public void onHighlight() {
            target.onHighlight();     
        }

        public void onNonHighlight() {
            target.onNonHighlight();
        }

        public void onSelected() {
            target.onSelected();
        }




    }

}
