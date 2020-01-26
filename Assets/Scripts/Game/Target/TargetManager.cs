using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Vagrant.Game.Targeting {

    public class TargetManager : MonoBehaviour {

        private List<ITargetable> _targets;

        private static TargetManager _instance;

        public static TargetManager instance {
            get {
                if (_instance == null)
                    _instance = Instantiate(new GameObject()).AddComponent<TargetManager>();
                return _instance;
            }
        }

        private bool _dirty = false;

        private void Awake() {

            if (_instance != null) {
                Destroy(this);
                return;
            }

            _instance = this;

            _targets = new List<ITargetable>();

            DontDestroyOnLoad(gameObject);
        }


        private void Update() {
            
            if (_dirty) {
                refreshTargets();
            }

            _dirty = false;
        }


        private void refreshTargets() {
            // TODO
            string message = "Targets: \n";
            //string message = $"Targets: \n {string.Join("\n", _targets)}";
            _targets.ForEach( t => { message += $"{t.name}"; });

            Debug.Log(message);
        }


        public void addTarget(ITargetable target) {
            if (!_targets.Contains(target)) {
                _targets.Add(target);
                _dirty = true;
            }
        }
        
        public void removeTarget(ITargetable target) {
            if (_targets.Contains(target)) {
                _targets.Remove(target);
                _dirty = true;
            }
        }


    }
}
