using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Vagrant.Game.Core;

namespace Vagrant.Game.UI {

    public class AffinityDataUI : MonoBehaviour {

        AffinityData _data;
        public AffinityData data {
            set {
                _data = value;
                UpdateData();
            }
        }

        List<DataValueUI> _uiValues;


        private void Awake() {

            _uiValues = new List<DataValueUI>(GetComponentsInChildren<DataValueUI>());
            int i = 0;

            foreach (DataValueUI dataValueUI in _uiValues){
                dataValueUI.label = ((AffinityEnum)i).ToString();
                i++;
            }

        }


        // DELETE ME
        /*
        private void Update() {
            if (_model == null) {
                Blade blade = FindObjectOfType<Blade>();
                if (blade != null)
                    _model = blade.affinityData;
            } 
            else UpdateData();

        }
        */

        private void UpdateData() {
            int i = 0;
            foreach (DataValueUI dataValueUI in _uiValues) { 
                dataValueUI.value = _data[i];
                dataValueUI.barFill = _data[i] * 0.1f;
                i++;
            }

        }

    }

}