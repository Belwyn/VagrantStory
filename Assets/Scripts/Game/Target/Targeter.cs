using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Vagrant.Game.Targeting {

    [RequireComponent(typeof(Collider))]
    public class Targeter : MonoBehaviour {

        Collider _trigger;

        List<Collider> _currentTargets;

        [SerializeField]
        GameObject _visual;

        private void Awake() {
            _trigger = GetComponent<Collider>();
            _trigger.isTrigger = true;
            _currentTargets = new List<Collider>();
        }



        public void Activate() {
            //_trigger.enabled = true;
            if (_visual != null)
                _visual.SetActive(true);

            _currentTargets.ForEach(t => t.GetComponent<BaseTarget>().onTargetable());
        }


        public void Deactivate() {
            //_trigger.enabled = false;
            //_currentTargets.ForEach(c => TargetManager.instance.RemoveTarget(c.GetComponent<BaseTarget>()));
            //_currentTargets.Clear();
            if (_visual != null)
                _visual.SetActive(false);
            _currentTargets.ForEach(t => t.GetComponent<BaseTarget>().onNotTargetable());
        }


        private void OnTriggerEnter(Collider other) {
            if (!_currentTargets.Contains(other)) {
                _currentTargets.Add(other);
            }
        }

        private void OnTriggerExit(Collider other) {
            if (_currentTargets.Remove(other)){
                //
                //
                //
            }
        }

    }

}